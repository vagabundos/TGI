using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.ServiceModel;
using System.ServiceModel.Description;
using Biblioteca.Controle;
using Biblioteca.Comunicação;

namespace Servico
{
    #region Interface WebService
    [ServiceContract]
    public interface IwsrvHomeOn
    {
        [OperationContract]
        bool EnviaRequisicao(string CodigoControlador, string CodigoDispositivo, string NovoValor, out string Mensagem);
    }
    #endregion

    public class ExecucaoBackground : IwsrvHomeOn
    {
        #region Propriedades
        private SerialPort portaXbeeServidor = new SerialPort();

        public string _BaseAddress
        {
            get
            {
                return "http://localhost:8000/Service";
            }
        }

        public string _ApplicationName
        {
            get
            {
                return "wsrvHomeOn.svc";
            }
        }

        public Uri _UriServidor
        {
            get
            {
                return new Uri(_BaseAddress + _ApplicationName);
            }
        }

        private static System.Collections.Concurrent.ConcurrentQueue<MensagemDispositivo> cqMsgRecebidas;
        private static System.Collections.Concurrent.ConcurrentQueue<MensagemDispositivo> cqMsgEnvio;
        //private static SynchronizedCollection<MensagemDispositivo> lstMensagensRecebidas;
        //private static SynchronizedCollection<MensagemDispositivo> lstMensagensEnvio;

        #endregion

        #region Métodos
        // Loop do serviço
        public void LoopPrincipal()
        {
            // Inicia Filas de comunicação entre as threads
            cqMsgRecebidas = new System.Collections.Concurrent.ConcurrentQueue<MensagemDispositivo>();
            cqMsgEnvio = new System.Collections.Concurrent.ConcurrentQueue<MensagemDispositivo>();

            // objeto Host (hospeda WebService)
            System.ServiceModel.ServiceHost Host = null;

            try
            {
                // Porta Serial, comunicação com a rede de sensores 
                // Correspondente ao Xbee conectado ao servidor
                portaXbeeServidor.PortName = "COM3";
                portaXbeeServidor.BaudRate = 9600;
                portaXbeeServidor.Parity = Parity.None;
                portaXbeeServidor.DataBits = 8;
                portaXbeeServidor.StopBits = StopBits.One;
                portaXbeeServidor.Open();

                // Evento para processar as mensagens recebidas pela rede de sensores
                portaXbeeServidor.DataReceived += portaXbeeServidor_DataReceived;

                // Inicia WebService
                // Recebe as requisições do gerenciador para envio aos dispositivos
                BasicHttpBinding bnd = new BasicHttpBinding();
                bnd.CloseTimeout = new TimeSpan(0, 0, 10, 0, 0);
                bnd.OpenTimeout = new TimeSpan(0, 0, 10, 0, 0);
                bnd.ReceiveTimeout = new TimeSpan(0, 0, 10, 0, 0);
                bnd.SendTimeout = new TimeSpan(0, 0, 10, 0, 0);

                using (Host = new ServiceHost(typeof(ExecucaoBackground), new Uri[] { new Uri(_BaseAddress) }))
                {
                    Host.AddServiceEndpoint(typeof(IwsrvHomeOn), bnd, _ApplicationName);

                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    Host.Description.Behaviors.Add(smb);

                    Host.Open();

                    while (Service._bAtivo)
                    {
                        try
                        {
                            MensagemDispositivo objMsg;

                            // Processa mensagem de envio
                            if (cqMsgEnvio.TryDequeue(out objMsg))
                            {
                                try
                                {
                                    portaXbeeServidor.Write(objMsg.TextoEnvio());
                                }
                                catch(Exception exc)
                                {

                                }
                            }

                            // Processa mensagem recebida
                            if (cqMsgRecebidas.TryDequeue(out objMsg))
                            {
                                // Chama método que avalia e grava informação recebida do controlador
                            }

                            System.Threading.Thread.Sleep(1000);
                        }
                        catch(Exception exc)
                        {

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, string.Format("Erro ao inicializar o serviço (LoopPrincipal). Detalhes:\r\n{0}", exc.Message), exc);
                return;
            }
            finally
            {
                // Fecha Webservice
                if (Host != null && Host.State != CommunicationState.Closed && Host.State != CommunicationState.Closing)
                    Host.Close();

                Host = null;

                // Fecha conexão serial
                if (portaXbeeServidor != null)
                {
                    if (portaXbeeServidor.IsOpen)
                        portaXbeeServidor.Close();

                    portaXbeeServidor.Dispose();
                }

                portaXbeeServidor = null;
            }
        }

        /// <summary>
        /// Método Web Service para colocar mensagens na fila de envio aos constroladores da rede
        /// </summary>
        public bool EnviaRequisicao(string CodigoControlador, string CodigoDispositivo, string NovoValor, out string Mensagem)
        {
            Mensagem = string.Empty;

            try
            {
                MensagemDispositivo objMensagem = new MensagemDispositivo();

                // Monta Header
                objMensagem._Header = new MensagemDispositivo.Header();
                objMensagem._Header.ID_Sender = "SERVIDOR";
                objMensagem._Header.ID_Receiver = CodigoControlador;

                // Monta Command
                objMensagem._Command = new MensagemDispositivo.Command();
                objMensagem._Command.ID_Dispositivo = CodigoDispositivo;
                objMensagem._Command.Disp_Value = NovoValor;

                // Coloca na Fila para envio
                cqMsgEnvio.Enqueue(objMensagem);
                return true;
            }
            catch (Exception exc)
            {
                Mensagem = "Erro ao montar requisição de envio ao controlador. Consulte o log para maiores detalhes.";
                controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao montar requisição de envio ao controlador. (EnviaRequisicao)", exc);
                return false;
            }
        }

        public void RecebeMensagem()
        {
            if (portaXbeeServidor.IsOpen)
            {
                string RxString=string.Empty;

                try
                {
                    while (portaXbeeServidor.BytesToRead > 0)
                    {
                    }

                    // Lê dados
                    RxString = portaXbeeServidor.ReadLine();
                }
                catch (Exception exc)
                {
                    controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro durante a leitura de dados da porta serial. (portaXbeeServidor_DataReceived)", exc);
                    return;
                }

                try
                {
                    // Monta mensagem recebida
                    MensagemDispositivo msgRecebida = new MensagemDispositivo(RxString);

                    // Adiciona na fila 
                    cqMsgRecebidas.Enqueue(msgRecebida);
                }
                catch (Exception exc)
                {
                    controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro,
                        string.Format("Erro ao instanciar objeto MensagemRecebida (portaXbeeServidor_DataReceived). Texto recebido: {0}", RxString), exc);
                    return;
                }
            }
        }

        #endregion

        #region Eventos
        /// <summary>
        /// Evento disparado sempre que recebido dados da porta serial (Xbee)
        /// </summary>
        void portaXbeeServidor_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Chama método responsável pelo recebimento de mensagens
            RecebeMensagem();
        }
        #endregion
    }
}

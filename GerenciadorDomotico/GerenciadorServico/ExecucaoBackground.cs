using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using Biblioteca.Controle;
using Dados;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Servico
{
    #region Interface WebService
    [ServiceContract]
    public interface IwsrvHomeOn
    {
        [OperationContract]
        bool EnviaRequisicao(string CodigoDispositivo, string NovoValor);
    }
    #endregion

    public class ExecucaoBackground : IwsrvHomeOn
    {
        #region Propriedades
        SerialPort portaXbeeServidor = new SerialPort();

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
        #endregion

        #region Métodos
        // Loop do serviço
        public void LoopPrincipal()
        {
            System.ServiceModel.ServiceHost Host = null;

            try
            {
                // Porta Serial, comunicação com a rede de sensores (Xbee conectado ao servidor)
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
                            System.Threading.Thread.Sleep(1000);
                        }
                        finally
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

        public bool EnviaRequisicao(string CodigoDispositivo, string NovoValor)
        {
            return true;
        }
        #endregion

        #region Eventos
        void portaXbeeServidor_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (portaXbeeServidor.IsOpen)
            {
                string RxString = portaXbeeServidor.ReadLine();
                // Valida e ...
                // Mensagem recebida, processa mensagem....

                Console.WriteLine(RxString);
            }
        }
        #endregion
    }
}

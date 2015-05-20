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
using System.Configuration;
using System.Reflection;
using System.Threading;
using System.Security.Permissions;

namespace Servico
{
    public class ExecucaoBackground : IwsrvHomeOn
    {
        #region Propriedades
        private SerialPort portaXbeeServidor;

        /// <summary>
        /// Endereco base do WebService
        /// </summary>
        private string _BaseAddress
        {
            get
            {
                return string.Format("http://{0}:{1}", Service._configuradorGeral.WsServidor, Service._configuradorGeral.WsPorta);
            }
        }

        /// <summary>
        /// Nome da aplicação do WebService
        /// </summary>
        private string _ApplicationName
        {
            get
            {
                return "wsrvHomeOn.svc";
            }
        }

        /// <summary>
        /// Retorna objeto Uri com caminho do servidor Web Service
        /// </summary>
        public string _UriServidor
        {
            get
            {
                return string.Format("{0}/{1}", _BaseAddress, _ApplicationName);
            }
        }

        private static System.Collections.Concurrent.ConcurrentQueue<MensagemDispositivo> cqMsgRecebidas;
        private static System.Collections.Concurrent.ConcurrentQueue<MensagemDispositivo> cqMsgEnvio;
        private static System.Collections.Concurrent.ConcurrentDictionary<string, string> cdStatusDispositivos;
        private static Thread threadRecebimento;
        #endregion

        #region Métodos

        #region Básicos
        [SecurityPermission(SecurityAction.Demand)]
        public void LoopPrincipal()
        {
            try
            {
                // Inicia Filas de comunicação entre as threads
                cqMsgRecebidas = new System.Collections.Concurrent.ConcurrentQueue<MensagemDispositivo>();
                cqMsgEnvio = new System.Collections.Concurrent.ConcurrentQueue<MensagemDispositivo>();

                // Guarda status atual dos dispositivos conectados
                cdStatusDispositivos = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();

                // Ativa thread a parte para processar as requisições recebidas
                threadRecebimento = new Thread(LoopProcessamentoRequisicoesRecebidas);
                threadRecebimento.Start();

                #region Porta Serial - Comunicação com a rede de sensores
                // Xbee conectado ao servidor
                portaXbeeServidor = new SerialPort();
                ConfiguraPortaSerial(portaXbeeServidor);

                // Ativa porta
                portaXbeeServidor.Open();

                #endregion

                // Inicia WebService
                // Recebe as requisições do gerenciador para envio aos dispositivos
                Uri objUri = new Uri(_UriServidor);
                using (ServiceHost Host = new ServiceHost(this.GetType(), objUri))
                {
                    #region configura o WebService
                    // Habilita HTTP
                    BasicHttpBinding bndng = new BasicHttpBinding();
                    bndng.MaxReceivedMessageSize = 10485760;
                    bndng.ReceiveTimeout = new TimeSpan(0, 0, 10, 0, 0);

                    System.ServiceModel.Description.ServiceMetadataBehavior smb = new System.ServiceModel.Description.ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.HttpGetUrl = objUri;

                    Host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
                    Host.AddServiceEndpoint(typeof(IwsrvHomeOn), bndng, _UriServidor);
                    Host.Description.Behaviors.Add(smb);

                    // Ativa Service Host (Servidor WebService)
                    Host.Open();
                    #endregion

                    // Faz solicitação do status de todos os dispositivos conectados
                    portaXbeeServidor.Write(MensagemDispositivo.StatusTodosDipositivos(Service._configuradorGeral.IdServidor));
                    portaXbeeServidor.BaseStream.Flush();
                    System.Threading.Thread.Sleep(3000);

                    try
                    {
                        #region LOOP da Thread Principal
                        while (Service._bAtivo)
                        {
                            try
                            {
                                int iSleep = 200;
                                MensagemDispositivo objMsg;

                                // Processa mensagem de envio
                                if (cqMsgEnvio.TryDequeue(out objMsg))
                                {
                                    try
                                    {
                                        string sTextoEnvio = objMsg.TextoEnvio();
                                        portaXbeeServidor.Write(sTextoEnvio);
                                        portaXbeeServidor.BaseStream.Flush();
                                        iSleep = 1000;

                                        // Grava trace
                                        controlTrace.Insere(Biblioteca.Modelo.TraceComunicacao.ProcedenciaTrace.HomeOn, objMsg._Header.ID_Receiver, objMsg._Command.ID_Dispositivo, sTextoEnvio);
                                    }
                                    catch (Exception exc)
                                    {
                                        controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao escrever mensagem na porta serial.", exc);
                                    }
                                }

                                System.Threading.Thread.Sleep(iSleep);
                            }
                            catch (Exception exc)
                            {
                                controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro no Loop Principal do Serviço.", exc);
                                System.Threading.Thread.Sleep(1000 * 30);
                            }
                        }
                        #endregion
                    }
                    finally
                    {
                        // Fecha Webservice
                        if (Host != null && Host.State != CommunicationState.Closed && Host.State != CommunicationState.Closing)
                            Host.Close();
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
                // Fecha conexão serial
                if (portaXbeeServidor != null)
                {
                    if (portaXbeeServidor.IsOpen)
                        portaXbeeServidor.Close();

                    portaXbeeServidor.Dispose();
                }

                portaXbeeServidor = null;

                // Espera thread de Recebimento terminar
                Service._bAtivo = false;
                while (threadRecebimento.IsAlive)
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        private void LoopProcessamentoRequisicoesRecebidas()
        {
            #region LOOP da Thread de Recebimento
            // Enquanto Serviço estiver ativo
            while (Service._bAtivo)
            {
                MensagemDispositivo objMsg;

                try
                {
                    // Processa mensagem recebida
                    if (cqMsgRecebidas.TryDequeue(out objMsg))
                    {
                        // Chama método que avalia e grava informação recebida do controlador
                        if (objMsg._Header.ID_Receiver == Service._configuradorGeral.IdServidor)
                        {
                            string sIdDispositivo = objMsg._Command.ID_Dispositivo;
                            string sValueDispositivo = objMsg._Command.Disp_Value;

                            if (!string.IsNullOrEmpty(sIdDispositivo) && !string.IsNullOrEmpty(sValueDispositivo))
                            {
                                bool bAlterado = false;
                                string sValorAnterior = string.Empty;

                                if (!cdStatusDispositivos.ContainsKey(sIdDispositivo))
                                {
                                    cdStatusDispositivos.TryAdd(sIdDispositivo, sValueDispositivo);
                                    bAlterado = true;
                                }
                                else
                                {
                                    if (!cdStatusDispositivos[sIdDispositivo].Equals(sValueDispositivo))
                                    {
                                        sValorAnterior = cdStatusDispositivos[sIdDispositivo];
                                        cdStatusDispositivos[sIdDispositivo] = sValueDispositivo;
                                        bAlterado = true;
                                    }
                                }

                                if (bAlterado)
                                {
                                    // Log de mudança no Valor do dispositivo
                                    controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.RequisicaoRecebida,
                                        string.Format("Recebido alteração no valor do dispositivo.\r\nCódigo Dipositivo: {0}\r\nValor Anterior: {1}\r\nValor Atual: {2}",
                                        sIdDispositivo, sValorAnterior, sValueDispositivo));
                                }
                            }
                        }
                        else
                        {
                            controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.RequisicaoRecebida,
                                string.Format("Recebido mensagem para destino diferente do esperado. Receiver da mensagem: {0}. ExecucaoBackGround.LoopProcessamentoRequisicoesRecebidas", objMsg._Header.ID_Receiver));
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(200);
                    }
                }
                catch (Exception exc)
                {
                    controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro no loop de processamento das requisições recebidas. ExecucaoBackGround.LoopProcessamentoRequisicoesRecebidas", exc);
                    System.Threading.Thread.Sleep(1000 * 30);
                }
            }
            #endregion
        }
        #endregion

        #region Auxiliares
        private void ConfiguraPortaSerial(SerialPort portaSerial)
        {
            portaSerial.PortName = Service._configuradorGeral.SerialPorta;
            portaSerial.BaudRate = Service._configuradorGeral.SerialBaudRate;
            portaSerial.Parity = Service._configuradorGeral.SerialParidade;
            portaSerial.DataBits = Service._configuradorGeral.SerialDataBits;
            portaSerial.StopBits = Service._configuradorGeral.SerialStopBits;

            // Evento para processar as mensagens recebidas pela rede de sensores
            portaXbeeServidor.DataReceived += portaXbeeServidor_DataReceived;
        }

        private void RecebeMensagem()
        {
            // Enquanto houver texto pendente no buffer
            // Enfileira as mensagens para processamento
            while (portaXbeeServidor.IsOpen && portaXbeeServidor.BytesToRead > 0)
            {
                List<byte> resposta = new List<byte>();
                bool bFim = false;
                int carac = 0;
                int tempo = 0, espera = 20;
                int iTimeOut = 1000;

                // Lê stream até encontrar um Trailer + CR
                while (!bFim && tempo <= iTimeOut)
                {
                    try
                    {
                        carac = portaXbeeServidor.ReadByte();

                        if ((char)carac == MensagemDispositivo._FimMensagem)
                        {
                            resposta.Add((byte)carac);
                            bFim = true;
                            continue;
                        }

                        // Nada recebido, espera mais um pouco
                        if (carac == -1)
                        {
                            tempo += espera;
                            System.Threading.Thread.Sleep(espera);
                        }
                        else
                        {
                            tempo = 0;
                            resposta.Add((byte)carac);
                        }
                    }
                    catch (Exception exc)
                    {
                        controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro durante a leitura de dados da porta serial. (RecebeMensagem)", exc);
                        bFim = true;
                    }
                }

                string texto = Encoding.GetEncoding("ISO-8859-1").GetString(resposta.ToArray<byte>());

                try
                {
                    // Monta mensagem recebida
                    MensagemDispositivo msgRecebida = new MensagemDispositivo(texto);

                    // Grava Trace
                    controlTrace.Insere(Biblioteca.Modelo.TraceComunicacao.ProcedenciaTrace.Controlador, msgRecebida._Header.ID_Sender, msgRecebida._Command.ID_Dispositivo, texto);

                    // Adiciona na fila 
                    cqMsgRecebidas.Enqueue(msgRecebida);
                }
                catch (Exception exc)
                {
                    controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro,
                        string.Format("Erro ao instanciar objeto MensagemRecebida (portaXbeeServidor_DataReceived). Texto recebido: {0}", texto), exc);
                }
            }
        }
        #endregion

        #region Web Methods
        /// <summary>
        /// Método Web Service para colocar mensagens na fila de envio aos constroladores da rede
        /// </summary>
        public bool EnviaRequisicao(string CodigoControlador, string CodigoDispositivo, string NovoValor, out string Mensagem)
        {
            Mensagem = string.Empty;

            try
            {
                #region Monta Mensagem
                MensagemDispositivo objMensagem = new MensagemDispositivo();

                // Monta Header
                objMensagem._Header = new MensagemDispositivo.Header();
                objMensagem._Header.ID_Sender = Service._configuradorGeral.IdServidor;
                objMensagem._Header.ID_Receiver = CodigoControlador;

                // Monta Command
                objMensagem._Command = new MensagemDispositivo.Command();
                objMensagem._Command.ID_Dispositivo = CodigoDispositivo;
                objMensagem._Command.Disp_Value = NovoValor;
                #endregion

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

        /// <summary>
        /// Método Web Service para obter status de um dispositivo
        /// Caso não informado identificador do dispositivo, é retornado para o Piso respectivo
        /// </summary>
        public bool StatusDispositivos(string Piso, string IdentificadorDispositivo, out Dictionary<string, string> DispositivosStatus, out string Mensagem)
        {
            Mensagem = string.Empty;
            DispositivosStatus = new Dictionary<string, string>();

            try
            {
                // Recebido Identificador específico para o Dispositivo
                if (!string.IsNullOrEmpty(IdentificadorDispositivo))
                {
                    if (cdStatusDispositivos.ContainsKey(IdentificadorDispositivo))
                    {
                        DispositivosStatus.Add(IdentificadorDispositivo, cdStatusDispositivos[IdentificadorDispositivo]);
                    }

                    return true;
                }

                List<Biblioteca.Modelo.Dispositivo> lstDisp = null;

                using (Dados.GerenciadorDB mngDB = new Dados.GerenciadorDB(false))
                {
                    controlBase<Biblioteca.Modelo.Dispositivo> ctrlDisp = new controlBase<Biblioteca.Modelo.Dispositivo>();

                    if (string.IsNullOrEmpty(Piso))
                    {
                        lstDisp = ctrlDisp.LoadTodos(mngDB);
                    }
                    else
                    {
                        lstDisp = ctrlDisp.LoadFiltro(mngDB, l => l.Piso == Piso);
                    }
                }

                // Filtra dispositivos conectados
                var Disps = from Biblioteca.Modelo.Dispositivo objAux in lstDisp
                            where cdStatusDispositivos.ContainsKey(objAux.Codigo)
                            select objAux;

                DispositivosStatus = new Dictionary<string, string>(Disps.ToDictionary(i => i.Codigo, i => cdStatusDispositivos[i.Codigo]));
                return true;
            }
            catch (Exception exc)
            {
                try
                {
                    Mensagem = string.Format("Não foi possível verificar o(s) valor(es) do(s) dispositivo(s) solicitado(s). Erro: {0}", exc.Message);
                    controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, Mensagem, exc);
                }
                catch
                {
                    // Vish
                }

                return false;
            }
        }
        #endregion

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

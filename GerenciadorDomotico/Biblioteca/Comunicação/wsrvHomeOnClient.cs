using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Biblioteca.Modelo;

namespace Biblioteca.Comunicação
{
    #region Class Auxiliar Client do WebService (IwsrvHomeOn)
    public partial class wsrvHomeOnClient : System.ServiceModel.ClientBase<IwsrvHomeOn>, IwsrvHomeOn
    {
        #region Propriedades
        //private Biblioteca.Comunicação.wsrvHomeOnClient _wsrvClient = null;
        public static wsrvHomeOnClient getClient()
        {
            Uri WebSrvUri = new Uri(string.Format("{0}/{1}", _BaseAddress, _ApplicationName));

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.SendTimeout = new TimeSpan(0, 0, 0, 2, 0);
            binding.OpenTimeout = new TimeSpan(0, 0, 1, 0, 0);
            binding.CloseTimeout = new TimeSpan(0, 0, 1, 0, 0);

            wsrvHomeOnClient _wsrvClient = new wsrvHomeOnClient(binding, new System.ServiceModel.EndpointAddress(WebSrvUri));

            return _wsrvClient;
        }

        #region Estáticos
        private static ConfiguracaoGeral _conf = null;
        private static ConfiguracaoGeral Config
        {
            get
            {
                if (_conf == null)
                {
                    // Carrega configurador geral do sistema
                    List<Biblioteca.Modelo.ConfiguracaoGeral> lstConfig = null;
                    using (Dados.GerenciadorDB mngBD = new Dados.GerenciadorDB(false))
                    {
                        Biblioteca.Controle.controlBase<Biblioteca.Modelo.ConfiguracaoGeral> ctrlGeral = new Biblioteca.Controle.controlBase<Biblioteca.Modelo.ConfiguracaoGeral>();
                        lstConfig = ctrlGeral.LoadTodos(mngBD);
                    }

                    // Deve existir apenas um item
                    _conf = lstConfig.First();
                }

                return _conf;
            }
        }

        private static string _BaseAddress
        {
            get
            {
                return string.Format("http://{0}:{1}", Config.WsServidor, Config.WsPorta);
            }
        }

        /// <summary>
        /// Nome da aplicação do WebService
        /// </summary>
        private static string _ApplicationName
        {
            get
            {
                return "wsrvHomeOn.svc";
            }
        }
        #endregion

        #endregion

        #region Construtores
        private wsrvHomeOnClient() { }

        private wsrvHomeOnClient(string configurationName) :
            base(configurationName)
        { }

        private wsrvHomeOnClient(System.ServiceModel.Channels.Binding binding,
            System.ServiceModel.EndpointAddress address) :
            base(binding, address)
        { }
        #endregion

        #region Métodos
        public bool EnviaRequisicao(string CodigoControlador, string CodigoDispositivo, string NovoValor, out string Mensagem)
        {
            return base.Channel.EnviaRequisicao(CodigoControlador, CodigoDispositivo, NovoValor, out Mensagem);
        }

        public bool StatusDispositivos(string Piso, string IdentificadorDispositivo, out Dictionary<string, string> DispositivosStatus, out string Mensagem)
        {
            return base.Channel.StatusDispositivos(Piso, IdentificadorDispositivo, out DispositivosStatus, out Mensagem);
        }
        #endregion
    }
    #endregion
}

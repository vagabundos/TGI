using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Biblioteca.Comunicação
{
    #region Class Auxiliar Client do WebService (IwsrvHomeOn)
    public partial class wsrvHomeOnClient : System.ServiceModel.ClientBase<IwsrvHomeOn>, IwsrvHomeOn
    {
        #region Construtores
        public wsrvHomeOnClient() { }

        public wsrvHomeOnClient(string configurationName) :
            base(configurationName)
        { }

        public wsrvHomeOnClient(System.ServiceModel.Channels.Binding binding,
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

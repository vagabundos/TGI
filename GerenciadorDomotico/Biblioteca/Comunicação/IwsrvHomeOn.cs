using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Biblioteca.Comunicação
{
    /// <summary>
    ///  Interface Implementada para WebService de gerenciamento
    /// </summary>
    [ServiceContract]
    public interface IwsrvHomeOn
    {
        [OperationContract]
        bool EnviaRequisicao(string CodigoControlador, string CodigoDispositivo, string NovoValor, out string Mensagem);

        [OperationContract]
        bool StatusDispositivos(string Piso, string IdentificadorDispositivo, out Dictionary<string, string> DispositivosStatus, out string Mensagem);
    }
}

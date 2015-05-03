using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo;
using Dados;

namespace Biblioteca.Controle
{
    public class controlTrace : controlBase<TraceComunicacao>
    {
        #region Métodos

        #region Métodos Estáticos
        public static void Insere(TraceComunicacao.ProcedenciaTrace procedencia, string sControlador, string sDispositivo, string sMensagem)
        {
            using (GerenciadorDB mngBD = new GerenciadorDB(false))
            {
                Insere(procedencia, sControlador, sDispositivo, sMensagem, mngBD);
            }
        }

        public static void Insere(TraceComunicacao.ProcedenciaTrace procedencia, string sControlador, string sDispositivo, string sMensagem, GerenciadorDB mngBD)
        {
            try
            {
                TraceComunicacao objTrace = new TraceComunicacao();

                objTrace.Procedencia = procedencia;
                objTrace.Controlador = sControlador;
                objTrace.Dispositivo = sDispositivo;
                objTrace.Mensagem = sMensagem;
                objTrace.DataHoraOcorrencia = DateTime.Now;

                new controlTrace().Salva(objTrace, mngBD);
            }
            catch(Exception ex)
            {
                string sMsg = "Erro ao salvar uma ocorrência de Trace.\r\n";
                sMsg += "Procedência: " + Enum.GetName(typeof(TraceComunicacao.ProcedenciaTrace), procedencia) + "\r\n";
                sMsg += "Controlador: " + sControlador + "\r\n";
                sMsg += "Dispositivo: " + sDispositivo + "\r\n";
                sMsg += "Mensagem: " + sMensagem + ". ";
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, sMsg, ex);
            }
        }
        #endregion

        #endregion
    }
}

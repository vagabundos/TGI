using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo;
using Dados;

namespace Biblioteca.Controle
{
    public class controlLog : controlBase<Log>
    {
        #region Métodos

        #region Métodos Estáticos
        public static void Insere(Log.LogTipo tipo, string sDescricao, Exception exc = null)
        {
            using (GerenciadorDB mngBD = new GerenciadorDB(false))
            {
                Insere(tipo, sDescricao, exc, mngBD);
            }
        }

        public static void Insere(Log.LogTipo tipo, string sDescricao, Exception exc, GerenciadorDB mngBD)
        {
            try
            {
                Log objLog = new Log();

                objLog.DataHoraInclusao = DateTime.Now;
                objLog.Tipo = tipo;
                objLog.Descricao = sDescricao;

                // Se recebido exceção
                if (exc != null)
                    objLog.Descricao += "\r\n" + exc.ToString();

                new Controle.controlLog().Salva(objLog, mngBD);
            }
            catch
            {
                /// Se caiu aqui #$%#@
            }
        }
        #endregion

        #endregion
    }
}

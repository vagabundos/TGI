using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Log
    {
        #region Propriedades

        #endregion

        #region Enum
        public enum LogTipo
        {
            Erro = 1,
            Manutencao_Tabela = 2
        }
        #endregion

        #region Métodos
        public static void gravaLog(LogTipo enLogTipo, string sMensagem, Exception exc = null)
        {

        }
        #endregion
    }
}

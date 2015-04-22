using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml;
using Biblioteca;
using Dados;

namespace GerenciadorDomotico
{
    static class winMain
    {
        #region Main
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Faz um teste inicial de Conexão com o Banco de Dados
                if (!Util.TestaArquivoConexao())
                {
                    string sMessage = "Não foi possível Conectar ao banco de dados.\r\nVerifique se o Banco de Dados MySql está ativo ";
                    sMessage += "e se e arquivo 'conexoes.xml' está corretamente configurado na pasta principal de instalação do sistema.";
                    MessageBox.Show(sMessage,"Erro de Conexão ao Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Inicia a aplicação normalmente
                Application.Run(new winInicial());
            }
            catch (Exception exc)
            {
                string sMessage = string.Format("Erro inesperado causou a interrupção da aplicação.\r\nDetalhes:\r\n{0}", exc.Message + " " + exc.InnerException.Message);
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, sMessage, exc);
                MessageBox.Show(sMessage, "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

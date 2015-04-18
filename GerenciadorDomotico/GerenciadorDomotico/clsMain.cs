using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace GerenciadorDomotico
{
    static class winMain
    {
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
                Application.Run(new winInicial());
            }
            catch (Exception exc)
            {
                string sMessage = string.Format("Erro inesperado causou a interrupção da aplicação.\r\nDetalhes:\r\n{0}", exc.Message);
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, sMessage, exc);
                MessageBox.Show(sMessage, "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

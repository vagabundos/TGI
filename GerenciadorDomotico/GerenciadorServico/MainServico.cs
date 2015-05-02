using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;

namespace Servico
{
    static class MainServico
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #region Validações
            // Faz um teste inicial de Conexão com o Banco de Dados
            if (!Util.TestaArquivoConexao())
                return;

            // Carrega configurador geral do sistema
            List<Biblioteca.Modelo.ConfiguracaoGeral> lstConfig = null;
            using (Dados.GerenciadorDB mngBD = new Dados.GerenciadorDB(false))
            {
                Biblioteca.Controle.controlBase<Biblioteca.Modelo.ConfiguracaoGeral> ctrlGeral = new Biblioteca.Controle.controlBase<Biblioteca.Modelo.ConfiguracaoGeral>();
                lstConfig = ctrlGeral.LoadTodos(mngBD);
            }

            // Não configurado sistema
            if (lstConfig == null || lstConfig.Count == 0)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro,
                    "Erro ao iniciar o Serviço do Gerenciador. Não foi possível carregar os dados da tabela: ConfiguracaoGeral do sistema.");
                return;
            }

            // Deve existir apenas um item
            Service._configuradorGeral = lstConfig.First();
            #endregion

            #region Debug
            // Permite executar Serviço em Debug
            if (System.Diagnostics.Debugger.IsAttached)
            {
                RodaComoServico();
            }
            #endregion

            // Aqui é execução do Serviço
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service() 
            };

            ServiceBase.Run(ServicesToRun);
        }

        #region Métodos
        private static void RodaComoServico()
        {
            Service objServico = new Service();
            try
            {
                objServico.Inicia();

                // Coloca em Loop aqui para manter a outra thread no rodando
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
            finally
            {
                objServico.Fecha();
            }
        }
        #endregion
    }
}

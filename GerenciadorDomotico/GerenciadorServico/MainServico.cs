using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    static class MainServico
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // Permite executar Serviço em Debug
            if (System.Diagnostics.Debugger.IsAttached)
            {
                RodaComoServico();
            }

            // Aqui é execução do Serviço
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service() 
            };
            ServiceBase.Run(ServicesToRun);
        }

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
    }
}

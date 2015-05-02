using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Biblioteca.Controle;

namespace Servico
{
    public partial class Service : ServiceBase
    {
        #region Construtor
        public Service()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        protected override void OnStart(string[] args)
        {
            Inicia();
        }

        protected override void OnStop()
        {
            Fecha();
        }

        protected override void OnShutdown()
        {
            Fecha();
            base.OnShutdown();
        }
        #endregion

        #region Propriedades
        public static bool _bAtivo;
        public static Biblioteca.Modelo.ConfiguracaoGeral _configuradorGeral;
        private Thread threadPrincipal;
        private ExecucaoBackground objBackGrd;
        #endregion

        #region Métodos
        public void Inicia()
        {
            // Marca como ativo
            _bAtivo = true;
            objBackGrd = new ExecucaoBackground();

            // Inicia thread Principal
            threadPrincipal = new Thread(new ThreadStart(objBackGrd.LoopPrincipal));
            threadPrincipal.Start();
        }

        public void Fecha()
        {
            _bAtivo = false;
            int espera = 0;

            try
            {
                // se thread nao iniciada sai
                if (threadPrincipal.ThreadState == System.Threading.ThreadState.Unstarted)
                {
                    return;
                }

                while (threadPrincipal.ThreadState != System.Threading.ThreadState.Stopped)
                {
                    Thread.Sleep(1000);
                    espera++;

                    // Espera até 40 segundos para parar
                    if (espera > 40)
                    {
                        threadPrincipal.Abort();
                        threadPrincipal = null;
                    }
                }
            }
            catch (Exception exc)
            {
                controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, string.Format("Erro ao parar o serviço. Detalhes:\r\n{0}", exc.Message), exc);
            }
        }
        #endregion
    }
}

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

namespace GerenciadorServico
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
        bool _bAtivo;
        Thread threadPrincipal;
        #endregion

        #region Métodos
        private void Inicia()
        {
            _bAtivo = true;
            threadPrincipal = new Thread(new ThreadStart(LoopPrincipal));
            threadPrincipal.Start();
        }

        private void Fecha()
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
                    if (espera > 40)
                    {
                        threadPrincipal.Abort();
                        threadPrincipal = null;
                    }
                }
            }
            catch (Exception exc)
            {
                // grava logs
            }
        }

        // Loop do serviço
        private void LoopPrincipal()
        {
            while (_bAtivo)
            {

            }
        }
        #endregion
    }
}

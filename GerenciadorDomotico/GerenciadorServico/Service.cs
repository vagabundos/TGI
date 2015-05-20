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
using System.IO;

namespace Servico
{
    public partial class Service : ServiceBase
    {
        #region Propriedades
        public static bool _bAtivo;
        public static Biblioteca.Modelo.ConfiguracaoGeral _configuradorGeral;
        private Thread threadPrincipal;
        private ExecucaoBackground objBackGrd;
        
        FileStream fs;
        StreamWriter w;
        bool logar = false;
        bool fechar = false;
        #endregion

        #region Construtor
        public Service(bool loga)
        {
            if (loga)
            {
                logar = true;
                fs = new FileStream("C:\\temp\\log.txt", FileMode.OpenOrCreate, FileAccess.Write);
                w = new StreamWriter(fs);
                w.BaseStream.Seek(0, SeekOrigin.End);
                Loga("Construtor Servico");
            }

            InitializeComponent();
        }
        #endregion

        #region Eventos
		protected override void OnStart(string[] args)
		{
			Loga("OnStart");
			Inicia();
			Loga("Fim do OnStart");
		}

		protected override void OnStop()
		{
			Loga("OnStop");
			Fecha();
			Loga("Fim do OnStop");
			
		}

		protected override void OnShutdown()
		{
			Loga("OnShutdown");
			Fecha();
			Loga("OnShudown - Fecha");
			base.OnShutdown();
			Loga("base.OnShutdown");
		}
        #endregion

        #region Métodos
        /// <summary>
        /// Método que grava o log
        /// </summary>
        public void Loga(string logMessage)
        {
            if (logar)
            {
                w.Write("Hora/Data");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine(":{0}", logMessage);
                w.WriteLine("-------------------------------");
                w.Flush();
            }
        }

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;
using Biblioteca.Controle;
using Biblioteca.Modelo;
using Dados;

namespace GerenciadorDomotico.Dispositivos
{
    public partial class ctlDispositivoBase : UserControl
    {
        #region Propriedades
        private Point MouseDownLocation;
        protected controlBase<Dispositivo> controleTela = new controlBase<Dispositivo>();
        protected Dispositivo objDisp;

        #region Web Service

        #region Estáticos
        private static ConfiguracaoGeral _conf = null;
        private static ConfiguracaoGeral Config
        {
            get
            {
                if (_conf == null)
                {
                    // Carrega configurador geral do sistema
                    List<Biblioteca.Modelo.ConfiguracaoGeral> lstConfig = null;
                    using (Dados.GerenciadorDB mngBD = new Dados.GerenciadorDB(false))
                    {
                        Biblioteca.Controle.controlBase<Biblioteca.Modelo.ConfiguracaoGeral> ctrlGeral = new Biblioteca.Controle.controlBase<Biblioteca.Modelo.ConfiguracaoGeral>();
                        lstConfig = ctrlGeral.LoadTodos(mngBD);
                    }

                    // Deve existir apenas um item
                    _conf = lstConfig.First();
                }

                return _conf;
            }
        }

        private static string _BaseAddress
        {
            get
            {
                return string.Format("http://{0}:{1}", Config.WsServidor, Config.WsPorta);
            }
        }

        /// <summary>
        /// Nome da aplicação do WebService
        /// </summary>
        private static string _ApplicationName
        {
            get
            {
                return "wsrvHomeOn.svc";
            }
        }

        private static Biblioteca.Comunicação.wsrvHomeOnClient _wsrvClient = null;
        private static Biblioteca.Comunicação.wsrvHomeOnClient WsrvClient
        {
            get
            {
                if (_wsrvClient == null)
                {
                    Uri WebSrvUri = new Uri(string.Format("{0}/{1}", _BaseAddress, _ApplicationName));

                    System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
                    binding.SendTimeout = new TimeSpan(0, 0, 10, 0, 0);
                    binding.OpenTimeout = new TimeSpan(0, 0, 10, 0, 0);
                    binding.CloseTimeout = new TimeSpan(0, 0, 10, 0, 0);

                    _wsrvClient = new Biblioteca.Comunicação.wsrvHomeOnClient(binding, new System.ServiceModel.EndpointAddress(WebSrvUri));
                }

                return _wsrvClient;
            }
        }
        #endregion

        #endregion

        #endregion

        #region Construtores
        /// <summary>
        /// Trata como um dispositivo genérico
        /// </summary>
        public ctlDispositivoBase()
        {
            InitializeComponent();

            ExibeControleDispositivo();
        }
        /// <summary>
        /// Trata já o dispositivo definido
        /// </summary>
        public ctlDispositivoBase(Dispositivo objDispModelo)
        {
            InitializeComponent();
            objDisp = objDispModelo;

            ExibeControleDispositivo();
        }
        #endregion

        #region Métodos

        #region Métodos Gerais
        /// <summary>
        /// Coloca o dispositivo sobre a coordenada relativa referente a posição recebida para a imagem
        /// </summary>
        public void setPosicaoDispositivoNaImagem(int posicaoX, int posicaoY, PictureBox imgContainer)
        {
            this.Location = Util.TranslateControlPositionZoom(posicaoX, posicaoY, imgContainer);
            return;
        }

        /// <summary>
        /// Retorna objeto Point com posição do dispositivo na imagem (em tamanho real)
        /// </summary>
        public Point getPosicaoDispositivoNaImagem(PictureBox imgContainer)
        {
            return Util.TranslateZoomControlPosition(imgContainer, this.Location);
        }

        public Point GetImageCenter(Point ptBorda)
        {
            Point ptCentro = new Point();
            ptCentro.X = (ptBorda.X + (ptBorda.X + Size.Width)) / 2;
            ptCentro.Y = (ptBorda.Y + (ptBorda.Y + Size.Height)) / 2;

            return ptCentro;
        }

        public void PermiteArrastar(bool bPermite)
        {
            this.pnlDispositivo.MouseMove -= new MouseEventHandler(pnlDispositivo_MouseMove);
            this.pnlDispositivo.MouseDown -= new MouseEventHandler(pnlDispositivo_MouseDown);

            if (bPermite)
            {
                this.pnlDispositivo.MouseMove += new MouseEventHandler(pnlDispositivo_MouseMove);
                this.pnlDispositivo.MouseDown += new MouseEventHandler(pnlDispositivo_MouseDown);
            }
        }

        public void SetImageButton(Image imgDisp, float fTransparencia = 1)
        {
            if (imgDisp != null)
            {
                pnlDispositivo.BackColor = Color.Empty;
                btnDisp.BackgroundImage = Util.SetTransparenciaImagem(imgDisp, fTransparencia);
                btnDisp.Visible = true;
                btnDisp.BackColor = Color.Transparent;
                btnDisp.ForeColor = Color.Transparent;
                btnDisp.BringToFront();
            }
        }

        /// <summary>
        /// Chama utilitário que altera a transparencia da imagem do botão
        /// </summary>
        public void SetTransparenciaImagem(float fTransparencia)
        {
            btnDisp.BackgroundImage = Util.SetTransparenciaImagem(btnDisp.BackgroundImage, fTransparencia);
        }
        #endregion

        #region Métodos Virtual
        protected virtual void ExibeControleDispositivo()
        {
            Image imgDisp = imgList.Images["Generico"];

            // Insere a imagem no botão, se houver
            SetImageButton(imgDisp);

            //pnlDispositivo.BackColor = Color.Empty;
            //pnlDispositivo.BackgroundImage = imgDisp;

            // Como o tipo do dispositivo não foi especificado, não permite acionar o botão
            btnDisp.Enabled = false;
        }

        /// <summary>
        /// Obrigatório Sobrescrever
        /// </summary>
        protected virtual void AcionaBotaoDisp()
        {
            throw new NotImplementedException();
        }

        #region Métodos de interação com o Web Service (SERVIÇO)
        /// <summary>
        /// Faz envio de requisição para a aplicação no serviço solicitando alteração no Status do Dispositivo
        /// </summary>
        protected virtual void Envia(string sValorNovo)
        {
            try
            {
                string sMessage;
                Biblioteca.Comunicação.wsrvHomeOnClient wsClient = WsrvClient;

                if (!wsClient.EnviaRequisicao(this.objDisp.Controlador, this.objDisp.Codigo, sValorNovo, out sMessage))
                {
                    throw new Exception(sMessage);
                }
            }
            catch (Exception ex)
            {
                string sMensagem = string.Format("Não foi possível requisitar a alteração no Status do Dispositivo: '{0}'.\r\nDetalhes: {1}", objDisp.Codigo, ex.Message);
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, sMensagem, ex);
                MessageBox.Show(sMensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Faz chamada ao Web Service do Serviço para recuperar valor atual do Dispositivo
        /// </summary>
        protected virtual string getValor()
        {
            string sMessage;
            string sValor = null;
            Dictionary<string, string> dicDisp;

            try
            {
                Biblioteca.Comunicação.wsrvHomeOnClient wsClient = WsrvClient;

                // Busca valor atualizado no Web Service
                if (!wsClient.StatusDispositivos(this.objDisp.Piso, this.objDisp.Codigo, out dicDisp, out sMessage))
                {
                    throw new Exception(sMessage);
                }
                
                if (dicDisp.ContainsKey(objDisp.Codigo))
                    sValor = dicDisp[objDisp.Codigo];
            }
            catch (Exception exc)
            {
                string sMensagem = string.Format("Não foi possível buscar o Status atual do Dispositivo: '{0}'.\r\nDetalhes: {1}", objDisp.Codigo, exc.Message);
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, sMensagem, exc);
                MessageBox.Show(sMensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sValor;
        }
        #endregion

        #endregion

        #endregion

        #region Eventos
        private void pnlDispositivo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        private void pnlDispositivo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void btnDisp_Click(object sender, EventArgs e)
        {
            AcionaBotaoDisp();
        }
        #endregion
    }
}

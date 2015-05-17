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
        protected string sValorDisp = string.Empty;
        protected int iIntervalo = 1000;
        protected float fTransparencia = 1f;
        protected Biblioteca.Comunicação.wsrvHomeOnClient wsClient;

        #endregion

        #region Construtores
        /// <summary>
        /// Trata como um dispositivo genérico
        /// </summary>
        public ctlDispositivoBase()
        {
            InitializeComponent();

            // Insere imagem default
            Image imgDisp = imgList.Images["Generico"];
            SetImageButton(imgDisp);

            // Como o tipo do dispositivo não foi especificado, não permite acionar o botão
            btnDisp.Enabled = false;
        }

        /// <summary>
        /// Trata já o dispositivo definido
        /// </summary>
        public ctlDispositivoBase(Dispositivo objDispModelo)
        {
            InitializeComponent();
            wsClient = Biblioteca.Comunicação.wsrvHomeOnClient.getClient();
            objDisp = objDispModelo;
            GetStatusDispositivo();
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

        public void SetImageButton(Image imgDisp)
        {
            if (imgDisp != null)
            {
                btnDisp.BackgroundImage = Util.SetTransparenciaImagem(imgDisp, this.fTransparencia);
                SetButtonVisible(true);
            }
        }

        /// <summary>
        /// Permite o botão principal do controle do dispositivo ficar visivel ou não
        /// </summary>
        public void SetButtonVisible(bool bVisivel)
        {
            pnlDispositivo.BackColor = Color.Empty;
            btnDisp.Visible = bVisivel;
            btnDisp.BackColor = Color.Transparent;
            btnDisp.ForeColor = Color.Transparent;
            btnDisp.BringToFront();
        }

        /// <summary>
        /// Chama utilitário que altera a transparencia da imagem do botão
        /// </summary>
        public void SetTransparenciaImagem(float fTransparencia)
        {
            btnDisp.BackgroundImage = Util.SetTransparenciaImagem(btnDisp.BackgroundImage, fTransparencia);
        }

        /// <summary>
        /// Mostra o dispositivo como desconectado após 
        /// </summary>
        public void SetDisconnected()
        {
            Image imgDisconnected = imgList.Images["Desconectado"];
            this.fTransparencia = 0.5f;
            SetImageButton(imgDisconnected);
            btnDisp.Enabled = false;
            this.iIntervalo = 1000 * 5;
            timerDispositivo.Interval = this.iIntervalo;
            sValorDisp = string.Empty;
        }

        /// <summary>
        /// Ativa o timer que dispara o evento para atualizar o status do dispositivo
        /// </summary>
        public void AtivaTimerExibicao(bool bAtiva, int iIntervalo)
        {
            // Para o timer, caso tenha sido desativado
            if (!bAtiva)
            {
                timerDispositivo.Stop();
                timerDispositivo.Enabled = false;
                return;
            }

            // Seta intervalo padrão para atualizar o status do dispositivo
            this.iIntervalo = iIntervalo;
            timerDispositivo.Interval = this.iIntervalo;

            // Ativa o timer
            timerDispositivo.Enabled = true;
            timerDispositivo.Start();
        }
        #endregion

        #region Métodos Virtual
        protected virtual void GetStatusDispositivo()
        {
            string sValorDispAnt = sValorDisp;

            // Aplica o valor em outra variável, para não chamar o Web Service mais de uma vez
            sValorDisp = getValor();

            if (sValorDisp != sValorDispAnt)
            {
                if (string.IsNullOrEmpty(sValorDisp))
                {
                    SetDisconnected();
                    return;
                }

                if (timerDispositivo.Interval != iIntervalo)
                {
                    timerDispositivo.Interval = iIntervalo;
                }

                // Mudança no valor do dispositivo
                MudaStatus();
            }
        }

        /// <summary>
        /// Obrigatório Override
        /// </summary>
        protected virtual void MudaStatus()
        {
            throw new NotImplementedException();
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

                if (!wsClient.EnviaRequisicao(this.objDisp.Controlador, this.objDisp.Codigo, sValorNovo, out sMessage))
                {
                    throw new Exception(sMessage);
                }

                // Muda para disable
                this.Enabled = false;
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
            this.Enabled = false;
            if (this.btnDisp.BackgroundImage != null)
            {
                this.fTransparencia = 0.5f;
                SetImageButton(this.btnDisp.BackgroundImage);
            }

            // Desativa botão por alguns instantes
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1500);
                btnDisp.Invoke(new Action(() =>
                {
                    this.Enabled = true;
                    if (this.btnDisp.BackgroundImage != null)
                    {
                        this.fTransparencia = 100f;
                        SetImageButton(this.btnDisp.BackgroundImage);
                    }
                }));
            });

            // Envia mensagem de requisição ao Controlador
            AcionaBotaoDisp();
        }

        private void timerDispositivo_Tick(object sender, EventArgs e)
        {
            GetStatusDispositivo();
        }
        #endregion

        //private void btnDisp_Paint(object sender, PaintEventArgs e)
        //{
        //    // Create a Bitmap object from an image file.
        //    Image myImg;
        //    Bitmap myBitmap;
        //    if (btnDisp.BackgroundImage != null)
        //    {
        //        btnDisp.BackColor = Color.DarkGreen;
        //        try
        //        {
        //            myImg = btnDisp.BackgroundImage;
        //            myBitmap = new Bitmap(myImg);

        //            // Get the color of a background pixel.
        //            Color backColor = myBitmap.GetPixel(0, 0); // GetPixel(1, 1); 
        //            Color backColorGray = Color.Gray;
        //            Color backColorGrayLight = Color.LightGray;
        //            Color backColorWhiteSmoke = Color.WhiteSmoke;
        //            Color backColorWhite = Color.White;
        //            Color backColorWheat = Color.Wheat;

        //            // Make backColor transparent for myBitmap.
        //            myBitmap.MakeTransparent(backColor);
        //            // OPTIONALLY, you may make any other "suspicious" back color transparent (usually gray, light gray or whitesmoke)
        //            myBitmap.MakeTransparent(backColorGray);
        //            myBitmap.MakeTransparent(backColorGrayLight);
        //            myBitmap.MakeTransparent(backColorWhiteSmoke);

        //            // Draw myBitmap to the screen.
        //            e.Graphics.DrawImage(myBitmap, 0, 0, btnDisp.Width - 5, btnDisp.Height - 5); //myBitmap.Width, myBitmap.Height);
        //        }
        //        catch
        //        {
        //            string t = "ss";
        //            //try { pictureBox1.Image = Util.byteArrayToImage( cls_convertImagesByte.GetImageFromByte(newImg); }
        //            //catch { } //must do something
        //        }
        //    }
        //}
    }
}

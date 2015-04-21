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
using Biblioteca.Modelo;

namespace GerenciadorDomotico.Dispositivos
{
    public partial class ctlDispositivoBase : UserControl
    {
        #region Construtores
        public ctlDispositivoBase()
        {
            InitializeComponent();
        }
        public ctlDispositivoBase(Dispositivo objDispModelo)
        {
            InitializeComponent();
            Image img = null;

            switch (objDispModelo.Tipo)
            {
                case Dispositivo.TipoSensor.Iluminacao:
                    img = imgList.Images[objDispModelo.Tipo.ToString() + "_ON"];
                    break;
            }

            if (img != null)
            {
                pnlDispositivo.BackColor = Color.Empty;
                pnlDispositivo.BackgroundImage = img;
                btnDisp.Visible = true;
                btnDisp.BackColor = Color.Transparent;
                btnDisp.ForeColor = Color.Transparent;
                btnDisp.BringToFront();
            }
        }
        #endregion

        #region Propriedades
        private Point MouseDownLocation;
        #endregion

        #region Métodos
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

        }

        private void btnDisp_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}

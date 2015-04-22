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
        private controlBase<Dispositivo> controleTela = new controlBase<Dispositivo>();
        private Point MouseDownLocation;
        private Dispositivo objDisp;
        private Image imgDisp;
        #endregion

        #region Construtores
        public ctlDispositivoBase()
        {
            InitializeComponent();
        }
        public ctlDispositivoBase(Dispositivo objDispModelo)
        {
            InitializeComponent();
            objDisp = objDispModelo;

            ExibeControleDispositivo();
        }
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

        private void ExibeControleDispositivo()
        {
            // Realiza a ação de acordo com o tipo do dispositivo
            switch (objDisp.Tipo)
            {
                case Dispositivo.TipoSensor.Iluminacao:
                    string sLampada = objDisp.Valor.Equals("1",StringComparison.CurrentCultureIgnoreCase) ? "ON" : "OFF";
                    imgDisp = imgList.Images[objDisp.Tipo.ToString() + "_" + sLampada];
                    break;

                default:
                    break;
            }

            // Insere a imagem no botão, se houver
            if (imgDisp != null)
            {
                pnlDispositivo.BackColor = Color.Empty;
                btnDisp.BackgroundImage = imgDisp;
                btnDisp.Visible = true;
                btnDisp.BackColor = Color.Transparent;
                btnDisp.ForeColor = Color.Transparent;
                btnDisp.BringToFront();
            }
        }

        private void Envia()
        {
            // To-Do: Envia comando ao Controlador. Por enquanto, simulamos alterando o valor no banco, apenas


            // Se a comunicação deu certo, salva o valor recebido do Controlador
            try
            {
                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    controleTela.Salva(objDisp, mngBD);
                }
            }
            catch(Exception ex)
            {
                string sMensagem = "Não foi possível salvar os dados alterados ao acionar o dispositivo '" + objDisp.Codigo + "'.";
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao salvar dispositivo. ", ex);
                MessageBox.Show(sMensagem, "Erro ao Salvar Dados do Dispositivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Altera o valor ON/OFF da Lampada
            if (objDisp.Valor.Equals("1")) 
                objDisp.Valor = "0";
            else
                objDisp.Valor = "1";

            // Envia mensagem de requisição ao Controlador
            Envia();

            // Atualiza exibição do controle do Dispositivo
            ExibeControleDispositivo();
        }

        private void btnDisp_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}

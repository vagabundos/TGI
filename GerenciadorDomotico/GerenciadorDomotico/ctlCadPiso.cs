using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Modelo;
using Biblioteca.Controle;
using Dados;

namespace GerenciadorDomotico
{
    public partial class ctlCadPiso : ctlCadBase
    {
        #region Propriedades
        controlBase<Piso> controleTela = new controlBase<Piso>();
        #endregion

        #region Construtores
        public ctlCadPiso()
        {
            InitializeComponent();
            
            imgPlantaPiso.SizeMode = PictureBoxSizeMode.Zoom;

            btnApaga.Visible = true;
            btnAtivaInativa.Visible = true;
            btnCancela.Visible = true;
            btnEdita.Visible = true;
            btnFecha.Visible = true;
            btnNovo.Visible = true;
            btnSalva.Visible = true;

            ConfiguraGrid();
            CarregaGrid();

            AtualizaTela = StatusTela.View;
        }
        #endregion

        #region Métodos
        protected override ctlCadBase.StatusTela AtualizaTela
        {
            get
            {
                return base.AtualizaTela;
            }
            set
            {
                base.AtualizaTela = value;

                // Sai se ainda não criou os objetos
                if (txtCodigo == null)
                    return;

                switch(this.AtualizaTela)
                {
                    case StatusTela.New:
                        txtCodigo.Enabled = true;
                        txtDescricao.Enabled = true;
                        btnDiretorio.Enabled = true;
                        grdPiso.Enabled = false;
                        break;

                    case StatusTela.Edit:
                        txtCodigo.Enabled = false;
                        txtDescricao.Enabled = true;
                        btnDiretorio.Enabled = true;
                        grdPiso.Enabled = false;
                        break;

                    case StatusTela.View:
                        txtCodigo.Enabled = false;
                        txtDescricao.Enabled = false;
                        btnDiretorio.Enabled = false;
                        grdPiso.Enabled = true;
                        break;

                    default:
                        break;
                }
            }
        }

        protected override void Novo()
        {
            base.Novo();
            Limpa();
            txtCodigo.Focus();
        }

        protected override void Edita()
        {
            base.Edita();
            txtDescricao.Focus();
        }

        protected override void Salva()
        {
            try
            {
                using (Dados.GerenciadorDB mngBD = new Dados.GerenciadorDB(false))
                {
                    Piso objPiso = null;

                    if (AtualizaTela == StatusTela.New)
                    {
                        objPiso = new Biblioteca.Modelo.Piso();
                    }
                    else if (AtualizaTela == StatusTela.Edit)
                    {
                        // Se nenhum piso do grid estiver selecionado, limpa a tela e sai
                        if (grdPiso.CurrentRow == null)
                        {
                            Limpa();
                            return;
                        }

                        objPiso = (Piso)grdPiso.CurrentRow.DataBoundItem;
                    }

                    if (objPiso != null)
                    {
                        objPiso.Codigo = txtCodigo.Text;
                        objPiso.Descricao = txtDescricao.Text;
                        objPiso.Imagem = Biblioteca.Util.ImageToByteArray(imgPlantaPiso.Image);
                        controleTela.Salva(objPiso, mngBD);
                    }
                }
            }
            catch (Exception exc)
            {

            }
            finally
            {
                base.Salva();
                CarregaGrid();
            }
        }

        protected override void Apaga()
        {
            try
            {
                // Sai se nenhum piso do grid estiver selecionado
                if (grdPiso.CurrentRow == null)
                {
                    Limpa();
                    return;
                }

                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    Piso objPisoSelecionado = (Piso)grdPiso.CurrentRow.DataBoundItem;
                    controleTela.Apaga(objPisoSelecionado, mngBD);
                }
            }
            catch (Exception exc)
            {
                // Exibir mensagem (tratada) ao usuário e gerar log
            }
            finally
            {
                base.Apaga();
                CarregaGrid();
            }
        }

        private void CarregaGrid()
        {
            using (GerenciadorDB mngBD = new GerenciadorDB(false))
            {
                BindingList<Piso> bList = new BindingList<Piso>(controleTela.LoadTodos(mngBD));
                this.grdPiso.DataSource = bList;
            }

            grdPiso.AutoResizeColumns();
        }

        private void ConfiguraGrid()
        {
            ConfiguraColunas(this.grdPiso, typeof(Piso));
        }

        private void Limpa()
        {
            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtDiretorio.Text = string.Empty;
            imgPlantaPiso.Image = null;
        }
        #endregion

        #region Eventos
        private void btnDiretorio_Click(object sender, EventArgs e)
        {
            string sArquivo = string.Empty;

            // Abre janela para selecionar uma imagem
            OpenFileDialog ofdImagem = new OpenFileDialog();
            ofdImagem.Filter = "JPEG (*.jpg)|*.jpg|TIFF (*.tif)|*.tif|PNG (*.png)|*.png|BITMAP (*.bmp)|*.bmp";
            ofdImagem.Title = "Selecione a imagem da planta do piso desejado";

            if (ofdImagem.ShowDialog() == DialogResult.OK)
            {
                sArquivo = ofdImagem.FileName;
                txtDiretorio.Text = sArquivo;
                // Carrega Imagem
                imgPlantaPiso.Image = Image.FromFile(sArquivo);
            }
        }

        private void grdPiso_SelectionChanged(object sender, EventArgs e)
        {
            // Se nenhum piso do grid estiver selecionado, limpa a tela e sai
            if (grdPiso.CurrentRow == null)
            {
                Limpa();
                return;
            }

            Piso objPisoSelecionado = (Piso)grdPiso.CurrentRow.DataBoundItem;

            txtCodigo.Text = objPisoSelecionado.Codigo;
            txtDescricao.Text = objPisoSelecionado.Descricao;
            imgPlantaPiso.Image = Biblioteca.Util.byteArrayToImage(objPisoSelecionado.Imagem);
        }
        #endregion
    }
}

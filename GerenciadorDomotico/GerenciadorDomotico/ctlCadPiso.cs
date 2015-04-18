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

namespace GerenciadorDomotico
{
    public partial class ctlCadPiso : ctlCadBase
    {
        #region Propriedades

        DataTable dttPisos = new DataTable();

        #endregion

        #region Construtores
        public ctlCadPiso()
        {
            InitializeComponent();

            btnApaga.Visible = true;
            btnAtivaInativa.Visible = true;
            btnCancela.Visible = true;
            btnEdita.Visible = true;
            btnFecha.Visible = true;
            btnNovo.Visible = true;
            btnSalva.Visible = true;

            dttPisos.Columns.Add("Codigo");
            dttPisos.Columns.Add("Descricao");

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
            // Converte a imagem para o tipo Byte[]
            //byte[] byteImage = Util.ImageToByteArray(imgPlantaPiso.Image);

            // Temporariamente: Seta dados que serão salvos direto no Grid
            if (AtualizaTela == StatusTela.New)
            {
                dttPisos.Rows.Add(new object[] { txtCodigo.Text, txtDescricao.Text });
            }

            if (AtualizaTela == StatusTela.Edit)
            {
                // Se nenhum piso do grid estiver selecionado, limpa a tela e sai
                if (grdPiso.CurrentRow == null)
                {
                    Limpa();
                    return;
                }
                int iRow = grdPiso.CurrentRow.Index;
                dttPisos.Rows[iRow].SetField("Descricao", txtDescricao.Text);
            }

            CarregaGrid();

            base.Salva();
        }

        protected override void Apaga()
        {
            base.Apaga();

            // Sai se nenhum piso do grid estiver selecionado
            if (grdPiso.CurrentRow == null)
            {
                Limpa();
                return;
            }

            int iRow = grdPiso.CurrentRow.Index;
            dttPisos.Rows[iRow].Delete();

            // To-Do: Excluir Piso do Banco de Dados
        }

        private void CarregaGrid()
        {
            // To-Do: Carrega Pisos do Banco de Dados

            grdPiso.DataSource = dttPisos;
        }

        private void ConfiguraGrid()
        {
            // Tamanho
            grdPiso.RowTemplate.Height = 17;

            // Cria colunas do Grid (Nunca setar as colunas no arquivo .Designer.cs!!)
            grdPiso.Columns.Add("Codigo", "Código");
            grdPiso.Columns.Add("Descricao", "Descrição");

            // Seta 'Codigos Internos' das colunas do digníssimo Grid (pois é...)
            grdPiso.Columns["Codigo"].DataPropertyName = "Codigo";
            grdPiso.Columns["Descricao"].DataPropertyName = "Descricao";

            // Respectivo 'ExtendLastCol'
            grdPiso.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

                // Carrega Imagem e ajusta seu tamanho para caber na tela
                imgPlantaPiso.Image = Image.FromFile(sArquivo);
                imgPlantaPiso.SizeMode = PictureBoxSizeMode.Zoom;
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

            int iRow = grdPiso.CurrentRow.Index;

            txtCodigo.Text = grdPiso["Codigo", iRow].Value.ToString();
            txtDescricao.Text = grdPiso["Descricao", iRow].Value.ToString();
        }
        #endregion
    }
}

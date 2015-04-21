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
            // Sai se não tem nenhum piso selecionado
            if (grdPiso.CurrentRow == null)
            {
                MessageBox.Show("Não há nenhum piso selecionado. Selecione um piso para poder editá-lo.", "Atenção!", MessageBoxButtons.OK);
                return;
            }

            base.Edita();
            txtDescricao.Focus();
        }

        protected override void Salva()
        {
            // Consiste dados a serem salvos
            string sMensagem = string.Empty;

            if (!Valida(out sMensagem))
            {
                MessageBox.Show(sMensagem, "O Piso não pôde ser salvo", MessageBoxButtons.OK);
                return;
            }

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

                        string sDetalhe = "Piso '" + objPiso.Codigo + "' salvo com sucesso.";
                        Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.ManutencaoTabelaPisos, sDetalhe);
                    }
                }
            }
            catch (Exception exc)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao salvar piso. ", exc);
                MessageBox.Show("Erro ao Salvar Piso. Visualizar a tabela de logs para mais detalhes.", "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Não há nenhum piso selecionado. Selecione um piso para poder apagá-lo.", "Atenção!", MessageBoxButtons.OK);
                    Limpa();
                    return;
                }

                // Janela de confirmação
                DialogResult drApaga = MessageBox.Show("Tem certeza que deseja apagar o piso selecionado?","Apagar Piso", MessageBoxButtons.YesNo);

                if (drApaga == DialogResult.Yes)
                {
                    using (GerenciadorDB mngBD = new GerenciadorDB(false))
                    {
                        Piso objPisoSelecionado = (Piso)grdPiso.CurrentRow.DataBoundItem;
                        controleTela.Apaga(objPisoSelecionado, mngBD);

                        string sDetalhe = "Piso '" + objPisoSelecionado.Codigo + "' apagado com sucesso.";
                        Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.ManutencaoTabelaPisos, sDetalhe);
                    }
                }
            }
            catch (Exception exc)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao apagar piso. ", exc);
                MessageBox.Show("Erro ao Apagar Piso. Visualizar a tabela de logs para mais detalhes.", "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                base.Apaga();
                CarregaGrid();
            }
        }

        protected override void Cancela()
        {
            base.Cancela();
            CarregaPisoSelecionado();
        }

        private bool Valida(out string sMensagem)
        {
            sMensagem = string.Empty;

            if (txtCodigo.Text == string.Empty)
            {
                sMensagem = "O código do Piso não pode ser nulo. \r\n";
                return false;
            }

            if (imgPlantaPiso.Image == null)
            {
                sMensagem = "Um piso não pode ser salvo sem a planta do piso relacionado. \r\n";
                return false;
            }
               
            return true;
        }

        private void CarregaGrid()
        {
            try
            {
                // Desativa evento para evitar erros
                grdPiso.SelectionChanged -= grdPiso_SelectionChanged;

                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    BindingList<Piso> bList = new BindingList<Piso>(controleTela.LoadTodos(mngBD));
                    this.grdPiso.DataSource = bList;
                }

                // Limpa os campos da tela se não restou nenhum piso
                if (grdPiso.Rows.Count == 0)
                    Limpa();

                grdPiso.AutoResizeColumns();
            }
            finally
            {
                grdPiso.SelectionChanged += grdPiso_SelectionChanged;
            }
        }

        /// <summary>
        /// Obtém o piso selecionado e o carrega na tela
        /// </summary>
        private void CarregaPisoSelecionado()
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
            txtDiretorio.Text = string.Empty;
            CarregaPisoSelecionado();
        }
        #endregion
    }
}

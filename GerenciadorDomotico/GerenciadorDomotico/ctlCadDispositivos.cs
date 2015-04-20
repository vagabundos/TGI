using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Controle;
using Biblioteca.Modelo;
using Dados;
using GerenciadorDomotico.Dispositivos;

namespace GerenciadorDomotico
{
    public partial class ctlCadDispositivos : ctlCadBase
    {
        #region Construtores
        public ctlCadDispositivos()
            : base()
        {
            InitializeComponent();

            AtualizaTela = StatusTela.View;
            imgPiso.SizeMode = PictureBoxSizeMode.Zoom;
            btnApaga.Visible = true;
            btnCancela.Visible = true;
            btnEdita.Visible = true;
            btnFecha.Visible = true;
            btnNovo.Visible = true;
            btnSalva.Visible = true;

            ConfiguraTela();
        }
        #endregion

        #region Propriedades
        private controlBase<Dispositivo> controleTela = new controlBase<Dispositivo>();
        private List<Piso> _lstPisos = null;
        private int _itemSel_PosicaoX;
        private int _itemSel_PosicaoY;
        private ctlDispositivoBase objDisp = new ctlDispositivoBase();
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

                switch (this.AtualizaTela)
                {
                    case StatusTela.New:
                        txtCodigo.Enabled = true;
                        txtDescricao.Enabled = true;
                        cmbPiso.Enabled = true;
                        cmbTipo.Enabled = true;
                        grdDispositivos.Enabled = false;
                        break;

                    case StatusTela.Edit:
                        txtCodigo.Enabled = false;
                        cmbPiso.Enabled = false;
                        txtDescricao.Enabled = true;
                        cmbTipo.Enabled = true;
                        grdDispositivos.Enabled = false;
                        break;

                    case StatusTela.View:
                        txtCodigo.Enabled = false;
                        txtDescricao.Enabled = false;
                        cmbPiso.Enabled = false;
                        cmbTipo.Enabled = false;
                        grdDispositivos.Enabled = true;
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
            ActiveControl = txtCodigo;
            txtCodigo.Focus();
        }

        protected override void Edita()
        {
            if (grdDispositivos.CurrentRow == null)
            {
                Limpa();
                return;
            }

            base.Edita();
            ActiveControl = txtDescricao;
            txtDescricao.Focus();
        }

        protected override void Salva()
        {
            try
            {
                using (Dados.GerenciadorDB mngBD = new Dados.GerenciadorDB(false))
                {
                    Dispositivo objDispositivo = null;

                    if (AtualizaTela == StatusTela.New)
                    {
                        objDispositivo = new Dispositivo();
                    }
                    else if (AtualizaTela == StatusTela.Edit)
                    {
                        // Se nenhum piso do grid estiver selecionado, limpa a tela e sai
                        if (grdDispositivos.CurrentRow == null)
                        {
                            Limpa();
                            return;
                        }

                        objDispositivo = (Dispositivo)grdDispositivos.CurrentRow.DataBoundItem;
                    }

                    if (objDispositivo != null)
                    {
                        objDispositivo.Codigo = txtCodigo.Text;
                        objDispositivo.Descricao = txtDescricao.Text;
                        objDispositivo.Piso = cmbPiso.SelectedValue.ToString();
                        objDispositivo.Tipo = (Dispositivo.TipoSensor)Enum.Parse(typeof(Dispositivo.TipoSensor), cmbTipo.SelectedValue.ToString());
                        Point posicaoDispositivo = objDisp.TranslateZoomMousePosition(imgPiso);
                        objDispositivo.PosicaoX = posicaoDispositivo.X;
                        objDispositivo.PosicaoY = posicaoDispositivo.Y;
                        controleTela.Salva(objDispositivo, mngBD);
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
                if (grdDispositivos.CurrentRow == null)
                {
                    Limpa();
                    return;
                }

                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    Dispositivo objDispositivoSelecionado = (Dispositivo)grdDispositivos.CurrentRow.DataBoundItem;
                    controleTela.Apaga(objDispositivoSelecionado, mngBD);
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

        protected override void Cancela()
        {
            base.Cancela();
            CarregaItemSelecionado();
        }

        private void ConfiguraTela()
        {
            // Adiciona controle visual do dispotivo
            pnlImagem.Controls.Add(objDisp);
            objDisp.BringToFront();
            objDisp.Visible = false;

            using (GerenciadorDB mngBD = new GerenciadorDB(false))
            {
                ConfiguraGrid();
                CarregaGrid();               

                // Carrega pisos e configura ComboBox
                _lstPisos = new controlBase<Piso>().LoadTodos(mngBD);

                var CodigosPiso = from Piso objAux in _lstPisos
                                  select objAux.Codigo;

                cmbPiso.DropDownStyle = ComboBoxStyle.DropDownList;
                List<string> lstCodigosPiso = CodigosPiso.ToList();
                lstCodigosPiso.Insert(0, string.Empty);
                cmbPiso.DataSource = lstCodigosPiso;

                // Configura ComboBox Tipos
                cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
                List<string> lstTipos = Enum.GetNames(typeof(Dispositivo.TipoSensor)).ToList();
                lstTipos.Insert(0, string.Empty);
                cmbTipo.DataSource = lstTipos;
            }
        }

        private void CarregaGrid()
        {
            try
            {
                // Desativa evento para evitar erros
                grdDispositivos.SelectionChanged -= grdDispositivo_SelectionChanged;

                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    BindingList<Dispositivo> bList = new BindingList<Dispositivo>(controleTela.LoadTodos(mngBD));
                    this.grdDispositivos.DataSource = bList;
                }

                if (grdDispositivos.Rows.Count == 0)
                {
                    Limpa();
                }

                grdDispositivos.AutoResizeColumns();
            }
            finally
            {
                grdDispositivos.SelectionChanged += grdDispositivo_SelectionChanged;
            }
        }

        private void ConfiguraGrid()
        {
            ConfiguraColunas(this.grdDispositivos, typeof(Dispositivo));
        }

        private void Limpa()
        {
            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            imgPiso.Image = null;
            _itemSel_PosicaoX = 0;
            _itemSel_PosicaoY = 0;
            if (cmbPiso.Items.Count > 0)
                cmbPiso.SelectedIndex = 0;
            if (cmbTipo.Items.Count > 0)
                cmbTipo.SelectedIndex = 0;
        }

        private void CarregaItemSelecionado()
        {
            // Se nenhum piso do grid estiver selecionado, limpa a tela e sai
            if (grdDispositivos.CurrentRow == null)
            {
                Limpa();
                return;
            }

            Dispositivo objDispositivoSelecionado = (Dispositivo)grdDispositivos.CurrentRow.DataBoundItem;

            txtCodigo.Text = objDispositivoSelecionado.Codigo;
            txtDescricao.Text = objDispositivoSelecionado.Descricao;
            if (cmbPiso.Items.Count > 0)
                cmbPiso.SelectedIndex = cmbPiso.FindString(objDispositivoSelecionado.Piso);
            if (cmbTipo.Items.Count > 0)
                cmbTipo.SelectedIndex = cmbTipo.FindString(Enum.GetName(typeof(Dispositivo.TipoSensor), objDispositivoSelecionado.Tipo));

            _itemSel_PosicaoX = objDispositivoSelecionado.PosicaoX;
            _itemSel_PosicaoY = objDispositivoSelecionado.PosicaoY;

            CarregaImagemPisoSelecionado();
        }

        public void CarregaImagemPisoSelecionado()
        {
            if (cmbPiso.SelectedValue != null && !string.IsNullOrEmpty(cmbPiso.SelectedValue.ToString()))
            {
                var auxPiso = from Piso objAux in _lstPisos
                              where objAux.Codigo == cmbPiso.SelectedValue.ToString()
                              select objAux;
                Piso objPisoSelecionado = auxPiso.First();

                if (objPisoSelecionado != null)
                {
                    imgPiso.Image = Biblioteca.Util.byteArrayToImage(objPisoSelecionado.Imagem);
                    objDisp.PosicionaImagem(_itemSel_PosicaoX, _itemSel_PosicaoY, imgPiso);
                    objDisp.Visible = true;
                }
            }
        }

        public void PosicionaDispositivo()
        {
            if (_itemSel_PosicaoX != 0 || _itemSel_PosicaoY != 0)
                objDisp.Location = new Point(_itemSel_PosicaoX, _itemSel_PosicaoY);
            else
            {

            }
        }
        #endregion

        #region Eventos
        private void grdDispositivo_SelectionChanged(object sender, EventArgs e)
        {
            CarregaItemSelecionado();
        }

        private void cmbPiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaImagemPisoSelecionado();
        }
        #endregion
    }
}

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
        #region Propriedades
        private controlBase<Dispositivo> controleTela = new controlBase<Dispositivo>();
        private List<Piso> _lstPisos = null;
        private KeyValuePair<ctlDispositivoBase, Point> pairDispSelecionado = new KeyValuePair<ctlDispositivoBase, Point>(new ctlDispositivoBase(), new Point(0, 0));
        private Dictionary<ctlDispositivoBase, Point> dicDisp = new Dictionary<ctlDispositivoBase, Point>();
        #endregion

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
                        txtCodControlador.Enabled = true;
                        cmbPiso.Enabled = true;
                        cmbTipo.Enabled = true;
                        grdDispositivos.Enabled = false;
                        pairDispSelecionado.Key.PermiteArrastar(true);
                        break;

                    case StatusTela.Edit:
                        txtCodigo.Enabled = false;
                        txtDescricao.Enabled = true;
                        txtCodControlador.Enabled = true;
                        cmbPiso.Enabled = false;
                        cmbTipo.Enabled = true;
                        grdDispositivos.Enabled = false;
                        pairDispSelecionado.Key.PermiteArrastar(true);
                        break;

                    case StatusTela.View:
                        txtCodigo.Enabled = false;
                        txtDescricao.Enabled = false;
                        txtCodControlador.Enabled = false;
                        cmbPiso.Enabled = false;
                        cmbTipo.Enabled = false;
                        grdDispositivos.Enabled = true;
                        pairDispSelecionado.Key.PermiteArrastar(false);
                        break;

                    default:
                        break;
                }
            }
        }

        protected override void ResizeTela()
        {
            base.ResizeTela();
            pairDispSelecionado.Key.setPosicaoDispositivoNaImagem(pairDispSelecionado.Value.X, pairDispSelecionado.Value.Y, imgPiso);

            // Seta a nova posição de cada um dos dispositivos exibidos
            foreach (KeyValuePair<ctlDispositivoBase, Point> pairDisp in dicDisp)
            {
                pairDisp.Key.setPosicaoDispositivoNaImagem(pairDisp.Value.X, pairDisp.Value.Y, imgPiso);
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
                MessageBox.Show("Não há nenhum dispositivo selecionado. Selecione um dispositivo para poder editá-lo.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Limpa();
                return;
            }

            base.Edita();
            ActiveControl = txtDescricao;
            txtDescricao.Focus();
        }

        protected override void Salva()
        {
            string sMensagem = string.Empty;

            // Valida Dados
            if (!Valida(out sMensagem))
            {
                MessageBox.Show(sMensagem, "O dispositivo não pôde ser salvo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

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
                        objDispositivo.Controlador = txtCodControlador.Text;
                        objDispositivo.Piso = cmbPiso.SelectedValue.ToString();
                        objDispositivo.Tipo = (Dispositivo.TipoSensor)Enum.Parse(typeof(Dispositivo.TipoSensor), cmbTipo.SelectedValue.ToString());

                        Point posicaoDispositivo = pairDispSelecionado.Key.getPosicaoDispositivoNaImagem(imgPiso);
                        objDispositivo.PosicaoX = posicaoDispositivo.X;
                        objDispositivo.PosicaoY = posicaoDispositivo.Y;

                        controleTela.Salva(objDispositivo, mngBD);

                        string sDetalhe = "Dispositivo '" + objDispositivo.Codigo + "' salvo com sucesso.";
                        Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.ManutencaoTabelaDispositivos, sDetalhe);
                    }
                }
            }
            catch (Exception exc)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao salvar dispositivo. ", exc);
                MessageBox.Show("Erro ao Salvar Dispositivo. Visualizar a tabela de logs para mais detalhes.", "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                base.Salva();
                CarregaGrid();
                CarregaItemSelecionado();
            }
        }

        protected override void Apaga()
        {
            try
            {
                // Sai se nenhum piso do grid estiver selecionado
                if (grdDispositivos.CurrentRow == null)
                {
                    MessageBox.Show("Não há nenhum dispositivo selecionado. Selecione um dispositivo para poder apagá-lo.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Limpa();
                    return;
                }

                // Janela de confirmação
                DialogResult drApaga = MessageBox.Show("Tem certeza que deseja apagar o dispositivo selecionado?", "Apagar Dispositivo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    Dispositivo objDispositivoSelecionado = (Dispositivo)grdDispositivos.CurrentRow.DataBoundItem;
                    controleTela.Apaga(objDispositivoSelecionado, mngBD);

                    string sDetalhe = "Dispositivo '" + objDispositivoSelecionado.Codigo + "' apagado com sucesso.";
                    Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.ManutencaoTabelaDispositivos, sDetalhe);
                }
            }
            catch (Exception exc)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao apagar dispositivo. ", exc);
                MessageBox.Show("Erro ao Apagar Dispositivo. Visualizar a tabela de logs para mais detalhes.", "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                base.Apaga();
                CarregaGrid();
                CarregaItemSelecionado();
            }
        }

        protected override void Cancela()
        {
            base.Cancela();
            CarregaItemSelecionado();
        }

        private bool Valida(out string sMensagem)
        {
            sMensagem = string.Empty;

            // Valida
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                sMensagem = "Codigo do dispositivo não informado.";
                return false;
            }

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                sMensagem = "Descrição do dispositivo não informada.";
                return false;
            }

            if (string.IsNullOrEmpty(cmbPiso.SelectedValue.ToString()))
            {
                sMensagem = "Piso do dispositivo não selecionado.";
                return false;
            }

            if (string.IsNullOrEmpty(cmbTipo.SelectedValue.ToString()))
            {
                sMensagem = "Tipo do dispositivo não selecionado.";
                return false;
            }
            
            if (string.IsNullOrEmpty(txtCodControlador.Text))
            {
                sMensagem = "Código do Controlador associado ao Dispositivo não informado.";
                return false;
            }

            return true;
        }

        private void ConfiguraTela()
        {
            // Adiciona controle visual do dispositivo
            imgPiso.Controls.Add(pairDispSelecionado.Key);
            pairDispSelecionado.Key.BringToFront();
            pairDispSelecionado.Key.Visible = false;

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
                    Limpa();

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
            txtCodControlador.Text = string.Empty;
            imgPiso.Image = null;
            pairDispSelecionado.Key.Visible = false;
            
            // Reseta o ponto inicial do dispositivo
            pairDispSelecionado = new KeyValuePair<ctlDispositivoBase, Point>(pairDispSelecionado.Key, new Point(0,0));
            if (cmbPiso.Items.Count > 0)
                cmbPiso.SelectedIndex = 0;
            if (cmbTipo.Items.Count > 0)
                cmbTipo.SelectedIndex = 0;

            // Limpa o dicionario de dispositivos para exibição
            LimpaDispositivosExibicao();
        }

        /// <summary>
        /// Limpa o dicionario de dispositivos para exibição
        /// </summary>
        private void LimpaDispositivosExibicao()
        {
            foreach (KeyValuePair<ctlDispositivoBase, Point> pairDisp in dicDisp)
            {
                pairDisp.Key.Visible = false;
                imgPiso.Controls.Remove(pairDisp.Key);
            }
            dicDisp.Clear();
        }

        private void CarregaItemSelecionado()
        {
            // Se nenhum piso do grid estiver selecionado, limpa a tela e sai
            if (grdDispositivos.CurrentRow == null)
            {
                Limpa();
                return;
            }

            // Carrega o dispositivo selecionado
            Dispositivo objDispositivoSelecionado = (Dispositivo)grdDispositivos.CurrentRow.DataBoundItem;

            txtCodigo.Text = objDispositivoSelecionado.Codigo;
            txtDescricao.Text = objDispositivoSelecionado.Descricao;
            txtCodControlador.Text = objDispositivoSelecionado.Controlador;
            if (cmbPiso.Items.Count > 0)
                cmbPiso.SelectedIndex = cmbPiso.FindString(objDispositivoSelecionado.Piso);
            if (cmbTipo.Items.Count > 0)
                cmbTipo.SelectedIndex = cmbTipo.FindString(Enum.GetName(typeof(Dispositivo.TipoSensor), objDispositivoSelecionado.Tipo));

            Point newPos = new Point();
            newPos.X = objDispositivoSelecionado.PosicaoX;
            newPos.Y = objDispositivoSelecionado.PosicaoY;

            pairDispSelecionado = new KeyValuePair<ctlDispositivoBase, Point>(pairDispSelecionado.Key, newPos);

            CarregaImagemPisoSelecionado();
        }

        public void CarregaImagemPisoSelecionado()
        {
            pairDispSelecionado.Key.Visible = false;

            if (cmbPiso.SelectedValue != null && !string.IsNullOrEmpty(cmbPiso.SelectedValue.ToString()))
            {
                var auxPiso = from Piso objAux in _lstPisos
                              where objAux.Codigo == cmbPiso.SelectedValue.ToString()
                              select objAux;
                Piso objPisoSelecionado = auxPiso.First();

                if (objPisoSelecionado != null)
                {
                    imgPiso.Image = Biblioteca.Util.byteArrayToImage(objPisoSelecionado.Imagem);
                    pairDispSelecionado.Key.setPosicaoDispositivoNaImagem(pairDispSelecionado.Value.X, pairDispSelecionado.Value.Y, imgPiso);
                    pairDispSelecionado.Key.Visible = true;

                    // Carrega os outros dispositivos para exibição
                    CarregaDispositivosPiso();
                }
            }
        }

        /// <summary>
        /// Carrega todos os Dispositivos do piso (exceto o selecionado) para serem exibidos junto ao dispositivo selecionado
        /// </summary>
        public void CarregaDispositivosPiso()
        {
            // Limpa dicionário de dispositivos do piso
            LimpaDispositivosExibicao();
            Dispositivo objDispositivoSelecionado = null;

            if (base.AtualizaTela != StatusTela.New)
            {
                // Pega o dispositivo selecionado atual, se estiver em modo edição
                objDispositivoSelecionado = (Dispositivo)grdDispositivos.CurrentRow.DataBoundItem;
            }

            foreach (DataGridViewRow grdRow in grdDispositivos.Rows)
            {
                Dispositivo disp = (Dispositivo)grdRow.DataBoundItem;

                // Se for o dispositivo selecionado (caso não seja um novo dispositivo), não inclui
                if (objDispositivoSelecionado != null)
                {
                    if (disp.Codigo == objDispositivoSelecionado.Codigo)
                        continue;
                }

                // Se o dispositivo não pertencer ao piso selecionado, não inclui
                if (disp.Piso != cmbPiso.SelectedValue.ToString())
                    continue;

                // Seta a posicao do dispositivo
                Point newPos = new Point();
                newPos.X = disp.PosicaoX;
                newPos.Y = disp.PosicaoY;

                // Inclui o dispositivo para visualização apenas
                ctlDispositivoBase ctlDisp = new ctlDispositivoBase();
                ctlDisp.PermiteArrastar(false);
                ctlDisp.setPosicaoDispositivoNaImagem(newPos.X, newPos.Y, imgPiso);
                ctlDisp.SetTransparenciaImagem((float)0.4);
                imgPiso.Controls.Add(ctlDisp);
                ctlDisp.BringToFront();
                ctlDisp.Visible = true;
                dicDisp.Add(ctlDisp, newPos);
            }
        }

        /// <summary>
        /// Atualiza a variável da posição atual do ctlDispositivoBase em edição
        /// </summary>
        public void AtualizaPosicaoAtual()
        {
            Point posAtualDispositivo = pairDispSelecionado.Key.getPosicaoDispositivoNaImagem(imgPiso);
            pairDispSelecionado = new KeyValuePair<ctlDispositivoBase, Point>(pairDispSelecionado.Key, posAtualDispositivo);
        }
        #endregion

        #region Eventos
        private void grdDispositivo_SelectionChanged(object sender, EventArgs e)
        {
            // Gambiarra: Ao iniciar a tela, esse evento é chamado duas vezes. Na segunda vez, o grdDispositivos.Rows fica sempre igual a 1
            if (grdDispositivos.Rows.Count != ((ICollection<Dispositivo>)grdDispositivos.DataSource).Count)
                return;

            CarregaItemSelecionado();
        }

        private void cmbPiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaImagemPisoSelecionado();
        }

        private void imgPiso_MouseLeave(object sender, EventArgs e)
        {
            AtualizaPosicaoAtual();
        }
        #endregion
    }
}

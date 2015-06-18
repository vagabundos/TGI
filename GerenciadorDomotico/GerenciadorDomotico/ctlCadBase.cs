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
using System.Reflection;
using Biblioteca.Modelo.Atributos;

namespace GerenciadorDomotico
{
    public partial class ctlCadBase : ctlBase
    {
        #region Propriedades
        private StatusTela _statusTela = StatusTela.View;
        #endregion

        #region Construtores
        public ctlCadBase()
        {
            InitializeComponent();

            // Status inicial da tela
            AtualizaTela = StatusTela.View;

            // Define os botões inicialmente como invisíveis
            btnApaga.Visible = false;
            btnAtivaInativa.Visible = false;
            btnEdita.Visible = false;
            btnNovo.Visible = false;
            btnSalva.Visible = false;
            btnCancela.Visible = false;
        }
        #endregion

        #region Métodos
        public override void SelecionaAba()
        {
            base.SelecionaAba();
            Biblioteca.Util.AlinharBotoes(pnlBotoes);
        }

        protected virtual void ConfiguraColunas(DataGridView grdBase, Type typeModelo)
        {
            // Tamanho
            grdBase.RowTemplate.Height = 17;
            grdBase.AutoGenerateColumns = false;
            grdBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grdBase.ScrollBars = ScrollBars.Both;

            PropertyInfo[] props = typeModelo.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Attribute atrib = prop.GetCustomAttribute(typeof(AtributoPropriedade), true);
                if (atrib != null)
                {
                    AtributoPropriedade atribProp = (AtributoPropriedade)atrib;

                    if (atribProp.OcultaGrid)
                        continue;

                    string sCaption = atribProp.Caption;
                    string sCollumn = prop.Name;

                    grdBase.Columns.Add(sCollumn, sCaption);
                    grdBase.Columns[sCollumn].DataPropertyName = sCollumn;

                    if (atribProp.OrdemGrid > 0)
                    {
                        grdBase.Columns[sCollumn].DisplayIndex = atribProp.OrdemGrid - 1;
                    }
                }
            }

            grdBase.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        protected virtual void Novo()
        {
            AtualizaTela = StatusTela.New;
        }

        protected virtual void Edita()
        {
            AtualizaTela = StatusTela.Edit;
        }

        protected virtual void Salva()
        {
            AtualizaTela = StatusTela.View;
        }

        protected virtual void Cancela()
        {
            AtualizaTela = StatusTela.View;
        }

        protected virtual void Apaga()
        {
            AtualizaTela = StatusTela.View;
        }

        protected virtual void AtivaInativa()
        {
            AtualizaTela = StatusTela.View;
        }

        protected virtual void ResizeTela()
        {

        }

        protected virtual StatusTela AtualizaTela
        {
            get
            {
                return _statusTela;
            }

            set
            {
                _statusTela = value;
                switch (_statusTela)
                {
                    case StatusTela.New:
                        btnNovo.Enabled = false;
                        btnEdita.Enabled = false;
                        btnSalva.Enabled = true;
                        btnCancela.Enabled = true;
                        btnApaga.Enabled = false;
                        btnAtivaInativa.Enabled = false;
                        break;

                    case StatusTela.Edit:
                        btnNovo.Enabled = false;
                        btnEdita.Enabled = false;
                        btnSalva.Enabled = true;
                        btnCancela.Enabled = true;
                        btnApaga.Enabled = false;
                        btnAtivaInativa.Enabled = false;
                        break;

                    case StatusTela.View:
                        btnNovo.Enabled = true;
                        btnEdita.Enabled = true;
                        btnSalva.Enabled = false;
                        btnCancela.Enabled = false;
                        btnApaga.Enabled = true;
                        btnAtivaInativa.Enabled = true;
                        break;

                    default:
                        break;
                }
            }
        }
        #endregion

        #region Enums
        protected enum StatusTela
        {
            New = 1,
            Edit = 2,
            View = 3
        }
        #endregion

        #region Eventos

        private void btnFecha_Click(object sender, EventArgs e)
        {
            Fecha();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btnEdita_Click(object sender, EventArgs e)
        {
            Edita();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            Salva();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Cancela();
        }

        private void btnAtivaInativa_Click(object sender, EventArgs e)
        {
            AtivaInativa();
        }

        private void btnApaga_Click(object sender, EventArgs e)
        {
            Apaga();
        }

        private void ctlCadBase_Resize(object sender, EventArgs e)
        {
            Biblioteca.Util.AlinharBotoes(pnlBotoes);
            ResizeTela();
        }

        #endregion
    }
}

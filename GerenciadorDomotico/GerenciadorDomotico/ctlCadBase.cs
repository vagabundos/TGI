using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDomotico
{
    public partial class ctlCadBase : UserControl
    {
        #region Propriedades
        protected enum StatusTela
        {
            New = 1,
            Edit = 2,
            View = 3
        }

        StatusTela _statusTela = StatusTela.View;
        #endregion

        #region Construtores
        public ctlCadBase()
        {
            InitializeComponent();

            // Define os botões inicialmente como invisíveis
            btnApaga.Visible = false;
            btnAtivaInativa.Visible = false;
            btnEdita.Visible = false;
            btnNovo.Visible = false;
            btnSalva.Visible = false;
            btnCancela.Visible = false;

            Biblioteca.Util.AlinharBotoes(pnlBotoes);
        }
        #endregion

        #region Métodos
        protected virtual void Novo()
        {

        }

        protected virtual void Edita()
        {

        }

        protected virtual void Salva()
        {

        }

        protected virtual void Cancela()
        {

        }

        protected virtual void Apaga()
        {

        }

        protected virtual void AtivaInativa()
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

        #region Eventos

        private void btnFecha_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        #endregion
    }
}

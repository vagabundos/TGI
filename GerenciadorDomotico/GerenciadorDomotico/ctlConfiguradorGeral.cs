using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GerenciadorDomotico
{
    public partial class ctlConfiguradorGeral : ctlCadBase
    {
        #region Propriedades
        #endregion

        #region Construtores
        public ctlConfiguradorGeral()
        {
            InitializeComponent();

            btnEdita.Visible = true;
            btnSalva.Visible = true;
            btnCancela.Visible = true;

            AtualizaTela = StatusTela.View;

            CarregaCamposPredefinidos();
            Limpa();
            CarregaTela();
            
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
                if (txtServidor == null)
                    return;

                switch (this.AtualizaTela)
                {
                    case StatusTela.Edit:
                        txtServidor.Enabled = true;
                        txtPortaTcp.Enabled = true;
                        txtPortaSerial.Enabled = true;
                        cmbBaudRate.Enabled = true;
                        cmbDataBits.Enabled = true;
                        cmbParidade.Enabled = true;
                        cmbStopBits.Enabled = true;
                        break;

                    case StatusTela.View:
                        txtServidor.Enabled = false;
                        txtPortaTcp.Enabled = false;
                        txtPortaSerial.Enabled = false;
                        cmbBaudRate.Enabled = false;
                        cmbDataBits.Enabled = false;
                        cmbParidade.Enabled = false;
                        cmbStopBits.Enabled = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void CarregaTela()
        {
            // To-Do: Carrega as configurações do Banco de Dados
        }

        private void CarregaCamposPredefinidos()
        {
            // ComboBox Baud Rate
            cmbBaudRate.Items.Add("1200");
            cmbBaudRate.Items.Add("2400");
            cmbBaudRate.Items.Add("4800");
            cmbBaudRate.Items.Add("9600");
            cmbBaudRate.Items.Add("19200");
            cmbBaudRate.Items.Add("38400");
            cmbBaudRate.Items.Add("57600");
            cmbBaudRate.Items.Add("115200");
            cmbBaudRate.Items.Add("230400");

            // ComboBox Parity
            List<string> lstParidade = Enum.GetNames(typeof(Parity)).ToList<string>();
            cmbParidade.DataSource = lstParidade;

            // ComboBox Data Bits
            cmbDataBits.Items.Add("5");
            cmbDataBits.Items.Add("6");
            cmbDataBits.Items.Add("7");
            cmbDataBits.Items.Add("8");

            // ComboBox Stop Bits
            List<string> lstStopBits = Enum.GetNames(typeof(StopBits)).ToList<string>();
            cmbStopBits.DataSource = lstStopBits;
        }

        private void Limpa()
        {
            txtPortaSerial.Text = string.Empty;
            txtPortaTcp.Text = string.Empty;
            txtServidor.Text = string.Empty;
            cmbBaudRate.SelectedIndex = -1;
            cmbParidade.SelectedIndex = -1;
            cmbDataBits.SelectedIndex = -1;
            cmbStopBits.SelectedIndex = -1;
        }

        protected override void Salva()
        {
            base.Salva();
        }

        protected override void Cancela()
        {
            base.Cancela();
            Limpa();
            CarregaTela();
        }
        #endregion

        #region Eventos
        #endregion
    }
}

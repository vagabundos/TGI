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
using Biblioteca.Controle;
using Biblioteca.Modelo;
using Dados;

namespace GerenciadorDomotico
{
    public partial class ctlConfiguradorGeral : ctlCadBase
    {
        #region Propriedades
        private controlBase<ConfiguracaoGeral> controleTela = new controlBase<ConfiguracaoGeral>();
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
                if (txtIdServidor == null)
                    return;

                switch (this.AtualizaTela)
                {
                    case StatusTela.Edit:
                        txtIdServidor.Enabled = true;
                        txtWsServidor.Enabled = true;
                        txtWsPorta.Enabled = true;
                        txtPortaSerial.Enabled = true;
                        cmbBaudRate.Enabled = true;
                        cmbDataBits.Enabled = true;
                        cmbParidade.Enabled = true;
                        cmbStopBits.Enabled = true;
                        break;

                    case StatusTela.View:
                        txtIdServidor.Enabled = false;
                        txtWsServidor.Enabled = false;
                        txtWsPorta.Enabled = false;
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
            try
            {
                // Carrega as configurações do Banco de Dados
                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    List<ConfiguracaoGeral> lstConfig = controleTela.LoadTodos(mngBD);

                    if (lstConfig.Count > 0)
                    {
                        // Pega só o primeiro, uma vez que essa tabela deverá conter uma única linha
                        ConfiguracaoGeral objConfig = lstConfig[0];

                        // Carrega as informações na tela
                        txtIdServidor.Text = objConfig.IdServidor;
                        txtWsServidor.Text = objConfig.WsServidor;
                        txtWsPorta.Text = objConfig.WsPorta;
                        txtPortaSerial.Text = objConfig.SerialPorta;
                        cmbBaudRate.SelectedIndex = cmbBaudRate.FindString(objConfig.SerialBaudRate.ToString());
                        cmbParidade.SelectedIndex = cmbParidade.FindString(Enum.GetName(typeof(Parity), objConfig.SerialParidade));
                        cmbDataBits.SelectedIndex = cmbDataBits.FindString(objConfig.SerialDataBits.ToString());
                        cmbStopBits.SelectedIndex = cmbStopBits.FindString(Enum.GetName(typeof(StopBits), objConfig.SerialStopBits));
                    }
                }
            }
            catch(Exception ex)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao carregar os dados da tabela do Configuador Geral. ", ex);
                MessageBox.Show("Erro ao carregar os dados da tabela do Configurador Geral. Visualizar a tabela de logs para mais detalhes.", "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpa();
            }
        }

        private void CarregaCamposPredefinidos()
        {
            // ComboBox Baud Rate
            List<int> lstBaudRate = new List<int>();
            lstBaudRate.Add(1200);
            lstBaudRate.Add(2400);
            lstBaudRate.Add(4800);
            lstBaudRate.Add(9600);
            lstBaudRate.Add(19200);
            lstBaudRate.Add(38400);
            lstBaudRate.Add(57600);
            lstBaudRate.Add(115200);
            lstBaudRate.Add(230400);
            cmbBaudRate.DataSource = lstBaudRate;

            // ComboBox Parity
            cmbParidade.DataSource = Enum.GetNames(typeof(Parity));

            // ComboBox Data Bits
            List<int> lstDataBits = new List<int>();
            lstDataBits.Add(5);
            lstDataBits.Add(6);
            lstDataBits.Add(7);
            lstDataBits.Add(8);
            cmbDataBits.DataSource = lstDataBits;

            // ComboBox Stop Bits
            cmbStopBits.DataSource = Enum.GetNames(typeof(StopBits));
        }

        private void Limpa()
        {
            txtIdServidor.Text = string.Empty;
            txtPortaSerial.Text = string.Empty;
            txtWsPorta.Text = string.Empty;
            txtWsServidor.Text = string.Empty;
            cmbBaudRate.SelectedIndex = 3;
            cmbParidade.SelectedIndex = 0;
            cmbDataBits.SelectedIndex = 3;
            cmbStopBits.SelectedIndex = 1;
        }

        protected override void Salva()
        {
            string sMensagem = string.Empty;

            // Valida Dados
            if (!Valida(out sMensagem))
            {
                MessageBox.Show(sMensagem, "As configurações não puderam ser salvas", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                using (GerenciadorDB mngBD = new GerenciadorDB(true))
                {
                    ConfiguracaoGeral objConfig = new ConfiguracaoGeral();

                    // Monta objeto do Configurador Geral
                    objConfig.IdServidor = txtIdServidor.Text;
                    objConfig.WsServidor = txtWsServidor.Text;
                    objConfig.WsPorta = txtWsPorta.Text;
                    objConfig.SerialPorta = txtPortaSerial.Text;
                    objConfig.SerialBaudRate = int.Parse(cmbBaudRate.SelectedValue.ToString());
                    objConfig.SerialParidade = (Parity)Enum.Parse(typeof(Parity), cmbParidade.SelectedValue.ToString());
                    objConfig.SerialDataBits = int.Parse(cmbDataBits.SelectedValue.ToString());
                    objConfig.SerialStopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.SelectedValue.ToString());

                    // Antes de salvar, verifica se já existe algo salvo na tabela (Essa tabela pode conter apenas uma linha)
                    List<ConfiguracaoGeral> lstConfig = controleTela.LoadTodos(mngBD);

                    // Apaga todos os itens recebidos
                    foreach (ConfiguracaoGeral oldConfig in lstConfig)
                        controleTela.Apaga(oldConfig, mngBD);

                    // Salva a nova Configuração
                    controleTela.Salva(objConfig, mngBD);

                    mngBD.ConfirmaTransacao();
                }
            }
            catch (Exception ex)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao salvar Configuador Geral. ", ex);
                MessageBox.Show("Erro ao Salvar Configurador Geral. Visualizar a tabela de logs para mais detalhes.", "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                base.Salva();
                CarregaTela();
            }
        }

        private bool Valida(out string sMensagem)
        {
            sMensagem = string.Empty;

            // Valida
            if (string.IsNullOrEmpty(txtIdServidor.Text))
            {
                sMensagem = "Um código de Identificação do Servidor deve ser informado antes de salvar.";
                return false;
            }

            return true;
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

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

namespace GerenciadorDomotico
{
    // Esta classe foi herdada da ctlCadBase apenas para aproveitar a facilidade da criação do grid
    public partial class ctlTraceComunicacao : ctlCadBase
    {
        #region Propriedades
        private controlBase<TraceComunicacao> controleTela = new controlBase<TraceComunicacao>();
        #endregion

        #region Construtores
        public ctlTraceComunicacao()
        {
            InitializeComponent();

            ConfiguraTela();
            CarregaGrid();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Carrega a tela da forma correta, logo quando é aberta
        /// </summary>
        private void ConfiguraTela()
        {
            CarregaTiposProcedenciaTrace();
            ConfiguraGrid();
            dtInicio.Value = DateTime.Now.Date;
            dtFinal.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        /// <summary>
        /// Carrega todos os tipos de Procedencia de Trace no CheckBox List para filtrar as ocorrências de Trace exibidos
        /// </summary>
        private void CarregaTiposProcedenciaTrace()
        {
            chkProcedenciaTrace.Items.Clear();
            chkProcedenciaTrace.Items.AddRange(Enum.GetNames(typeof(TraceComunicacao.ProcedenciaTrace)));
            
            // Seleciona todos os tipos por default
            for (int index = 0; index < chkProcedenciaTrace.Items.Count; index++)
            {
                chkProcedenciaTrace.SetItemChecked(index, true);
            }
        }

        /// <summary>
        /// Configura as colunas do Grid de acordo com o objeto Modelo
        /// </summary>
        private void ConfiguraGrid()
        {
            ConfiguraColunas(this.grdTraceOcorrencias, typeof(TraceComunicacao));
        }

        private void Limpa()
        {
            grdTraceOcorrencias.DataSource = null;
            txtMensagem.Text = string.Empty;
        }

        /// <summary>
        /// Retorna uma lista com todos as procedencias de Trace selecionadas
        /// </summary>
        public List<TraceComunicacao.ProcedenciaTrace> GetProcedenciaTraceSelecionados()
        {
            List<TraceComunicacao.ProcedenciaTrace> lstProcTrace = new List<TraceComunicacao.ProcedenciaTrace>();

            for (int index = 0; index < chkProcedenciaTrace.Items.Count; index++)
            {
                if (chkProcedenciaTrace.GetItemChecked(index))
                {
                    lstProcTrace.Add((TraceComunicacao.ProcedenciaTrace)Enum.Parse(typeof(TraceComunicacao.ProcedenciaTrace), chkProcedenciaTrace.Items[index].ToString()));
                }
            }

            return lstProcTrace;
        }

        private void CarregaGrid()
        {
            try
            {
                BindingList<TraceComunicacao> bList;

                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    bList = new BindingList<TraceComunicacao>(controleTela.LoadTodos(mngBD));    
                }

                // Pega as procedencias de trace selecionadas no filtro para exibição
                List<TraceComunicacao.ProcedenciaTrace> lstProcedenciaTrace = GetProcedenciaTraceSelecionados();

                // Aplica filtros da tela na lista
                var auxTrace = (from TraceComunicacao objTrace in bList.OrderByDescending(l => l.ID)
                                where lstProcedenciaTrace.Contains(objTrace.Procedencia)
                                where dtInicio.Value <= objTrace.DataHoraOcorrencia
                                where dtFinal.Value >= objTrace.DataHoraOcorrencia
                                select objTrace).Select(t => { t.Mensagem = Util.TraduzCaracteresEspeciais(t.Mensagem); return t; });

                List<TraceComunicacao> lstTrace = auxTrace.ToList();

                #region Filtros Opcionais

                // Filtro pelo ID da ocorrência do Trace
                if (!string.IsNullOrEmpty(txtOcorrencia.Text))
                    lstTrace = lstTrace.Where(t => t.ID.ToString() == txtOcorrencia.Text).ToList();

                // Filtro pelo código do Controlador
                if (!string.IsNullOrEmpty(txtControlador.Text))
                    lstTrace = lstTrace.Where(t => t.Controlador == txtControlador.Text).ToList();

                // Filtro pelo código do Dispositivo
                if (!string.IsNullOrEmpty(txtDispositivo.Text))
                    lstTrace = lstTrace.Where(t => t.Dispositivo == txtDispositivo.Text).ToList();

                #endregion

                this.grdTraceOcorrencias.DataSource = lstTrace;

                if (grdTraceOcorrencias.Columns.Contains("DataHoraOcorrencia"))
                {
                    grdTraceOcorrencias.Columns["DataHoraOcorrencia"].DefaultCellStyle.Format = "dd/MM/yyyy hh:MM:ss";
                }

                grdTraceOcorrencias.AutoResizeColumns();
            }
            catch(Exception ex)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao carregar ocorrências de Trace. ", ex);
                MessageBox.Show("Erro ao Carregar as ocorrências de Trace do sistema.", "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos
        private void ctlTraceComunicacao_Resize(object sender, EventArgs e)
        {
            Util.AlinharBotoes(pnlBotoes);
        }

        private void grdTraceOcorrencias_SelectionChanged(object sender, EventArgs e)
        {
            // Se nenhum Trace do grid estiver selecionado, sai
            if (grdTraceOcorrencias.CurrentRow == null)
            {
                Limpa();
                return;
            }

            // Carrega a mensagem da ocorrência do Trace para exibição
            TraceComunicacao objTrace = (TraceComunicacao)grdTraceOcorrencias.CurrentRow.DataBoundItem;
            txtMensagem.Text = objTrace.Mensagem;
        }

        private void btnExibe_Click(object sender, EventArgs e)
        {
            Limpa();
            CarregaGrid();
        }
        #endregion
    }
}

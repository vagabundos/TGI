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
    public partial class ctlLogs : ctlCadBase
    {
        #region Propriedades
        private controlBase<Log> controleTela = new controlBase<Log>();
        #endregion

        #region Construtores
        public ctlLogs()
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
            CarregaTiposLog();
            ConfiguraGrid();
            dtInicio.Value = DateTime.Now.Date;
            dtFinal.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        /// <summary>
        /// Carrega todos os tipos de log no CheckBox List para filtrar os logs exibidos
        /// </summary>
        private void CarregaTiposLog()
        {
            chkTiposLog.Items.Clear();
            chkTiposLog.Items.AddRange(Enum.GetNames(typeof(Log.LogTipo)));
            
            // Seleciona todos os tipos por default
            for (int index = 0; index < chkTiposLog.Items.Count; index++)
            {
                chkTiposLog.SetItemChecked(index, true);
            }
        }

        /// <summary>
        /// Configura as colunas do Grid de acordo com o objeto Modelo
        /// </summary>
        private void ConfiguraGrid()
        {
            ConfiguraColunas(this.grdLogs, typeof(Log));
        }

        private void Limpa()
        {
            grdLogs.DataSource = null;
            txtDetalhes.Text = string.Empty;
        }

        /// <summary>
        /// Retorna uma lista com todos os tipos de log selecionados
        /// </summary>
        public List<Log.LogTipo> GetTipoLogsSelecionados()
        {
            List<Log.LogTipo> lstTiposLog = new List<Log.LogTipo>();

            for (int index = 0; index < chkTiposLog.Items.Count; index++)
            {
                if (chkTiposLog.GetItemChecked(index))
                {
                    lstTiposLog.Add((Log.LogTipo)Enum.Parse(typeof(Log.LogTipo), chkTiposLog.Items[index].ToString()));
                }
            }

            return lstTiposLog;
        }

        private void CarregaGrid()
        {
            try
            {
                BindingList<Log> bList;

                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    bList = new BindingList<Log>(controleTela.LoadTodos(mngBD));    
                }

                // Pega os tipos de logs selecionados no filtro para exibição
                List<Log.LogTipo> lstTiposLog = GetTipoLogsSelecionados();

                // Aplica filtros da tela na lista
                var auxLogs = from Log objLog in bList.OrderByDescending(l => l.ID)
                              where lstTiposLog.Contains(objLog.Tipo)
                              where dtInicio.Value <= objLog.DataHoraInclusao
                              where dtFinal.Value >= objLog.DataHoraInclusao
                              select objLog;

                List<Log> lstLogs = auxLogs.ToList();

                // Se o filtro direto por ID de ocorrência foi utilizado, faz a busca
                if (!string.IsNullOrEmpty(txtOcorrencia.Text))
                {
                    Log objLog = lstLogs.FirstOrDefault(l => l.ID.ToString() == txtOcorrencia.Text);
                    lstLogs.Clear();
                    if (objLog != null)
                        lstLogs.Add(objLog);
                }

                this.grdLogs.DataSource = lstLogs;

                grdLogs.AutoResizeColumns();
            }
            catch(Exception ex)
            {
                Biblioteca.Controle.controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao carregar logs. ", ex);
                MessageBox.Show("Erro ao Carregar os logs na tela.", "Erro no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos
        private void ctlLogs_Resize(object sender, EventArgs e)
        {
            Util.AlinharBotoes(pnlBotoes);
        }

        private void grdLogs_SelectionChanged(object sender, EventArgs e)
        {
            // Se nenhum log do grid estiver selecionado, sai
            if (grdLogs.CurrentRow == null)
            {
                Limpa();
                return;
            }

            // Carrega o detalhamento do log para exibição
            Log objLog = (Log)grdLogs.CurrentRow.DataBoundItem;
            txtDetalhes.Text = objLog.Descricao;
        }

        private void btnExibe_Click(object sender, EventArgs e)
        {
            Limpa();
            CarregaGrid();
        }
        #endregion
    }
}

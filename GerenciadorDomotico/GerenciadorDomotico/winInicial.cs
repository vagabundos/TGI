using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Controle;

namespace GerenciadorDomotico
{
    public partial class winInicial : winBase
    {
        #region Propriedades

        Dictionary<string, string> ctlTelas;

        #endregion

        #region Construtores
        public winInicial()
        {
            InitializeComponent();
            this.tabCtrl.Visible = false;

            try
            {
                ConfiguraMenu(stpMenu);

                ToolStripMenuItem objMenuItem;
                ToolStripMenuItem objSubMenuItem;

                #region Telas
                // Cria dicionario de telas
                ctlTelas = new Dictionary<string, string>();

                ctlTelas.Add("Geral", "ctlConfiguradorGeral");
                ctlTelas.Add("Cadastro de Usuários", "ctlCadUsuario");
                ctlTelas.Add("Cadastro de Pisos", "ctlCadPiso");
                ctlTelas.Add("Cadastro de Dispositivos", "ctlCadDispositivos");
                ctlTelas.Add("Monitor", "ctlPainel");
                ctlTelas.Add("Logs", "ctlLogs");
                ctlTelas.Add("Trace de Comunicação", "ctlTraceComunicacao");

                #endregion

                #region Menu Operação
                objMenuItem = new ToolStripMenuItem("Operação");
                ConfiguraSubMenu(objMenuItem);
                stpMenu.Items.Add(objMenuItem);

                // Submenus
                objSubMenuItem = new ToolStripMenuItem("Monitor", null, mniRotina_Click);
                ConfiguraSubMenu(objSubMenuItem);
                objMenuItem.DropDown.Items.Add(objSubMenuItem);

                #endregion

                #region Menu Configurações
                objMenuItem = new ToolStripMenuItem("Configuração");
                ConfiguraSubMenu(objMenuItem);
                stpMenu.Items.Add(objMenuItem);

                // Submenus
                //objSubMenuItem = new ToolStripMenuItem("Cadastro de Usuários", null, mniRotina_Click);
                //ConfiguraSubMenu(objSubMenuItem);
                //objMenuItem.DropDown.Items.Add(objSubMenuItem);

                objSubMenuItem = new ToolStripMenuItem("Geral", null, mniRotina_Click);
                ConfiguraSubMenu(objSubMenuItem);
                objMenuItem.DropDown.Items.Add(objSubMenuItem);

                objSubMenuItem = new ToolStripMenuItem("Cadastro de Pisos", null, mniRotina_Click);
                ConfiguraSubMenu(objSubMenuItem);
                objMenuItem.DropDown.Items.Add(objSubMenuItem);

                objSubMenuItem = new ToolStripMenuItem("Cadastro de Dispositivos", null, mniRotina_Click);
                ConfiguraSubMenu(objSubMenuItem);
                objMenuItem.DropDown.Items.Add(objSubMenuItem);
                #endregion

                #region Menu Manutenção
                objMenuItem = new ToolStripMenuItem("Sistema");
                ConfiguraSubMenu(objMenuItem);
                stpMenu.Items.Add(objMenuItem);

                // Submenus
                objSubMenuItem = new ToolStripMenuItem("Logs", null, mniRotina_Click);
                ConfiguraSubMenu(objSubMenuItem);
                objMenuItem.DropDown.Items.Add(objSubMenuItem);

                objSubMenuItem = new ToolStripMenuItem("Trace de Comunicação", null, mniRotina_Click);
                ConfiguraSubMenu(objSubMenuItem);
                objMenuItem.DropDown.Items.Add(objSubMenuItem);
                #endregion
            }
            catch (Exception exc)
            {
                controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao carregar tela Inicial (winInicial())", exc);
            }
        }
        #endregion

        #region Métodos
        private void ConfiguraMenu(Control ctrl)
        {
            ctrl.ForeColor = System.Drawing.Color.White;
            ctrl.BackColor = System.Drawing.Color.DarkSeaGreen;
            ctrl.Font = new Font(ctrl.Font, FontStyle.Bold);
        }

        private void ConfiguraSubMenu(ToolStripItem ctrl)
        {
            ctrl.ForeColor = System.Drawing.Color.White;
            ctrl.BackColor = System.Drawing.Color.DarkSeaGreen;
            ctrl.Font = new Font(ctrl.Font, FontStyle.Bold);
        }

        #endregion

        #region Eventos
        private void mniRotina_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem objMenuItem = (ToolStripMenuItem)sender;
                if (!tabCtrl.TabPages.ContainsKey(objMenuItem.Text))
                {
                    Assembly currAssembly = Assembly.GetExecutingAssembly();
                    string ctl = currAssembly.GetName().Name + "." + ctlTelas[objMenuItem.Text];

                    // Carrega a tela selecionada via reflection
                    ctlBase ctrlCarregado = currAssembly.CreateInstance(ctl) as ctlBase;

                    // Proteção para tela não carregada
                    if (ctrlCarregado.IsDisposed)
                        return;

                    tabCtrl.TabPages.Add(objMenuItem.Text, objMenuItem.Text + "           ");
                    TabPage objTabPage = tabCtrl.TabPages[objMenuItem.Text];
                    tabCtrl.SelectTab(objTabPage);

                    this.tabCtrl.Visible = true;
                    objTabPage.Controls.Add(ctrlCarregado);
                    this.ActiveControl = ctrlCarregado;
                    this.ActiveControl.Focus();

                    // Aciona evento para fechar a aba quando fechar uma tela for fechada
                    ctrlCarregado.Disposed += new EventHandler(CloseTab);
                }
            }
            catch (Exception exc)
            {
                controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro ao abrir nova tela (mniRotina_Click.winInicial)", exc);
            }
        }

        private void CloseTab(object sender, EventArgs e)
        {
            this.tabCtrl.TabPages.RemoveAt(tabCtrl.SelectedIndex);

            if (tabCtrl.TabCount == 0)
                this.tabCtrl.Visible = false;
        }

        private void tabCtrl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
                e.Graphics.DrawString(this.tabCtrl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
                e.DrawFocusRectangle();
            }
            catch (Exception exc)
            {
                controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro na execução do evento (tabCtrl1_DrawItem.winInicial)", exc);
            }
        }

        private void tabCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                #region Fecha Aba pelo X
                //Looping through the controls.
                for (int i = 0; i < this.tabCtrl.TabPages.Count; i++)
                {
                    Rectangle r = this.tabCtrl.GetTabRect(i);
                    //Getting the position of the "x" mark.
                    Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                    if (closeButton.Contains(e.Location))
                    {
                        if (MessageBox.Show("Tem certeza que deseja fechar esta janela?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (this.tabCtrl.TabPages[i].Controls.Count > 0 && this.tabCtrl.TabPages[i].Controls[0] is ctlBase)
                            {
                                ctlBase ctrl = this.tabCtrl.TabPages[i].Controls[0] as ctlBase;
                                if (!ctrl.Fecha())
                                    return;
                            }
                        }
                    }
                }
                #endregion

                #region Trata Seleção da Aba
                TabPage objTabPage = this.tabCtrl.TabPages[tabCtrl.SelectedIndex];
                if (objTabPage.Controls.Count > 0 && objTabPage.Controls[0] is ctlBase)
                {
                    ctlBase ctlSelecionado = objTabPage.Controls[0] as ctlBase;
                    ctlSelecionado.SelecionaAba();
                }
                #endregion
            }
            catch (Exception exc)
            {
                controlLog.Insere(Biblioteca.Modelo.Log.LogTipo.Erro, "Erro na execução do evento (tabCtrl1_MouseDown.winInicial)", exc);
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            //stpMenu.ForeColor = System.Drawing.Color.White;
            //stpMenu.BackColor = System.Drawing.Color.Black;
            ConfiguraMenu(stpMenu);

			ToolStripMenuItem objMenuItem;
			ToolStripMenuItem objSubMenuItem;

            #region Telas
            // Cria dicionario de telas
            ctlTelas = new Dictionary<string, string>();

            ctlTelas.Add("Configurador Geral", "ctlConfiguradorGeral");
            ctlTelas.Add("Cadastro de Usuários", "ctlCadUsuario");
            ctlTelas.Add("Cadastro de Pisos", "ctlCadPiso");
            ctlTelas.Add("Cadastro de Dispositivos", "ctlCadDispositivos");
            ctlTelas.Add("Painel da Casa", "ctlPainel");
            ctlTelas.Add("Logs do Sistema", "ctlLogs");
            
            #endregion

            #region Menu Operação
            objMenuItem = new ToolStripMenuItem("Operação");
            ConfiguraSubMenu(objMenuItem);
            stpMenu.Items.Add(objMenuItem);

            // Submenus
            objSubMenuItem = new ToolStripMenuItem("Painel da Casa", null, mniRotina_Click);
            ConfiguraSubMenu(objSubMenuItem);
            objMenuItem.DropDown.Items.Add(objSubMenuItem);

            objSubMenuItem = new ToolStripMenuItem("Logs do Sistema", null, mniRotina_Click);
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

            objSubMenuItem = new ToolStripMenuItem("Configurador Geral", null, mniRotina_Click);
            ConfiguraSubMenu(objSubMenuItem);
            objMenuItem.DropDown.Items.Add(objSubMenuItem);

            objSubMenuItem = new ToolStripMenuItem("Cadastro de Pisos", null, mniRotina_Click);
            ConfiguraSubMenu(objSubMenuItem);
            objMenuItem.DropDown.Items.Add(objSubMenuItem);

            objSubMenuItem = new ToolStripMenuItem("Cadastro de Dispositivos", null, mniRotina_Click);
            ConfiguraSubMenu(objSubMenuItem);
            objMenuItem.DropDown.Items.Add(objSubMenuItem);
            #endregion
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
			ToolStripMenuItem objMenuItem = (ToolStripMenuItem)sender;
			if (!tabCtrl1.TabPages.ContainsKey(objMenuItem.Text))
			{
                string ctl = "GerenciadorDomotico." + ctlTelas[objMenuItem.Text];
				tabCtrl1.TabPages.Add(objMenuItem.Text, objMenuItem.Text);
                TabPage objTabPage = tabCtrl1.TabPages[objMenuItem.Text];
                tabCtrl1.SelectTab(objTabPage);

                // Carrega a tela selecionada via reflection
                ctlBase ctrlCarregado = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ctl) as ctlBase;

                objTabPage.Controls.Add(ctrlCarregado);
				this.ActiveControl = ctrlCarregado;
				this.ActiveControl.Focus();

                // Aciona evento para fechar a aba quando fechar uma tela for fechada
                ctrlCarregado.Disposed += new EventHandler(CloseTab);
			}
		}

        private void CloseTab(object sender, EventArgs e)
        {
            this.tabCtrl1.TabPages.RemoveAt(tabCtrl1.SelectedIndex);
        }

        private void tabCtrl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabCtrl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabCtrl1_MouseDown(object sender, MouseEventArgs e)
        {
            //Looping through the controls.
            for (int i = 0; i < this.tabCtrl1.TabPages.Count; i++)
            {
                Rectangle r = this.tabCtrl1.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Tem certeza que deseja fechar esta janela?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.tabCtrl1.TabPages[i].Controls.Count > 0 && this.tabCtrl1.TabPages[i].Controls[0] is ctlBase)
                        {
                            ctlBase ctrl = this.tabCtrl1.TabPages[i].Controls[0] as ctlBase;
                            if (!ctrl.Fecha())
                                return;
                        }
                    }
                }
            }
        }
        #endregion
    }
}

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
		public winInicial()
		{
			InitializeComponent();

            //stpMenu.ForeColor = System.Drawing.Color.White;
            //stpMenu.BackColor = System.Drawing.Color.Black;
            ConfiguraMenu(stpMenu);

			ToolStripMenuItem objMenuItem;
			ToolStripMenuItem objSubMenuItem;

			#region Menu Configurações
			objMenuItem = new ToolStripMenuItem("Configurações");
            ConfiguraSubMenu(objMenuItem);
			stpMenu.Items.Add(objMenuItem);

			// Submenus
			objSubMenuItem = new ToolStripMenuItem("Usuários", null, mniRotina_Click);
            ConfiguraSubMenu(objSubMenuItem);
			objMenuItem.DropDown.Items.Add(objSubMenuItem);

			objSubMenuItem = new ToolStripMenuItem("Cômodos", null, mniRotina_Click);
            ConfiguraSubMenu(objSubMenuItem);
			objMenuItem.DropDown.Items.Add(objSubMenuItem);
			#endregion

			//System.IO.Ports.SerialPort porta = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.Even, 8, System.IO.Ports.StopBits.None);
			//porta.Open();
		}

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
				tabCtrl1.TabPages.Add(objMenuItem.Text, objMenuItem.Text);
                TabPage objTabPage = tabCtrl1.TabPages[objMenuItem.Text];
                ctlBase ctrlCarregado = new ctlBase();
                objTabPage.Controls.Add(ctrlCarregado);
				this.ActiveControl = ctrlCarregado;
				this.ActiveControl.Focus();
			}
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
                        this.tabCtrl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        #endregion
    }
}

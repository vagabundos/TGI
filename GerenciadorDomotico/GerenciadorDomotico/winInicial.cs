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
			ToolStripMenuItem objMenuItem;
			ToolStripMenuItem objSubMenuItem;

			#region Menu Configurações
			objMenuItem = new ToolStripMenuItem("Configurações");
			stpMenu.Items.Add(objMenuItem);

			// Submenus
			objSubMenuItem = new ToolStripMenuItem("Usuários", null, mniRotina_Click);
			objMenuItem.DropDown.Items.Add(objSubMenuItem);
			objSubMenuItem = new ToolStripMenuItem("Cômodos", null, mniRotina_Click);
			objMenuItem.DropDown.Items.Add(objSubMenuItem);
			#endregion

			//System.IO.Ports.SerialPort porta = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.Even, 8, System.IO.Ports.StopBits.None);
			//porta.Open();
		}

		private void mniRotina_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem objMenuItem = (ToolStripMenuItem)sender;
			if (!tabCtrl1.TabPages.ContainsKey(objMenuItem.Text))
			{
				tabCtrl1.TabPages.Add(objMenuItem.Text, objMenuItem.Text);
				ctlBase ctrlCarregado = new ctlBase();
				tabCtrl1.TabPages[objMenuItem.Text].Controls.Add(ctrlCarregado);
				this.ActiveControl = ctrlCarregado;
				this.ActiveControl.Focus();
			}
		}
	}
}

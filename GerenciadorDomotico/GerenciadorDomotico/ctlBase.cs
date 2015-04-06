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
	public partial class ctlBase : UserControl
	{
		public ctlBase()
		{
			InitializeComponent();
		}

		#region Métodos
		public virtual bool Fecha()
		{
			this.Dispose(true);
			return true;
		}
		#endregion
	}
}

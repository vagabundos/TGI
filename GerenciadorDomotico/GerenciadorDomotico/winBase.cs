﻿using System;
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
	public partial class winBase : Form
	{
		#region Construtores
		public winBase()
		{
			InitializeComponent();
		}
		#endregion

		#region Métodos
		public virtual bool Fecha()
		{
			this.Dispose(true);
			return true;
		}
		#endregion
	}
}

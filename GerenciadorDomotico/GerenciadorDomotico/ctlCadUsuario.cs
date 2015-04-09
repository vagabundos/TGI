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
    public partial class ctlCadUsuario : ctlCadBase
    {
        public ctlCadUsuario()
        {
            InitializeComponent();
            
            btnApaga.Visible = true;
            btnAtivaInativa.Visible = true;
            btnCancela.Visible = true;
            btnEdita.Visible = true;
            btnFecha.Visible = true;
            btnNovo.Visible = true;
            btnSalva.Visible = true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Modelo;

namespace GerenciadorDomotico.Dispositivos
{
    public partial class ctlDispositivoDistancia : ctlDispositivoBase
    {
        #region Propriedades
        #endregion

        #region Construtores
        public ctlDispositivoDistancia()
        {
            InitializeComponent();
        }

        public ctlDispositivoDistancia(Dispositivo objDispModelo)
            : base(objDispModelo)
        {
        }
        #endregion

        #region Métodos
        protected override void ExibeControleDispositivo()
        {

        }
        #endregion

        #region Eventos
        #endregion
    }
}

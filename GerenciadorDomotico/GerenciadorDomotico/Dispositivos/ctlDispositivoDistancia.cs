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
            this.Size = new Size(60, 50);
        }
        #endregion

        #region Métodos
        protected override void MudaStatus()
        {
            if (string.IsNullOrEmpty(btnDisp.Text))
            {
                // Aplica a imagem no controle de temperatura, se ainda não foi aplicada
                Image imgDisp = imgList.Images[objDisp.Tipo.ToString()];
                this.SetImageButton(imgDisp);
            }

            // Seta imagem default e exibe o botão apenas como se fosse um panel para visualizar os dados
            btnDisp.Enabled = false;
            btnDisp.ImageAlign = ContentAlignment.TopCenter;
            btnDisp.TextAlign = ContentAlignment.BottomLeft;
            btnDisp.UseCompatibleTextRendering = true;
            btnDisp.Font = new Font(btnDisp.Font, FontStyle.Bold);

            // Exibe o valor no controle de temperatura
            btnDisp.Text = sValorDisp;
        }
        #endregion

        #region Eventos
        #endregion
    }
}

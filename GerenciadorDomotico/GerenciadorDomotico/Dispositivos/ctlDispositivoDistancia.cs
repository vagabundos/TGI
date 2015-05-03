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
            // Aplica a imagem no controle de temperatura, se ainda não foi aplicada
            if (btnDisp.BackgroundImage == null)
            {
                // Seta imagem default e exibe o botão apenas como se fosse um panel para visualizar os dados
                Image imgDisp = imgList.Images[objDisp.Tipo.ToString()];
                this.SetImageButton(imgDisp);
                btnDisp.Enabled = false;
                btnDisp.ImageAlign = ContentAlignment.TopCenter;
                btnDisp.TextAlign = ContentAlignment.BottomCenter;
                btnDisp.UseCompatibleTextRendering = true;
                btnDisp.Text = string.Empty;
                //btnDisp.Font = new Font(btnDisp.Font, FontStyle.Bold);
            }

            // Aplica o valor em outra variável, para não chamar o Web Service mais de uma vez
            string sValor = getValor(); //"0.42m";

            if (string.IsNullOrEmpty(sValor))
            {
                // To-Do: Disable do dispositivo, não está conectado ao servidor
                SetDisconnected();
                return;
            }

            // Exibe o valor no controle de temperatura
            btnDisp.Text = sValor;
        }
        #endregion

        #region Eventos
        #endregion
    }
}

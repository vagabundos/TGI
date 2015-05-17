﻿using System;
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
            this.Size = new Size(60, 40);
        }
        #endregion

        #region Métodos
        protected override void MudaStatus()
        {
            // Aplica a imagem no controle de temperatura, se ainda não foi aplicada
            if (btnDisp.BackgroundImage == null)
            {
                // Seta imagem default e exibe o botão apenas como se fosse um panel para visualizar os dados
                Image imgDisp = imgList.Images[objDisp.Tipo.ToString()];
                this.SetImageButton(imgDisp);
                btnDisp.Enabled = false;
                btnDisp.ImageAlign = ContentAlignment.TopCenter;
                btnDisp.TextAlign = ContentAlignment.BottomLeft;
                btnDisp.UseCompatibleTextRendering = true;
                btnDisp.Text = string.Empty;
                //btnDisp.Font = new Font(btnDisp.Font, FontStyle.Bold);
            }

            // Exibe o valor no controle de temperatura
            btnDisp.Text = sValorDisp;
        }
        #endregion

        #region Eventos
        #endregion
    }
}

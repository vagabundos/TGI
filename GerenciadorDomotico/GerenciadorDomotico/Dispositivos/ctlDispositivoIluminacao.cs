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
    public partial class ctlDispositivoIluminacao : ctlDispositivoBase
    {
        #region Propriedades
        #endregion

        #region Construtores
        public ctlDispositivoIluminacao()
        {
            InitializeComponent();
        }

        public ctlDispositivoIluminacao(Dispositivo objDispModelo)
            : base(objDispModelo)
        {
        }
        #endregion

        #region Métodos
        protected override void MudaStatus()
        {
            // Ativa botão
            btnDisp.Enabled = true;

            // Converte para valores esperados
            string sLampada = sValorDisp.Equals("1", StringComparison.CurrentCultureIgnoreCase) ? "ON" : "OFF";

            // Aplica imagem correspondente ao Status do dispositivo
            Image imgDisp = imgList.Images[objDisp.Tipo.ToString() + "_" + sLampada];

            // Insere a imagem no botão, se houver
            SetImageButton(imgDisp);
        }

        protected override void AcionaBotaoDisp()
        {
            string sNovoValor;

            // Altera o valor ON/OFF da Lampada
            if (sValorDisp.Equals("1"))
                sNovoValor = "0";
            else
                sNovoValor = "1";

            Envia(sNovoValor);
        }
        #endregion

        #region Eventos
        #endregion
    }
}

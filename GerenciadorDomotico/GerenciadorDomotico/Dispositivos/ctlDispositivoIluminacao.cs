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
        protected override void ExibeControleDispositivo()
        {
            string sValor = Valor;
            string sLampada = objDisp.Valor.Equals("1", StringComparison.CurrentCultureIgnoreCase) ? "ON" : "OFF";
            Image imgDisp = imgList.Images[objDisp.Tipo.ToString() + "_" + sLampada];

            // Insere a imagem no botão, se houver
            SetImageButton(imgDisp);
        }

        protected override void AcionaBotaoDisp()
        {
            base.AcionaBotaoDisp();

            // Altera o valor ON/OFF da Lampada
            if (objDisp.Valor.Equals("1"))
                objDisp.Valor = "0";
            else
                objDisp.Valor = "1";

            // Envia mensagem de requisição ao Controlador
            Envia();

            // Atualiza exibição do controle do Dispositivo
            ExibeControleDispositivo();
        }
        #endregion

        #region Eventos
        #endregion
    }
}

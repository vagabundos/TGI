using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Controle;
using Biblioteca.Modelo;
using Dados;
using GerenciadorDomotico.Dispositivos;

namespace GerenciadorDomotico
{
    public partial class ctlPainel : ctlBase
    {
        #region Propriedades
        private controlBase<Dispositivo> controleTela = new controlBase<Dispositivo>();
        private List<Piso> _lstPisos = null;
        private List<Dispositivo> _lstDispositivos;
        private Dictionary<ctlDispositivoBase, Point> _dicDispositivos = new Dictionary<ctlDispositivoBase,Point>();
        #endregion

        #region Construtores
        public ctlPainel()
            : base()
        {
            InitializeComponent();

            ConfiguraTela();
        }
        #endregion

        #region Métodos
        private void ConfiguraTela()
        {
            using (GerenciadorDB mngBD = new GerenciadorDB(false))
            {
                // Carrega pisos e configura ComboBox
                _lstPisos = new controlBase<Piso>().LoadTodos(mngBD);

                var CodigosPiso = from Piso objAux in _lstPisos
                                  select objAux.Codigo;

                cmbPiso.DropDownStyle = ComboBoxStyle.DropDownList;
                List<string> lstCodigosPiso = CodigosPiso.ToList();
                lstCodigosPiso.Insert(0, string.Empty);
                cmbPiso.DataSource = lstCodigosPiso;

                // Configura ComboBox Tipos
                //cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
                //List<string> lstTipos = Enum.GetNames(typeof(Dispositivo.TipoSensor)).ToList();
                //lstTipos.Insert(0, string.Empty);
                //cmbTipo.DataSource = lstTipos;
            }
        }

        private void CarregaImagemPisoSelecionado()
        {
            if (cmbPiso.SelectedValue != null && !string.IsNullOrEmpty(cmbPiso.SelectedValue.ToString()))
            {
                var auxPiso = from Piso objAux in _lstPisos
                              where objAux.Codigo == cmbPiso.SelectedValue.ToString()
                              select objAux;
                Piso objPisoSelecionado = auxPiso.First();

                if (objPisoSelecionado != null)
                {
                    // Carrega a imagem do Piso no PictureBox
                    imgPiso.Image = Biblioteca.Util.byteArrayToImage(objPisoSelecionado.Imagem);

                    using (GerenciadorDB mngBD = new GerenciadorDB(false))
                    {
                        // Carrega os Dispositivos associados ao Piso selecionado
                        _lstDispositivos = new controlBase<Dispositivo>().LoadTodos(mngBD);

                        var dispositivos = from Dispositivo objDisp in _lstDispositivos
                                           where objDisp.Piso == cmbPiso.SelectedValue.ToString()
                                           select objDisp;

                        _lstDispositivos = dispositivos.ToList();
                    }

                    // Carrega os dispositivos no Piso
                    _dicDispositivos.Clear();

                    foreach (Dispositivo disp in _lstDispositivos)
                    {
                        ctlDispositivoBase ctlDisp = FactoryControlDispositivo.getControleDispositivo(disp);
                        ctlDisp.PermiteArrastar(false);
                        ctlDisp.setPosicaoDispositivoNaImagem(disp.PosicaoX, disp.PosicaoY, imgPiso);
                        ctlDisp.Visible = true;

                        // Exibe o dispositivo na tela
                        imgPiso.Controls.Add(ctlDisp);
                        ctlDisp.BringToFront();

                        // Adiciona em um dicionario que deverá conter sempre os Dispositivos do Piso selecionado
                        Point pDisp = new Point(disp.PosicaoX, disp.PosicaoY);
                        _dicDispositivos.Add(ctlDisp, pDisp);
                    }
                }
            }
        }

        /// <summary>
        /// Limpa a imagem e os Dispositivos exibidos na tela
        /// </summary>
        private void Limpa()
        {
            foreach(KeyValuePair<ctlDispositivoBase, Point> pairDisp in _dicDispositivos)
            {
                pairDisp.Key.Visible = false;
                imgPiso.Controls.Remove(pairDisp.Key);
            }

            _dicDispositivos.Clear();
            imgPiso.Image = null;
        }

        private void RealocaDispositivos()
        {
            foreach (KeyValuePair<ctlDispositivoBase, Point> pairDisp in _dicDispositivos)
            {
                pairDisp.Key.setPosicaoDispositivoNaImagem(pairDisp.Value.X, pairDisp.Value.Y, imgPiso);
            }
        }
        #endregion

        #region Eventos
        private void btnFecha_Click(object sender, EventArgs e)
        {
            base.Fecha();
        }

        private void ctlPainel_Resize(object sender, EventArgs e)
        {
            pnlBotoes.Height = 42;
            Biblioteca.Util.AlinharBotoes(pnlBotoes);
            RealocaDispositivos();
        }

        private void cmbPiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpa();
            CarregaImagemPisoSelecionado();
        }

        private void splPanels_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RealocaDispositivos();
        }
        #endregion
    }
}

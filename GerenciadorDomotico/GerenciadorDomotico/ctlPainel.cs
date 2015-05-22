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

            Biblioteca.Comunicação.wsrvHomeOnClient WSclient = Biblioteca.Comunicação.wsrvHomeOnClient.getClient();
            bool bServicoAtivo = false;
            try
            {
                Dictionary<string, string> dicRetorno = null;
                string sMsgRetorno = null;
                WSclient.StatusDispositivos("", "", out dicRetorno, out sMsgRetorno);
                bServicoAtivo = true;
            }
            catch
            { }

            if (!bServicoAtivo)
            {
                MessageBox.Show("Não foi possível conectar ao Serviço para obter o STATUS dos Dispositivos.\r\nVerifique se o processo está ativo e/ou as configurações estão corretas.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

                this.Fecha();
                return;
            }

            ConfiguraTela();
            ActiveControl = cmbPiso;
            cmbPiso.Focus();
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
                        _lstDispositivos = new controlBase<Dispositivo>().LoadFiltro(mngBD, p => p.Piso == cmbPiso.SelectedValue.ToString());

                        // Carrega os dispositivos no Piso
                        foreach (Dispositivo disp in _lstDispositivos)
                        {
                            ctlDispositivoBase ctlDisp = FactoryControlDispositivo.getControleDispositivo(disp);
                            ctlDisp.PermiteArrastar(false);
                            ctlDisp.setPosicaoDispositivoNaImagem(disp.PosicaoX, disp.PosicaoY, imgPiso);
                            ctlDisp.Visible = true;
                            ctlDisp.AtivaTimerExibicao(true, 1000);

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
        }

        /// <summary>
        /// Limpa a imagem e os Dispositivos exibidos na tela
        /// </summary>
        private void Limpa()
        {
            foreach (KeyValuePair<ctlDispositivoBase, Point> pairDisp in _dicDispositivos)
            {
                imgPiso.Controls.Remove(pairDisp.Key);
                pairDisp.Key.Visible = false;
                pairDisp.Key.AtivaTimerExibicao(false, 1000);
                pairDisp.Key.Dispose();
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

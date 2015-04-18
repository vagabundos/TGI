using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;

namespace Biblioteca
{
    public class Util
    {
        #region Métodos
        public static void AlinharBotoes(Control painel)
        {
            int tamTotal = painel.ClientSize.Width;
            int tamBotoes = 0;
            SortedList<int, Control> botoes = new SortedList<int, Control>();
            foreach (Control c in painel.Controls)
            {
                if (c.Visible)
                {
                    tamBotoes += c.Width;
                    int pos = c.Left;
                    while (botoes.ContainsKey(pos))
                        pos++;
                    botoes.Add(pos, c);
                }
            }
            int espacamento = (tamTotal - tamBotoes) / (botoes.Keys.Count + 1);
            int ultimo = 0;
            foreach (Control c in botoes.Values)
            {
                c.Left = espacamento + ultimo;
                ultimo = c.Right;
            }
        }

        /// <summary>
        /// Converte uma imagem para o tipo Byte[]
        /// </summary>
        /// <param name="imagem">Imagem a ser convertida para o tipo Byte[]</param>
        /// <param name="formato">Formato atual da imagem</param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(Image imagem)
        {
            MemoryStream msImagem = new MemoryStream();
            imagem.Save(msImagem, imagem.RawFormat);
            return msImagem.ToArray();
        }
        #endregion
    }
}

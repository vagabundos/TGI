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
        public static byte[] ImageToByteArray(Image imagem)
        {
            if (imagem == null)
            {
                return null;
            }

            MemoryStream msImagem = new MemoryStream();
            imagem.Save(msImagem, imagem.RawFormat);
            return msImagem.ToArray();
        }

        /// <summary>
        /// Converte ByteArray para um objeto Image
        /// </summary>
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                return null;
            }

            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// Devolve texto SQL correspondente ao DBCommand
        /// </summary>
        public static string DevolveStringCommand(System.Data.Common.DbCommand dbCommand)
        {
            var query = dbCommand.CommandText;
            foreach (System.Data.Common.DbParameter parameter in dbCommand.Parameters)
            {
                query = query.Replace(parameter.ParameterName, parameter.Value.ToString());
            }

            return query;
        }

        /// <summary>
        /// Retorna a posição real de um objeto sobre a imagem a partir da posição relativa
        /// </summary>
        /// <param name="imgContainer">PictureBox com a imagem exibida em modo ZOOM</param>
        /// <param name="coordinates">Posição (Location) do objeto sobre a imagem</param>
        /// <returns></returns>
        public static Point TranslateZoomControlPosition(PictureBox imgContainer, Point coordinates)
        {
            // test to make sure our image is not null
            if (imgContainer.Image == null) return coordinates;

            // Make sure our control width and height are not 0 and our 
            // image width and height are not 0
            if (imgContainer.Width == 0 || imgContainer.Height == 0 || imgContainer.Image.Width == 0 || imgContainer.Image.Height == 0)
                return coordinates;

            // This is the one that gets a little tricky. Essentially, need to check 
            // the aspect ratio of the image to the aspect ratio of the control
            // to determine how it is being rendered
            float imageAspect = (float)imgContainer.Image.Width / imgContainer.Image.Height;
            float controlAspect = (float)imgContainer.Width / imgContainer.Height;
            float newX = coordinates.X;
            float newY = coordinates.Y;

            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, 
                // meaning the image fills up the entire control from left to right
                float ratioWidth = (float)imgContainer.Image.Width / imgContainer.Width;
                newX *= ratioWidth;
                float scale = (float)imgContainer.Width / imgContainer.Image.Width;
                float displayHeight = scale * imgContainer.Image.Height;
                float diffHeight = imgContainer.Height - displayHeight;
                diffHeight /= 2;
                newY -= diffHeight;
                newY /= scale;
            }
            else
            {
                // This means that we are limited by height, 
                // meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)imgContainer.Image.Height / imgContainer.Height;
                newY *= ratioHeight;
                float scale = (float)imgContainer.Height / imgContainer.Image.Height;
                float displayWidth = scale * imgContainer.Image.Width;
                float diffWidth = imgContainer.Width - displayWidth;
                diffWidth /= 2;
                newX -= diffWidth;
                newX /= scale;
            }

            return new Point((int)newX, (int)newY);
        }

        /// <summary>
        /// Devolve posição relativa do objeto em uma imagem exibida no PictureBox a partir das coordenadas da mesma imagem em tamanho real
        /// </summary>
        /// <param name="posicaoX">Posição X do controle na Imagem real</param>
        /// <param name="posicaoY">Posição Y do controle na Imagem real</param>
        /// <param name="imgContainer">PictureBox com a imagem exibida em modo ZOOM</param>
        public static Point TranslateControlPositionZoom(int posicaoX, int posicaoY, PictureBox imgContainer)
        {
            Point RelativeLocation = new Point(posicaoX, posicaoY);

            // test to make sure our image is not null
            if (imgContainer.Image == null)
                return RelativeLocation;

            // Make sure our control width and height are not 0 and our 
            // image width and height are not 0

            if (imgContainer.Width == 0 || imgContainer.Height == 0 || imgContainer.Image.Width == 0 || imgContainer.Image.Height == 0)
                return RelativeLocation;

            // This is the one that gets a little tricky. Essentially, need to check 
            // the aspect ratio of the image to the aspect ratio of the control
            // to determine how it is being rendered
            float imageAspect = (float)imgContainer.Image.Width / imgContainer.Image.Height;
            float controlAspect = (float)imgContainer.Width / imgContainer.Height;
            float newX, newY;

            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, 
                // meaning the image fills up the entire control from left to right
                float scale = (float)imgContainer.Width / imgContainer.Image.Width;
                float displayHeight = scale * imgContainer.Image.Height;
                float diffHeight = imgContainer.Height - displayHeight;
                diffHeight /= 2;
                newY = (posicaoY * scale) + diffHeight;
                newX = posicaoX * scale;
            }
            else
            {
                // This means that we are limited by height, 
                // meaning the image fills up the entire control from top to bottom
                float scale = (float)imgContainer.Height / imgContainer.Image.Height;
                float displayWidth = scale * imgContainer.Image.Width;
                float diffWidth = imgContainer.Width - displayWidth;
                diffWidth /= 2;
                newX = (posicaoX * scale) + diffWidth;
                newY = posicaoY * scale;
            }

            RelativeLocation = new Point((int)newX, (int)newY);
            return RelativeLocation;
        }
        #endregion
    }
}

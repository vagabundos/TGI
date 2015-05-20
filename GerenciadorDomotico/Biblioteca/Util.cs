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
using System.Xml;
using System.Reflection;
using Dados;
using System.Drawing.Drawing2D;

namespace Biblioteca
{
    public class Util
    {
        #region Métodos

        #region Métodos de Manipulação ao Windows Forms
        public static void AlinharBotoes(Control painel)
        {
            painel.Height = 42;
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
        #endregion

        #region Métodos de Manipulação de Imagens
        /// <summary>
        /// Retorna a posição real de um objeto sobre a imagem a partir da posição relativa
        /// </summary>
        /// <param name="imgContainer">PictureBox com a imagem exibida em modo ZOOM</param>
        /// <param name="coordinates">Posição (Location) do objeto sobre a imagem</param>
        /// <returns></returns>
        public static Point TranslateZoomControlPosition(PictureBox imgContainer, Point coordinates)
        {
            // test to make sure our image is not null
            if (imgContainer.Image == null) return new Point(0,0);

            // Make sure our control width and height are not 0 and our 
            // image width and height are not 0
            if (imgContainer.Width == 0 || imgContainer.Height == 0 || imgContainer.Image.Width == 0 || imgContainer.Image.Height == 0)
                return new Point(0,0);

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

            return new Point((int)newX+1, (int)newY+1);
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
        /// Altera o grau Alpha de transparência de uma imagem
        /// </summary>
        public static Image SetTransparenciaImagem(Image image, float opacity)
        {
            //Image image = imgList.Images["Generico"];
            var colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = opacity;
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            var output = new Bitmap(image.Width, image.Height);
            using (var gfx = Graphics.FromImage(output))
            {
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.DrawImage(
                    image,
                    new Rectangle(0, 0, image.Width, image.Height),
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes);
            }
            return output;
        }
        #endregion

        #region Métodos de Conexão com Banco de Dados
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
        /// Testa o Arquivo 'conexoes.xml' de Conexão ao Danco de Dados e grava os dados em memória enquanto o sistema estiver sendo executado
        /// </summary>
        /// <returns>Retorna se o teste da Conexão ao Banco de Dados funcionou ou não</returns>
        public static bool TestaArquivoConexao()
        {
            bool bSucesso = false;
            string sDiretorio = string.Empty;

            // Pega o Arquivo de Conexões
            sDiretorio = GetArquivoConexao();
            if (string.IsNullOrEmpty(sDiretorio))
                return false;

            // Faz a leitura do arquivo Xml
            XmlDocument xmlConexoes = new XmlDocument();
            xmlConexoes.Load(sDiretorio);

            // Pega o Server e Port especificados no arquivo para a conexão com o Banco de Dados
            XmlNode xmlDados = xmlConexoes.DocumentElement.SelectSingleNode("/Conexoes/Banco");

            // Seta os dados para as conexões a serem realizadas enquanto o sistema estiver sendo executado
            GerenciadorDB._Server = xmlDados["Server"].InnerText;
            GerenciadorDB._Port = xmlDados["Port"].InnerText;

            // Testa Conexão
            try
            {
                using (GerenciadorDB mngBD = new GerenciadorDB(false))
                {
                    bSucesso = true;
                }
            }
            catch (Exception exc)
            {
                // Se caiu aqui, a conexão não funcionou
                //using (FileStream fs = new FileStream("C:\\temp\\log.txt", FileMode.OpenOrCreate, FileAccess.Write))
                //{
                //    using (StreamWriter w = new StreamWriter(fs))
                //    {
                //        w.BaseStream.Seek(0, SeekOrigin.End);
                //        w.WriteLine(exc.ToString());
                //        w.Flush();
                //        w.Close();
                //    }

                //    fs.Close();
                //}
            }

            return bSucesso;
        }

        /// <summary>
        /// Pega o caminho completo do arquivo 'conexoes.xml' localizado no diretório de instalação do sistema
        /// </summary>
        public static string GetArquivoConexao()
        {
            string sDiretorio = string.Empty;

#if DEBUG
            // Pega diretório de trabalho
            sDiretorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conexoes.xml");
            //sDiretorio = Path.Combine(Assembly.GetExecutingAssembly().Location, "conexoes.xml");
#else
            sDiretorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conexoes.xml");
#endif
            // Verifica se o arquivo existe
            if (!File.Exists(sDiretorio))
                return string.Empty;

            return sDiretorio;
        }
        #endregion

        #region Métodos de Manipulação de Strings
        /// <summary>
        /// Devolve determinado 'Piece' pelo 'Separador' informado da 'String' de entrada
        /// </summary>
        public static string GetPiece(string sData, char cSeparador, int iPiece)
        {
            string sRetorno = string.Empty;

            string[] arrFlds = sData.Split(cSeparador);

            if (arrFlds.Length >= iPiece)
                sRetorno = arrFlds[iPiece - 1];

            return sRetorno;
        }

        /// <summary>
        /// Transforma uma string para ficar mais fácil de visualizar caracteres especiais para o usuário
        /// </summary>
        public static string TraduzCaracteresEspeciais(string sData)
        {
            string sRetorno = sData;

            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(0), "<NUL>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(1), "<SOH>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(2), "<STX>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(3), "<ETX>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(4), "<EOT>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(5), "<ENQ>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(6), "<ACK>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(7), "<BEL>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(8), "<BS>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(9), "<TAB>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(10), "<LF>"); sRetorno = sRetorno.Replace("\n", "<LF>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(11), "<VT>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(12), "<FF>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(13), "<CR>"); sRetorno = sRetorno.Replace("\r", "<CR>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(14), "<SO>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(15), "<SI>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(16), "<DLE>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(17), "<DC1>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(18), "<DC2>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(19), "<DC3>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(20), "<DC4>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(21), "<NAK>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(22), "<SYN>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(23), "<ETB>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(24), "<CAN>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(25), "<EM>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(26), "<SUB>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(27), "<ESC>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(28), "<FS>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(29), "<GS>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(30), "<RS>");
            sRetorno = sRetorno.Replace(Char.ConvertFromUtf32(31), "<US>");

            return sRetorno;
        }
        #endregion

        #endregion
    }
}

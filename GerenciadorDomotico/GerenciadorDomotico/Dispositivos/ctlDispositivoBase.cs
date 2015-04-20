using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDomotico.Dispositivos
{
    public partial class ctlDispositivoBase : UserControl
    {
        public ctlDispositivoBase()
        {
            InitializeComponent();
        }

        private Point MouseDownLocation;

        private void pnlDispositivo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        private void pnlDispositivo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        public void PosicionaImagem(int posicaoX, int posicaoY, PictureBox imgContainer)
        {
            // test to make sure our image is not null
            if (imgContainer.Image == null)
                return;

            // Make sure our control width and height are not 0 and our 
            // image width and height are not 0

            if (imgContainer.Width == 0 || imgContainer.Height == 0 || imgContainer.Image.Width == 0 || imgContainer.Image.Height == 0)
                return;

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

            this.Location = new Point((int)newX, (int)newY);
            return;
        }

        public Point TranslateZoomMousePosition(PictureBox imgContainer)
        {
            Point coordinates = this.Location;

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
    }
}

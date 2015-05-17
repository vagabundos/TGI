namespace GerenciadorDomotico.Dispositivos
{
    partial class ctlDispositivoIluminacao
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlDispositivoIluminacao));
            this.pnlDispositivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDispositivo
            // 
            this.pnlDispositivo.Size = new System.Drawing.Size(80, 80);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.Images.SetKeyName(0, "Iluminacao_OFF_OLD");
            this.imgList.Images.SetKeyName(1, "Iluminacao_ON_OLD");
            this.imgList.Images.SetKeyName(2, "Generico");
            this.imgList.Images.SetKeyName(3, "Temperatura");
            this.imgList.Images.SetKeyName(4, "Desconectado");
            this.imgList.Images.SetKeyName(5, "Umidade");
            this.imgList.Images.SetKeyName(6, "Distancia");
            this.imgList.Images.SetKeyName(7, "Iluminacao_ON");
            this.imgList.Images.SetKeyName(8, "Iluminacao_OFF");
            // 
            // btnDisp
            // 
            this.btnDisp.Size = new System.Drawing.Size(80, 80);
            // 
            // ctlDispositivoIluminacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctlDispositivoIluminacao";
            this.Size = new System.Drawing.Size(80, 80);
            this.pnlDispositivo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

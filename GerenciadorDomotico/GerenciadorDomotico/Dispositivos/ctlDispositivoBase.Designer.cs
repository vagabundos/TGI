namespace GerenciadorDomotico.Dispositivos
{
    partial class ctlDispositivoBase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlDispositivoBase));
            this.pnlDispositivo = new System.Windows.Forms.Panel();
            this.btnDisp = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.pnlDispositivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDispositivo
            // 
            this.pnlDispositivo.BackColor = System.Drawing.Color.Lime;
            this.pnlDispositivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDispositivo.Controls.Add(this.btnDisp);
            this.pnlDispositivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDispositivo.Location = new System.Drawing.Point(0, 0);
            this.pnlDispositivo.Name = "pnlDispositivo";
            this.pnlDispositivo.Size = new System.Drawing.Size(45, 45);
            this.pnlDispositivo.TabIndex = 1;
            this.pnlDispositivo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDispositivo_MouseDown);
            this.pnlDispositivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDispositivo_MouseMove);
            // 
            // btnDisp
            // 
            this.btnDisp.BackColor = System.Drawing.Color.Transparent;
            this.btnDisp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisp.Location = new System.Drawing.Point(0, 0);
            this.btnDisp.Margin = new System.Windows.Forms.Padding(30);
            this.btnDisp.Name = "btnDisp";
            this.btnDisp.Size = new System.Drawing.Size(45, 45);
            this.btnDisp.TabIndex = 0;
            this.btnDisp.UseVisualStyleBackColor = false;
            this.btnDisp.Visible = false;
            this.btnDisp.Click += new System.EventHandler(this.btnDisp_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "Iluminacao_OFF");
            this.imgList.Images.SetKeyName(1, "Iluminacao_ON");
            this.imgList.Images.SetKeyName(2, "Generico");
            this.imgList.Images.SetKeyName(3, "Temperatura");
            this.imgList.Images.SetKeyName(4, "Desconectado");
            this.imgList.Images.SetKeyName(5, "Umidade");
            this.imgList.Images.SetKeyName(6, "Distancia");
            // 
            // ctlDispositivoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlDispositivo);
            this.Name = "ctlDispositivoBase";
            this.Size = new System.Drawing.Size(45, 45);
            this.pnlDispositivo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlDispositivo;
        protected System.Windows.Forms.ImageList imgList;
        protected System.Windows.Forms.Button btnDisp;

    }
}

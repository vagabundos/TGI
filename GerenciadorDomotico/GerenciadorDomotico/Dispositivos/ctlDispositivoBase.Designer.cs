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
            this.pnlDispositivo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlDispositivo
            // 
            this.pnlDispositivo.BackColor = System.Drawing.Color.Lime;
            this.pnlDispositivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDispositivo.Location = new System.Drawing.Point(0, 0);
            this.pnlDispositivo.Name = "pnlDispositivo";
            this.pnlDispositivo.Size = new System.Drawing.Size(60, 60);
            this.pnlDispositivo.TabIndex = 1;
            this.pnlDispositivo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDispositivo_MouseDown);
            this.pnlDispositivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDispositivo_MouseMove);
            // 
            // ctlDispositivoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDispositivo);
            this.Name = "ctlDispositivoBase";
            this.Size = new System.Drawing.Size(60, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDispositivo;

    }
}

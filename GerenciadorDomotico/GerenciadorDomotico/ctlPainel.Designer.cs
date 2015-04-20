namespace GerenciadorDomotico
{
    partial class ctlPainel
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
            this.pnlTeste = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlTeste
            // 
            this.pnlTeste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeste.Location = new System.Drawing.Point(0, 0);
            this.pnlTeste.Name = "pnlTeste";
            this.pnlTeste.Size = new System.Drawing.Size(1450, 698);
            this.pnlTeste.TabIndex = 0;
            // 
            // ctlPainel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTeste);
            this.Name = "ctlPainel";
            this.Size = new System.Drawing.Size(1450, 698);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTeste;
    }
}

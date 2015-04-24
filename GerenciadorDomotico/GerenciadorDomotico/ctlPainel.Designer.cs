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
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnFecha = new System.Windows.Forms.Button();
            this.splPanels = new System.Windows.Forms.SplitContainer();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.lblPiso = new System.Windows.Forms.Label();
            this.cmbPiso = new System.Windows.Forms.ComboBox();
            this.grpImagem = new System.Windows.Forms.GroupBox();
            this.imgPiso = new System.Windows.Forms.PictureBox();
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splPanels)).BeginInit();
            this.splPanels.Panel1.SuspendLayout();
            this.splPanels.Panel2.SuspendLayout();
            this.splPanels.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.grpImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPiso)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnFecha);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 513);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1023, 42);
            this.pnlBotoes.TabIndex = 0;
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(474, 10);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(75, 23);
            this.btnFecha.TabIndex = 0;
            this.btnFecha.Text = "Fecha";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // splPanels
            // 
            this.splPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splPanels.Location = new System.Drawing.Point(0, 0);
            this.splPanels.Name = "splPanels";
            this.splPanels.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splPanels.Panel1
            // 
            this.splPanels.Panel1.Controls.Add(this.grpHeader);
            this.splPanels.Panel1MinSize = 0;
            // 
            // splPanels.Panel2
            // 
            this.splPanels.Panel2.Controls.Add(this.grpImagem);
            this.splPanels.Panel2MinSize = 350;
            this.splPanels.Size = new System.Drawing.Size(1023, 513);
            this.splPanels.SplitterDistance = 65;
            this.splPanels.TabIndex = 1;
            this.splPanels.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splPanels_SplitterMoved);
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblPiso);
            this.grpHeader.Controls.Add(this.cmbPiso);
            this.grpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHeader.Location = new System.Drawing.Point(0, 0);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1023, 65);
            this.grpHeader.TabIndex = 0;
            this.grpHeader.TabStop = false;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(6, 13);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(27, 13);
            this.lblPiso.TabIndex = 3;
            this.lblPiso.Text = "Piso";
            // 
            // cmbPiso
            // 
            this.cmbPiso.FormattingEnabled = true;
            this.cmbPiso.Location = new System.Drawing.Point(9, 29);
            this.cmbPiso.Name = "cmbPiso";
            this.cmbPiso.Size = new System.Drawing.Size(141, 21);
            this.cmbPiso.TabIndex = 2;
            this.cmbPiso.SelectedIndexChanged += new System.EventHandler(this.cmbPiso_SelectedIndexChanged);
            // 
            // grpImagem
            // 
            this.grpImagem.Controls.Add(this.imgPiso);
            this.grpImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImagem.Location = new System.Drawing.Point(0, 0);
            this.grpImagem.Name = "grpImagem";
            this.grpImagem.Size = new System.Drawing.Size(1023, 444);
            this.grpImagem.TabIndex = 0;
            this.grpImagem.TabStop = false;
            // 
            // imgPiso
            // 
            this.imgPiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPiso.Location = new System.Drawing.Point(3, 16);
            this.imgPiso.Name = "imgPiso";
            this.imgPiso.Size = new System.Drawing.Size(1017, 425);
            this.imgPiso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPiso.TabIndex = 1;
            this.imgPiso.TabStop = false;
            // 
            // ctlPainel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splPanels);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "ctlPainel";
            this.Size = new System.Drawing.Size(1023, 555);
            this.Resize += new System.EventHandler(this.ctlPainel_Resize);
            this.pnlBotoes.ResumeLayout(false);
            this.splPanels.Panel1.ResumeLayout(false);
            this.splPanels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splPanels)).EndInit();
            this.splPanels.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPiso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.SplitContainer splPanels;
        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.GroupBox grpImagem;
        private System.Windows.Forms.ComboBox cmbPiso;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.PictureBox imgPiso;

    }
}

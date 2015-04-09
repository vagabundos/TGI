namespace GerenciadorDomotico
{
    partial class ctlCadUsuario
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBotoes.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(884, 23);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(62, 23);
            // 
            // btnEdita
            // 
            this.btnEdita.Location = new System.Drawing.Point(199, 23);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(336, 23);
            // 
            // btnCancela
            // 
            this.btnCancela.Location = new System.Drawing.Point(473, 23);
            // 
            // btnAtivaInativa
            // 
            this.btnAtivaInativa.Location = new System.Drawing.Point(610, 23);
            // 
            // btnApaga
            // 
            this.btnApaga.Location = new System.Drawing.Point(747, 23);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.grpHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1023, 126);
            this.pnlHeader.TabIndex = 1;
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblCodigo);
            this.grpHeader.Controls.Add(this.txtCodigo);
            this.grpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHeader.Location = new System.Drawing.Point(0, 0);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1023, 126);
            this.grpHeader.TabIndex = 0;
            this.grpHeader.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Usuário";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(9, 32);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(136, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 126);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1023, 218);
            this.pnlMain.TabIndex = 2;
            // 
            // ctlCadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ctlCadUsuario";
            this.Controls.SetChildIndex(this.pnlBotoes, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
    }
}

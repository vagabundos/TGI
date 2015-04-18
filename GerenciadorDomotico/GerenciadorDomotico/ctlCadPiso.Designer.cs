namespace GerenciadorDomotico
{
    partial class ctlCadPiso
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
            this.grpGrid = new System.Windows.Forms.GroupBox();
            this.grdPiso = new System.Windows.Forms.DataGridView();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.lblImagem = new System.Windows.Forms.Label();
            this.txtDiretorio = new System.Windows.Forms.TextBox();
            this.btnDiretorio = new System.Windows.Forms.Button();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.grpImagem = new System.Windows.Forms.GroupBox();
            this.imgPlantaPiso = new System.Windows.Forms.PictureBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPiso)).BeginInit();
            this.grpHeader.SuspendLayout();
            this.grpImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlantaPiso)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(62, 11);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(199, 11);
            // 
            // btnEdita
            // 
            this.btnEdita.Location = new System.Drawing.Point(336, 11);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(473, 11);
            // 
            // btnCancela
            // 
            this.btnCancela.Location = new System.Drawing.Point(610, 11);
            // 
            // btnAtivaInativa
            // 
            this.btnAtivaInativa.Location = new System.Drawing.Point(747, 11);
            // 
            // btnApaga
            // 
            this.btnApaga.Location = new System.Drawing.Point(884, 11);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.grpGrid);
            this.pnlHeader.Controls.Add(this.grpHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1023, 124);
            this.pnlHeader.TabIndex = 1;
            // 
            // grpGrid
            // 
            this.grpGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGrid.Controls.Add(this.grdPiso);
            this.grpGrid.Location = new System.Drawing.Point(386, 0);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Size = new System.Drawing.Size(637, 124);
            this.grpGrid.TabIndex = 3;
            this.grpGrid.TabStop = false;
            // 
            // grdPiso
            // 
            this.grdPiso.AllowUserToAddRows = false;
            this.grdPiso.AllowUserToDeleteRows = false;
            this.grdPiso.AllowUserToResizeRows = false;
            this.grdPiso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPiso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPiso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPiso.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.grdPiso.Location = new System.Drawing.Point(3, 16);
            this.grdPiso.Name = "grdPiso";
            this.grdPiso.RowHeadersWidth = 20;
            this.grdPiso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPiso.Size = new System.Drawing.Size(631, 105);
            this.grdPiso.TabIndex = 3;
            this.grdPiso.SelectionChanged += new System.EventHandler(this.grdPiso_SelectionChanged);
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblImagem);
            this.grpHeader.Controls.Add(this.txtDiretorio);
            this.grpHeader.Controls.Add(this.btnDiretorio);
            this.grpHeader.Controls.Add(this.lblDescricao);
            this.grpHeader.Controls.Add(this.txtDescricao);
            this.grpHeader.Controls.Add(this.txtCodigo);
            this.grpHeader.Controls.Add(this.lblCodigo);
            this.grpHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpHeader.Location = new System.Drawing.Point(0, 0);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(386, 124);
            this.grpHeader.TabIndex = 2;
            this.grpHeader.TabStop = false;
            // 
            // lblImagem
            // 
            this.lblImagem.AutoSize = true;
            this.lblImagem.Location = new System.Drawing.Point(44, 60);
            this.lblImagem.Name = "lblImagem";
            this.lblImagem.Size = new System.Drawing.Size(101, 13);
            this.lblImagem.TabIndex = 6;
            this.lblImagem.Text = "Diretório da Imagem";
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiretorio.Location = new System.Drawing.Point(47, 76);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.ReadOnly = true;
            this.txtDiretorio.Size = new System.Drawing.Size(330, 20);
            this.txtDiretorio.TabIndex = 5;
            // 
            // btnDiretorio
            // 
            this.btnDiretorio.Location = new System.Drawing.Point(9, 73);
            this.btnDiretorio.Name = "btnDiretorio";
            this.btnDiretorio.Size = new System.Drawing.Size(25, 23);
            this.btnDiretorio.TabIndex = 4;
            this.btnDiretorio.Text = "...";
            this.btnDiretorio.UseVisualStyleBackColor = true;
            this.btnDiretorio.Click += new System.EventHandler(this.btnDiretorio_Click);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(128, 15);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 3;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(131, 31);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(246, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(9, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(116, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 15);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código";
            // 
            // grpImagem
            // 
            this.grpImagem.Controls.Add(this.imgPlantaPiso);
            this.grpImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImagem.Location = new System.Drawing.Point(0, 124);
            this.grpImagem.Name = "grpImagem";
            this.grpImagem.Size = new System.Drawing.Size(1023, 280);
            this.grpImagem.TabIndex = 2;
            this.grpImagem.TabStop = false;
            // 
            // imgPlantaPiso
            // 
            this.imgPlantaPiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPlantaPiso.Location = new System.Drawing.Point(3, 16);
            this.imgPlantaPiso.Name = "imgPlantaPiso";
            this.imgPlantaPiso.Size = new System.Drawing.Size(1017, 261);
            this.imgPlantaPiso.TabIndex = 0;
            this.imgPlantaPiso.TabStop = false;
            // 
            // ctlCadPiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpImagem);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ctlCadPiso";
            this.Controls.SetChildIndex(this.pnlBotoes, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.grpImagem, 0);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPiso)).EndInit();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlantaPiso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Button btnDiretorio;
        private System.Windows.Forms.TextBox txtDiretorio;
        private System.Windows.Forms.GroupBox grpImagem;
        private System.Windows.Forms.DataGridView grdPiso;
        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.PictureBox imgPlantaPiso;
        private System.Windows.Forms.Label lblImagem;
    }
}

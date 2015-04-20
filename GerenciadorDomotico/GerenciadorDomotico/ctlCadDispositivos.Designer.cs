namespace GerenciadorDomotico
{
    partial class ctlCadDispositivos
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
            this.grbGrid = new System.Windows.Forms.GroupBox();
            this.grdDispositivos = new System.Windows.Forms.DataGridView();
            this.grbDados = new System.Windows.Forms.GroupBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.cmbPiso = new System.Windows.Forms.ComboBox();
            this.pnlImagem = new System.Windows.Forms.Panel();
            this.imgPiso = new System.Windows.Forms.PictureBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDispositivos)).BeginInit();
            this.grbDados.SuspendLayout();
            this.pnlImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPiso)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Location = new System.Drawing.Point(3, -49);
            this.pnlBotoes.Size = new System.Drawing.Size(0, 46);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(-65, 11);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(-55, 11);
            // 
            // btnEdita
            // 
            this.btnEdita.Location = new System.Drawing.Point(-45, 11);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(-35, 11);
            // 
            // btnCancela
            // 
            this.btnCancela.Location = new System.Drawing.Point(-25, 11);
            // 
            // btnAtivaInativa
            // 
            this.btnAtivaInativa.Location = new System.Drawing.Point(-15, 11);
            // 
            // btnApaga
            // 
            this.btnApaga.Location = new System.Drawing.Point(-5, 11);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.grbGrid);
            this.pnlHeader.Controls.Add(this.grbDados);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(3);
            this.pnlHeader.Size = new System.Drawing.Size(0, 150);
            this.pnlHeader.TabIndex = 1;
            // 
            // grbGrid
            // 
            this.grbGrid.Controls.Add(this.grdDispositivos);
            this.grbGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGrid.Location = new System.Drawing.Point(318, 3);
            this.grbGrid.Name = "grbGrid";
            this.grbGrid.Size = new System.Drawing.Size(0, 144);
            this.grbGrid.TabIndex = 2;
            this.grbGrid.TabStop = false;
            // 
            // grdDispositivos
            // 
            this.grdDispositivos.AllowUserToAddRows = false;
            this.grdDispositivos.AllowUserToDeleteRows = false;
            this.grdDispositivos.AllowUserToResizeRows = false;
            this.grdDispositivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdDispositivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDispositivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDispositivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdDispositivos.Location = new System.Drawing.Point(3, 16);
            this.grdDispositivos.MultiSelect = false;
            this.grdDispositivos.Name = "grdDispositivos";
            this.grdDispositivos.RowHeadersWidth = 20;
            this.grdDispositivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDispositivos.Size = new System.Drawing.Size(0, 125);
            this.grdDispositivos.TabIndex = 0;
            this.grdDispositivos.SelectionChanged += new System.EventHandler(this.grdDispositivo_SelectionChanged);
            // 
            // grbDados
            // 
            this.grbDados.Controls.Add(this.cmbTipo);
            this.grbDados.Controls.Add(this.lblTipo);
            this.grbDados.Controls.Add(this.lblDescricao);
            this.grbDados.Controls.Add(this.txtDescricao);
            this.grbDados.Controls.Add(this.txtCodigo);
            this.grbDados.Controls.Add(this.lblCodigo);
            this.grbDados.Controls.Add(this.lblPiso);
            this.grbDados.Controls.Add(this.cmbPiso);
            this.grbDados.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbDados.Location = new System.Drawing.Point(3, 3);
            this.grbDados.Name = "grbDados";
            this.grbDados.Size = new System.Drawing.Size(315, 144);
            this.grbDados.TabIndex = 1;
            this.grbDados.TabStop = false;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(7, 109);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 8;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(4, 93);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(4, 54);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 6;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(7, 70);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(302, 20);
            this.txtDescricao.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(158, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(151, 20);
            this.txtCodigo.TabIndex = 4;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(155, 14);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código";
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(4, 14);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(27, 13);
            this.lblPiso.TabIndex = 2;
            this.lblPiso.Text = "Piso";
            // 
            // cmbPiso
            // 
            this.cmbPiso.FormattingEnabled = true;
            this.cmbPiso.Location = new System.Drawing.Point(7, 30);
            this.cmbPiso.Name = "cmbPiso";
            this.cmbPiso.Size = new System.Drawing.Size(141, 21);
            this.cmbPiso.TabIndex = 1;
            this.cmbPiso.SelectedIndexChanged += new System.EventHandler(this.cmbPiso_SelectedIndexChanged);
            // 
            // pnlImagem
            // 
            this.pnlImagem.Controls.Add(this.imgPiso);
            this.pnlImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagem.Location = new System.Drawing.Point(3, 153);
            this.pnlImagem.Name = "pnlImagem";
            this.pnlImagem.Padding = new System.Windows.Forms.Padding(3);
            this.pnlImagem.Size = new System.Drawing.Size(0, 0);
            this.pnlImagem.TabIndex = 2;
            // 
            // imgPiso
            // 
            this.imgPiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPiso.Location = new System.Drawing.Point(3, 3);
            this.imgPiso.Name = "imgPiso";
            this.imgPiso.Size = new System.Drawing.Size(0, 0);
            this.imgPiso.TabIndex = 0;
            this.imgPiso.TabStop = false;
            // 
            // ctlCadDispositivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlImagem);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ctlCadDispositivos";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(0, 0);
            this.Controls.SetChildIndex(this.pnlBotoes, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlImagem, 0);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grbGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDispositivos)).EndInit();
            this.grbDados.ResumeLayout(false);
            this.grbDados.PerformLayout();
            this.pnlImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPiso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.GroupBox grbGrid;
        private System.Windows.Forms.DataGridView grdDispositivos;
        private System.Windows.Forms.GroupBox grbDados;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.ComboBox cmbPiso;
        private System.Windows.Forms.Panel pnlImagem;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.PictureBox imgPiso;
    }
}

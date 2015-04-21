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
            this.lblCodControlador = new System.Windows.Forms.Label();
            this.txtCodControlador = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.cmbPiso = new System.Windows.Forms.ComboBox();
            this.pnlImagem = new System.Windows.Forms.Panel();
            this.grpImagem = new System.Windows.Forms.GroupBox();
            this.imgPiso = new System.Windows.Forms.PictureBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDispositivos)).BeginInit();
            this.grbDados.SuspendLayout();
            this.pnlImagem.SuspendLayout();
            this.grpImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPiso)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Location = new System.Drawing.Point(0, 510);
            this.pnlBotoes.Size = new System.Drawing.Size(1023, 45);
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
            this.pnlHeader.Controls.Add(this.grbGrid);
            this.pnlHeader.Controls.Add(this.grbDados);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1023, 150);
            this.pnlHeader.TabIndex = 1;
            // 
            // grbGrid
            // 
            this.grbGrid.Controls.Add(this.grdDispositivos);
            this.grbGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGrid.Location = new System.Drawing.Point(315, 0);
            this.grbGrid.Name = "grbGrid";
            this.grbGrid.Size = new System.Drawing.Size(708, 150);
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
            this.grdDispositivos.Size = new System.Drawing.Size(702, 131);
            this.grdDispositivos.TabIndex = 0;
            this.grdDispositivos.SelectionChanged += new System.EventHandler(this.grdDispositivo_SelectionChanged);
            // 
            // grbDados
            // 
            this.grbDados.Controls.Add(this.lblCodControlador);
            this.grbDados.Controls.Add(this.txtCodControlador);
            this.grbDados.Controls.Add(this.cmbTipo);
            this.grbDados.Controls.Add(this.lblTipo);
            this.grbDados.Controls.Add(this.lblDescricao);
            this.grbDados.Controls.Add(this.txtDescricao);
            this.grbDados.Controls.Add(this.txtCodigo);
            this.grbDados.Controls.Add(this.lblCodigo);
            this.grbDados.Controls.Add(this.lblPiso);
            this.grbDados.Controls.Add(this.cmbPiso);
            this.grbDados.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbDados.Location = new System.Drawing.Point(0, 0);
            this.grbDados.Name = "grbDados";
            this.grbDados.Size = new System.Drawing.Size(315, 150);
            this.grbDados.TabIndex = 1;
            this.grbDados.TabStop = false;
            // 
            // lblCodControlador
            // 
            this.lblCodControlador.AutoSize = true;
            this.lblCodControlador.Location = new System.Drawing.Point(155, 94);
            this.lblCodControlador.Name = "lblCodControlador";
            this.lblCodControlador.Size = new System.Drawing.Size(97, 13);
            this.lblCodControlador.TabIndex = 10;
            this.lblCodControlador.Text = "Código Controlador";
            // 
            // txtCodControlador
            // 
            this.txtCodControlador.Location = new System.Drawing.Point(158, 110);
            this.txtCodControlador.Name = "txtCodControlador";
            this.txtCodControlador.Size = new System.Drawing.Size(151, 20);
            this.txtCodControlador.TabIndex = 9;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(7, 110);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(141, 21);
            this.cmbTipo.TabIndex = 8;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(4, 94);
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
            this.pnlImagem.Controls.Add(this.grpImagem);
            this.pnlImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagem.Location = new System.Drawing.Point(0, 150);
            this.pnlImagem.Name = "pnlImagem";
            this.pnlImagem.Size = new System.Drawing.Size(1023, 360);
            this.pnlImagem.TabIndex = 2;
            // 
            // grpImagem
            // 
            this.grpImagem.Controls.Add(this.imgPiso);
            this.grpImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImagem.Location = new System.Drawing.Point(0, 0);
            this.grpImagem.Name = "grpImagem";
            this.grpImagem.Size = new System.Drawing.Size(1023, 360);
            this.grpImagem.TabIndex = 0;
            this.grpImagem.TabStop = false;
            // 
            // imgPiso
            // 
            this.imgPiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPiso.Location = new System.Drawing.Point(3, 16);
            this.imgPiso.Name = "imgPiso";
            this.imgPiso.Size = new System.Drawing.Size(1017, 341);
            this.imgPiso.TabIndex = 0;
            this.imgPiso.TabStop = false;
            this.imgPiso.MouseLeave += new System.EventHandler(this.imgPiso_MouseLeave);
            // 
            // ctlCadDispositivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlImagem);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ctlCadDispositivos";
            this.Size = new System.Drawing.Size(1023, 555);
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
            this.grpImagem.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpImagem;
        private System.Windows.Forms.Label lblCodControlador;
        private System.Windows.Forms.TextBox txtCodControlador;
    }
}

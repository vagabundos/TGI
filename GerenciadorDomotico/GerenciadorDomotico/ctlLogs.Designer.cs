namespace GerenciadorDomotico
{
    partial class ctlLogs
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
            this.grbHeader = new System.Windows.Forms.GroupBox();
            this.numMaximoLinhas = new System.Windows.Forms.NumericUpDown();
            this.lblMaximoLinhas = new System.Windows.Forms.Label();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.btnExibe = new System.Windows.Forms.Button();
            this.lblDataFim = new System.Windows.Forms.Label();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.grbTiposLog = new System.Windows.Forms.GroupBox();
            this.chkTiposLog = new System.Windows.Forms.CheckedListBox();
            this.lblOcorrencia = new System.Windows.Forms.Label();
            this.txtOcorrencia = new System.Windows.Forms.TextBox();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.grbGridLogs = new System.Windows.Forms.GroupBox();
            this.grdLogs = new System.Windows.Forms.DataGridView();
            this.grbDetalhesLog = new System.Windows.Forms.GroupBox();
            this.txtDetalhes = new System.Windows.Forms.RichTextBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximoLinhas)).BeginInit();
            this.grbTiposLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.grbGridLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            this.grbDetalhesLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Location = new System.Drawing.Point(0, 604);
            this.pnlBotoes.Size = new System.Drawing.Size(1373, 42);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(106, 11);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(287, 11);
            // 
            // btnEdita
            // 
            this.btnEdita.Location = new System.Drawing.Point(468, 11);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(649, 11);
            // 
            // btnCancela
            // 
            this.btnCancela.Location = new System.Drawing.Point(830, 11);
            // 
            // btnAtivaInativa
            // 
            this.btnAtivaInativa.Location = new System.Drawing.Point(1011, 11);
            // 
            // btnApaga
            // 
            this.btnApaga.Location = new System.Drawing.Point(1192, 11);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.grbHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1373, 110);
            this.pnlHeader.TabIndex = 0;
            // 
            // grbHeader
            // 
            this.grbHeader.Controls.Add(this.numMaximoLinhas);
            this.grbHeader.Controls.Add(this.lblMaximoLinhas);
            this.grbHeader.Controls.Add(this.dtFinal);
            this.grbHeader.Controls.Add(this.btnExibe);
            this.grbHeader.Controls.Add(this.lblDataFim);
            this.grbHeader.Controls.Add(this.lblDataInicio);
            this.grbHeader.Controls.Add(this.dtInicio);
            this.grbHeader.Controls.Add(this.grbTiposLog);
            this.grbHeader.Controls.Add(this.lblOcorrencia);
            this.grbHeader.Controls.Add(this.txtOcorrencia);
            this.grbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbHeader.Location = new System.Drawing.Point(0, 0);
            this.grbHeader.Name = "grbHeader";
            this.grbHeader.Size = new System.Drawing.Size(1373, 110);
            this.grbHeader.TabIndex = 0;
            this.grbHeader.TabStop = false;
            // 
            // numMaximoLinhas
            // 
            this.numMaximoLinhas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaximoLinhas.Location = new System.Drawing.Point(1292, 48);
            this.numMaximoLinhas.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaximoLinhas.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaximoLinhas.Name = "numMaximoLinhas";
            this.numMaximoLinhas.Size = new System.Drawing.Size(74, 20);
            this.numMaximoLinhas.TabIndex = 17;
            this.numMaximoLinhas.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblMaximoLinhas
            // 
            this.lblMaximoLinhas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaximoLinhas.AutoSize = true;
            this.lblMaximoLinhas.Location = new System.Drawing.Point(1289, 32);
            this.lblMaximoLinhas.Name = "lblMaximoLinhas";
            this.lblMaximoLinhas.Size = new System.Drawing.Size(77, 13);
            this.lblMaximoLinhas.TabIndex = 16;
            this.lblMaximoLinhas.Text = "Máximo Linhas";
            // 
            // dtFinal
            // 
            this.dtFinal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinal.Location = new System.Drawing.Point(389, 77);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(143, 20);
            this.dtFinal.TabIndex = 8;
            this.dtFinal.Value = new System.DateTime(2015, 5, 3, 0, 16, 37, 0);
            // 
            // btnExibe
            // 
            this.btnExibe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExibe.Location = new System.Drawing.Point(1292, 78);
            this.btnExibe.Name = "btnExibe";
            this.btnExibe.Size = new System.Drawing.Size(75, 23);
            this.btnExibe.TabIndex = 9;
            this.btnExibe.Text = "&Exibe";
            this.btnExibe.UseVisualStyleBackColor = true;
            this.btnExibe.Click += new System.EventHandler(this.btnExibe_Click);
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Location = new System.Drawing.Point(386, 61);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(55, 13);
            this.lblDataFim.TabIndex = 7;
            this.lblDataFim.Text = "Data Final";
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(386, 22);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(60, 13);
            this.lblDataInicio.TabIndex = 6;
            this.lblDataInicio.Text = "Data Início";
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtInicio.Location = new System.Drawing.Point(389, 38);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(143, 20);
            this.dtInicio.TabIndex = 5;
            // 
            // grbTiposLog
            // 
            this.grbTiposLog.Controls.Add(this.chkTiposLog);
            this.grbTiposLog.Location = new System.Drawing.Point(143, 16);
            this.grbTiposLog.Name = "grbTiposLog";
            this.grbTiposLog.Size = new System.Drawing.Size(237, 85);
            this.grbTiposLog.TabIndex = 4;
            this.grbTiposLog.TabStop = false;
            this.grbTiposLog.Text = "Tipos de Log";
            // 
            // chkTiposLog
            // 
            this.chkTiposLog.CheckOnClick = true;
            this.chkTiposLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTiposLog.FormattingEnabled = true;
            this.chkTiposLog.Location = new System.Drawing.Point(3, 16);
            this.chkTiposLog.Name = "chkTiposLog";
            this.chkTiposLog.Size = new System.Drawing.Size(231, 66);
            this.chkTiposLog.TabIndex = 2;
            // 
            // lblOcorrencia
            // 
            this.lblOcorrencia.AutoSize = true;
            this.lblOcorrencia.Location = new System.Drawing.Point(6, 16);
            this.lblOcorrencia.Name = "lblOcorrencia";
            this.lblOcorrencia.Size = new System.Drawing.Size(88, 13);
            this.lblOcorrencia.TabIndex = 1;
            this.lblOcorrencia.Text = "ID da Ocorrência";
            // 
            // txtOcorrencia
            // 
            this.txtOcorrencia.Location = new System.Drawing.Point(9, 32);
            this.txtOcorrencia.Name = "txtOcorrencia";
            this.txtOcorrencia.Size = new System.Drawing.Size(128, 20);
            this.txtOcorrencia.TabIndex = 0;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 110);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.grbGridLogs);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.grbDetalhesLog);
            this.spcMain.Size = new System.Drawing.Size(1373, 494);
            this.spcMain.SplitterDistance = 383;
            this.spcMain.TabIndex = 1;
            // 
            // grbGridLogs
            // 
            this.grbGridLogs.Controls.Add(this.grdLogs);
            this.grbGridLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGridLogs.Location = new System.Drawing.Point(0, 0);
            this.grbGridLogs.Name = "grbGridLogs";
            this.grbGridLogs.Size = new System.Drawing.Size(1373, 383);
            this.grbGridLogs.TabIndex = 0;
            this.grbGridLogs.TabStop = false;
            this.grbGridLogs.Text = "Logs do Sistema";
            // 
            // grdLogs
            // 
            this.grdLogs.AllowUserToAddRows = false;
            this.grdLogs.AllowUserToDeleteRows = false;
            this.grdLogs.AllowUserToOrderColumns = true;
            this.grdLogs.AllowUserToResizeRows = false;
            this.grdLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLogs.Location = new System.Drawing.Point(3, 16);
            this.grdLogs.MultiSelect = false;
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.RowHeadersWidth = 20;
            this.grdLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLogs.Size = new System.Drawing.Size(1367, 364);
            this.grdLogs.TabIndex = 0;
            this.grdLogs.SelectionChanged += new System.EventHandler(this.grdLogs_SelectionChanged);
            // 
            // grbDetalhesLog
            // 
            this.grbDetalhesLog.Controls.Add(this.txtDetalhes);
            this.grbDetalhesLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDetalhesLog.Location = new System.Drawing.Point(0, 0);
            this.grbDetalhesLog.Name = "grbDetalhesLog";
            this.grbDetalhesLog.Size = new System.Drawing.Size(1373, 107);
            this.grbDetalhesLog.TabIndex = 0;
            this.grbDetalhesLog.TabStop = false;
            this.grbDetalhesLog.Text = "Detalhamento do Log";
            // 
            // txtDetalhes
            // 
            this.txtDetalhes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetalhes.Location = new System.Drawing.Point(3, 16);
            this.txtDetalhes.Name = "txtDetalhes";
            this.txtDetalhes.ReadOnly = true;
            this.txtDetalhes.Size = new System.Drawing.Size(1367, 88);
            this.txtDetalhes.TabIndex = 0;
            this.txtDetalhes.Text = "";
            // 
            // ctlLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ctlLogs";
            this.Size = new System.Drawing.Size(1373, 646);
            this.Resize += new System.EventHandler(this.ctlLogs_Resize);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlBotoes, 0);
            this.Controls.SetChildIndex(this.spcMain, 0);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grbHeader.ResumeLayout(false);
            this.grbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximoLinhas)).EndInit();
            this.grbTiposLog.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.grbGridLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            this.grbDetalhesLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.GroupBox grbGridLogs;
        private System.Windows.Forms.GroupBox grbDetalhesLog;
        private System.Windows.Forms.GroupBox grbHeader;
        private System.Windows.Forms.Label lblOcorrencia;
        private System.Windows.Forms.TextBox txtOcorrencia;
        private System.Windows.Forms.CheckedListBox chkTiposLog;
        private System.Windows.Forms.GroupBox grbTiposLog;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.RichTextBox txtDetalhes;
        private System.Windows.Forms.DataGridView grdLogs;
        private System.Windows.Forms.Button btnExibe;
        private System.Windows.Forms.NumericUpDown numMaximoLinhas;
        private System.Windows.Forms.Label lblMaximoLinhas;
    }
}

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
            this.pnlBotoes.Location = new System.Drawing.Point(0, 514);
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
            this.pnlHeader.Controls.Add(this.grbHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1023, 110);
            this.pnlHeader.TabIndex = 0;
            // 
            // grbHeader
            // 
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
            this.grbHeader.Size = new System.Drawing.Size(1023, 110);
            this.grbHeader.TabIndex = 0;
            this.grbHeader.TabStop = false;
            // 
            // dtFinal
            // 
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFinal.Location = new System.Drawing.Point(389, 77);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(109, 20);
            this.dtFinal.TabIndex = 8;
            this.dtFinal.Value = new System.DateTime(2015, 5, 3, 0, 16, 37, 0);
            // 
            // btnExibe
            // 
            this.btnExibe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExibe.Location = new System.Drawing.Point(942, 78);
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
            this.dtInicio.CustomFormat = "";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtInicio.Location = new System.Drawing.Point(389, 38);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(109, 20);
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
            this.spcMain.Size = new System.Drawing.Size(1023, 404);
            this.spcMain.SplitterDistance = 314;
            this.spcMain.TabIndex = 1;
            // 
            // grbGridLogs
            // 
            this.grbGridLogs.Controls.Add(this.grdLogs);
            this.grbGridLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGridLogs.Location = new System.Drawing.Point(0, 0);
            this.grbGridLogs.Name = "grbGridLogs";
            this.grbGridLogs.Size = new System.Drawing.Size(1023, 314);
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
            this.grdLogs.Size = new System.Drawing.Size(1017, 295);
            this.grdLogs.TabIndex = 0;
            this.grdLogs.SelectionChanged += new System.EventHandler(this.grdLogs_SelectionChanged);
            // 
            // grbDetalhesLog
            // 
            this.grbDetalhesLog.Controls.Add(this.txtDetalhes);
            this.grbDetalhesLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDetalhesLog.Location = new System.Drawing.Point(0, 0);
            this.grbDetalhesLog.Name = "grbDetalhesLog";
            this.grbDetalhesLog.Size = new System.Drawing.Size(1023, 86);
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
            this.txtDetalhes.Size = new System.Drawing.Size(1017, 67);
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
            this.Size = new System.Drawing.Size(1023, 556);
            this.Resize += new System.EventHandler(this.ctlLogs_Resize);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlBotoes, 0);
            this.Controls.SetChildIndex(this.spcMain, 0);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grbHeader.ResumeLayout(false);
            this.grbHeader.PerformLayout();
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
    }
}

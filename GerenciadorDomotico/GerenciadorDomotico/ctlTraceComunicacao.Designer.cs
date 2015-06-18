namespace GerenciadorDomotico
{
    partial class ctlTraceComunicacao
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
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.lblControlador = new System.Windows.Forms.Label();
            this.txtDispositivo = new System.Windows.Forms.TextBox();
            this.txtControlador = new System.Windows.Forms.TextBox();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.btnExibe = new System.Windows.Forms.Button();
            this.lblDataFim = new System.Windows.Forms.Label();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.grbProcedenciaTrace = new System.Windows.Forms.GroupBox();
            this.chkProcedenciaTrace = new System.Windows.Forms.CheckedListBox();
            this.lblOcorrencia = new System.Windows.Forms.Label();
            this.txtOcorrencia = new System.Windows.Forms.TextBox();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.grbGridTrace = new System.Windows.Forms.GroupBox();
            this.grdTraceOcorrencias = new System.Windows.Forms.DataGridView();
            this.grbMensagemTrace = new System.Windows.Forms.GroupBox();
            this.txtMensagem = new System.Windows.Forms.RichTextBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximoLinhas)).BeginInit();
            this.grbProcedenciaTrace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.grbGridTrace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTraceOcorrencias)).BeginInit();
            this.grbMensagemTrace.SuspendLayout();
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
            this.grbHeader.Controls.Add(this.lblDispositivo);
            this.grbHeader.Controls.Add(this.lblControlador);
            this.grbHeader.Controls.Add(this.txtDispositivo);
            this.grbHeader.Controls.Add(this.txtControlador);
            this.grbHeader.Controls.Add(this.dtFinal);
            this.grbHeader.Controls.Add(this.btnExibe);
            this.grbHeader.Controls.Add(this.lblDataFim);
            this.grbHeader.Controls.Add(this.lblDataInicio);
            this.grbHeader.Controls.Add(this.dtInicio);
            this.grbHeader.Controls.Add(this.grbProcedenciaTrace);
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
            this.numMaximoLinhas.Location = new System.Drawing.Point(1293, 42);
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
            this.numMaximoLinhas.TabIndex = 15;
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
            this.lblMaximoLinhas.Location = new System.Drawing.Point(1289, 22);
            this.lblMaximoLinhas.Name = "lblMaximoLinhas";
            this.lblMaximoLinhas.Size = new System.Drawing.Size(77, 13);
            this.lblMaximoLinhas.TabIndex = 14;
            this.lblMaximoLinhas.Text = "Máximo Linhas";
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.AutoSize = true;
            this.lblDispositivo.Location = new System.Drawing.Point(386, 61);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(58, 13);
            this.lblDispositivo.TabIndex = 13;
            this.lblDispositivo.Text = "Dispositivo";
            // 
            // lblControlador
            // 
            this.lblControlador.AutoSize = true;
            this.lblControlador.Location = new System.Drawing.Point(386, 22);
            this.lblControlador.Name = "lblControlador";
            this.lblControlador.Size = new System.Drawing.Size(61, 13);
            this.lblControlador.TabIndex = 12;
            this.lblControlador.Text = "Controlador";
            // 
            // txtDispositivo
            // 
            this.txtDispositivo.Location = new System.Drawing.Point(389, 77);
            this.txtDispositivo.Name = "txtDispositivo";
            this.txtDispositivo.Size = new System.Drawing.Size(109, 20);
            this.txtDispositivo.TabIndex = 11;
            // 
            // txtControlador
            // 
            this.txtControlador.Location = new System.Drawing.Point(389, 38);
            this.txtControlador.Name = "txtControlador";
            this.txtControlador.Size = new System.Drawing.Size(109, 20);
            this.txtControlador.TabIndex = 10;
            // 
            // dtFinal
            // 
            this.dtFinal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinal.Location = new System.Drawing.Point(504, 77);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(145, 20);
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
            this.lblDataFim.Location = new System.Drawing.Point(501, 61);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(55, 13);
            this.lblDataFim.TabIndex = 7;
            this.lblDataFim.Text = "Data Final";
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(501, 22);
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
            this.dtInicio.Location = new System.Drawing.Point(504, 38);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(145, 20);
            this.dtInicio.TabIndex = 5;
            // 
            // grbProcedenciaTrace
            // 
            this.grbProcedenciaTrace.Controls.Add(this.chkProcedenciaTrace);
            this.grbProcedenciaTrace.Location = new System.Drawing.Point(143, 16);
            this.grbProcedenciaTrace.Name = "grbProcedenciaTrace";
            this.grbProcedenciaTrace.Size = new System.Drawing.Size(237, 85);
            this.grbProcedenciaTrace.TabIndex = 4;
            this.grbProcedenciaTrace.TabStop = false;
            this.grbProcedenciaTrace.Text = "Procedência";
            // 
            // chkProcedenciaTrace
            // 
            this.chkProcedenciaTrace.CheckOnClick = true;
            this.chkProcedenciaTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkProcedenciaTrace.FormattingEnabled = true;
            this.chkProcedenciaTrace.Location = new System.Drawing.Point(3, 16);
            this.chkProcedenciaTrace.Name = "chkProcedenciaTrace";
            this.chkProcedenciaTrace.Size = new System.Drawing.Size(231, 66);
            this.chkProcedenciaTrace.TabIndex = 2;
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
            this.spcMain.Panel1.Controls.Add(this.grbGridTrace);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.grbMensagemTrace);
            this.spcMain.Size = new System.Drawing.Size(1373, 494);
            this.spcMain.SplitterDistance = 382;
            this.spcMain.TabIndex = 1;
            // 
            // grbGridTrace
            // 
            this.grbGridTrace.Controls.Add(this.grdTraceOcorrencias);
            this.grbGridTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGridTrace.Location = new System.Drawing.Point(0, 0);
            this.grbGridTrace.Name = "grbGridTrace";
            this.grbGridTrace.Size = new System.Drawing.Size(1373, 382);
            this.grbGridTrace.TabIndex = 0;
            this.grbGridTrace.TabStop = false;
            this.grbGridTrace.Text = "Traces do Sistema";
            // 
            // grdTraceOcorrencias
            // 
            this.grdTraceOcorrencias.AllowUserToAddRows = false;
            this.grdTraceOcorrencias.AllowUserToDeleteRows = false;
            this.grdTraceOcorrencias.AllowUserToOrderColumns = true;
            this.grdTraceOcorrencias.AllowUserToResizeRows = false;
            this.grdTraceOcorrencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTraceOcorrencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdTraceOcorrencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTraceOcorrencias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdTraceOcorrencias.Location = new System.Drawing.Point(3, 16);
            this.grdTraceOcorrencias.MultiSelect = false;
            this.grdTraceOcorrencias.Name = "grdTraceOcorrencias";
            this.grdTraceOcorrencias.RowHeadersWidth = 20;
            this.grdTraceOcorrencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTraceOcorrencias.Size = new System.Drawing.Size(1367, 363);
            this.grdTraceOcorrencias.TabIndex = 0;
            this.grdTraceOcorrencias.SelectionChanged += new System.EventHandler(this.grdTraceOcorrencias_SelectionChanged);
            // 
            // grbMensagemTrace
            // 
            this.grbMensagemTrace.Controls.Add(this.txtMensagem);
            this.grbMensagemTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbMensagemTrace.Location = new System.Drawing.Point(0, 0);
            this.grbMensagemTrace.Name = "grbMensagemTrace";
            this.grbMensagemTrace.Size = new System.Drawing.Size(1373, 108);
            this.grbMensagemTrace.TabIndex = 0;
            this.grbMensagemTrace.TabStop = false;
            this.grbMensagemTrace.Text = "Mensagem Transmitida";
            // 
            // txtMensagem
            // 
            this.txtMensagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMensagem.Location = new System.Drawing.Point(3, 16);
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.ReadOnly = true;
            this.txtMensagem.Size = new System.Drawing.Size(1367, 89);
            this.txtMensagem.TabIndex = 0;
            this.txtMensagem.Text = "";
            // 
            // ctlTraceComunicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ctlTraceComunicacao";
            this.Size = new System.Drawing.Size(1373, 646);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlBotoes, 0);
            this.Controls.SetChildIndex(this.spcMain, 0);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.grbHeader.ResumeLayout(false);
            this.grbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximoLinhas)).EndInit();
            this.grbProcedenciaTrace.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.grbGridTrace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTraceOcorrencias)).EndInit();
            this.grbMensagemTrace.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.GroupBox grbGridTrace;
        private System.Windows.Forms.GroupBox grbMensagemTrace;
        private System.Windows.Forms.GroupBox grbHeader;
        private System.Windows.Forms.Label lblOcorrencia;
        private System.Windows.Forms.TextBox txtOcorrencia;
        private System.Windows.Forms.CheckedListBox chkProcedenciaTrace;
        private System.Windows.Forms.GroupBox grbProcedenciaTrace;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.RichTextBox txtMensagem;
        private System.Windows.Forms.DataGridView grdTraceOcorrencias;
        private System.Windows.Forms.Button btnExibe;
        private System.Windows.Forms.TextBox txtControlador;
        private System.Windows.Forms.TextBox txtDispositivo;
        private System.Windows.Forms.Label lblControlador;
        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.NumericUpDown numMaximoLinhas;
        private System.Windows.Forms.Label lblMaximoLinhas;
    }
}

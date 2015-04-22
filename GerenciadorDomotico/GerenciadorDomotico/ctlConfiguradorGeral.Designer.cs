﻿namespace GerenciadorDomotico
{
    partial class ctlConfiguradorGeral
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
            this.pnlWebService = new System.Windows.Forms.Panel();
            this.grbWebService = new System.Windows.Forms.GroupBox();
            this.lblPortaTcp = new System.Windows.Forms.Label();
            this.lblServidor = new System.Windows.Forms.Label();
            this.txtPortaTcp = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.pnlSerial = new System.Windows.Forms.Panel();
            this.grbSerial = new System.Windows.Forms.GroupBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.lblParidade = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.cmbParidade = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblPortaSerial = new System.Windows.Forms.Label();
            this.txtPortaSerial = new System.Windows.Forms.TextBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlWebService.SuspendLayout();
            this.grbWebService.SuspendLayout();
            this.pnlSerial.SuspendLayout();
            this.grbSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Location = new System.Drawing.Point(0, 513);
            this.pnlBotoes.Size = new System.Drawing.Size(1023, 42);
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
            // pnlWebService
            // 
            this.pnlWebService.Controls.Add(this.grbWebService);
            this.pnlWebService.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWebService.Location = new System.Drawing.Point(0, 0);
            this.pnlWebService.Name = "pnlWebService";
            this.pnlWebService.Size = new System.Drawing.Size(1023, 65);
            this.pnlWebService.TabIndex = 1;
            // 
            // grbWebService
            // 
            this.grbWebService.Controls.Add(this.lblPortaTcp);
            this.grbWebService.Controls.Add(this.lblServidor);
            this.grbWebService.Controls.Add(this.txtPortaTcp);
            this.grbWebService.Controls.Add(this.txtServidor);
            this.grbWebService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbWebService.Location = new System.Drawing.Point(0, 0);
            this.grbWebService.Name = "grbWebService";
            this.grbWebService.Size = new System.Drawing.Size(1023, 65);
            this.grbWebService.TabIndex = 0;
            this.grbWebService.TabStop = false;
            this.grbWebService.Text = "Endereço do Web Service";
            // 
            // lblPortaTcp
            // 
            this.lblPortaTcp.AutoSize = true;
            this.lblPortaTcp.Location = new System.Drawing.Point(260, 16);
            this.lblPortaTcp.Name = "lblPortaTcp";
            this.lblPortaTcp.Size = new System.Drawing.Size(32, 13);
            this.lblPortaTcp.TabIndex = 3;
            this.lblPortaTcp.Text = "Porta";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(6, 16);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(46, 13);
            this.lblServidor.TabIndex = 2;
            this.lblServidor.Text = "Servidor";
            // 
            // txtPortaTcp
            // 
            this.txtPortaTcp.Location = new System.Drawing.Point(263, 32);
            this.txtPortaTcp.Name = "txtPortaTcp";
            this.txtPortaTcp.Size = new System.Drawing.Size(131, 20);
            this.txtPortaTcp.TabIndex = 1;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(9, 32);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(248, 20);
            this.txtServidor.TabIndex = 0;
            // 
            // pnlSerial
            // 
            this.pnlSerial.Controls.Add(this.grbSerial);
            this.pnlSerial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSerial.Location = new System.Drawing.Point(0, 65);
            this.pnlSerial.Name = "pnlSerial";
            this.pnlSerial.Size = new System.Drawing.Size(1023, 71);
            this.pnlSerial.TabIndex = 2;
            // 
            // grbSerial
            // 
            this.grbSerial.Controls.Add(this.lblStopBits);
            this.grbSerial.Controls.Add(this.lblDataBits);
            this.grbSerial.Controls.Add(this.lblParidade);
            this.grbSerial.Controls.Add(this.lblBaudRate);
            this.grbSerial.Controls.Add(this.cmbStopBits);
            this.grbSerial.Controls.Add(this.cmbDataBits);
            this.grbSerial.Controls.Add(this.cmbParidade);
            this.grbSerial.Controls.Add(this.cmbBaudRate);
            this.grbSerial.Controls.Add(this.lblPortaSerial);
            this.grbSerial.Controls.Add(this.txtPortaSerial);
            this.grbSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbSerial.Location = new System.Drawing.Point(0, 0);
            this.grbSerial.Name = "grbSerial";
            this.grbSerial.Size = new System.Drawing.Size(1023, 71);
            this.grbSerial.TabIndex = 0;
            this.grbSerial.TabStop = false;
            this.grbSerial.Text = "Porta Serial";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(542, 16);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(49, 13);
            this.lblStopBits.TabIndex = 9;
            this.lblStopBits.Text = "Stop Bits";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(408, 16);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(50, 13);
            this.lblDataBits.TabIndex = 8;
            this.lblDataBits.Text = "Data Bits";
            // 
            // lblParidade
            // 
            this.lblParidade.AutoSize = true;
            this.lblParidade.Location = new System.Drawing.Point(274, 16);
            this.lblParidade.Name = "lblParidade";
            this.lblParidade.Size = new System.Drawing.Size(49, 13);
            this.lblParidade.TabIndex = 7;
            this.lblParidade.Text = "Paridade";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(140, 16);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 6;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Location = new System.Drawing.Point(545, 32);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(128, 21);
            this.cmbStopBits.TabIndex = 5;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Location = new System.Drawing.Point(411, 32);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(128, 21);
            this.cmbDataBits.TabIndex = 4;
            // 
            // cmbParidade
            // 
            this.cmbParidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParidade.FormattingEnabled = true;
            this.cmbParidade.Location = new System.Drawing.Point(277, 32);
            this.cmbParidade.Name = "cmbParidade";
            this.cmbParidade.Size = new System.Drawing.Size(128, 21);
            this.cmbParidade.TabIndex = 3;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(143, 32);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(128, 21);
            this.cmbBaudRate.TabIndex = 2;
            // 
            // lblPortaSerial
            // 
            this.lblPortaSerial.AutoSize = true;
            this.lblPortaSerial.Location = new System.Drawing.Point(6, 16);
            this.lblPortaSerial.Name = "lblPortaSerial";
            this.lblPortaSerial.Size = new System.Drawing.Size(32, 13);
            this.lblPortaSerial.TabIndex = 1;
            this.lblPortaSerial.Text = "Porta";
            // 
            // txtPortaSerial
            // 
            this.txtPortaSerial.Location = new System.Drawing.Point(9, 32);
            this.txtPortaSerial.Name = "txtPortaSerial";
            this.txtPortaSerial.Size = new System.Drawing.Size(128, 20);
            this.txtPortaSerial.TabIndex = 0;
            // 
            // ctlConfiguradorGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSerial);
            this.Controls.Add(this.pnlWebService);
            this.Name = "ctlConfiguradorGeral";
            this.Controls.SetChildIndex(this.pnlBotoes, 0);
            this.Controls.SetChildIndex(this.pnlWebService, 0);
            this.Controls.SetChildIndex(this.pnlSerial, 0);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlWebService.ResumeLayout(false);
            this.grbWebService.ResumeLayout(false);
            this.grbWebService.PerformLayout();
            this.pnlSerial.ResumeLayout(false);
            this.grbSerial.ResumeLayout(false);
            this.grbSerial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWebService;
        private System.Windows.Forms.Panel pnlSerial;
        private System.Windows.Forms.GroupBox grbWebService;
        private System.Windows.Forms.GroupBox grbSerial;
        private System.Windows.Forms.TextBox txtPortaTcp;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lblPortaTcp;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox txtPortaSerial;
        private System.Windows.Forms.Label lblPortaSerial;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.ComboBox cmbParidade;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblParidade;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.Label lblStopBits;
    }
}

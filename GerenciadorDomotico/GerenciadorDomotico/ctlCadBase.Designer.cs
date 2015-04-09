namespace GerenciadorDomotico
{
    partial class ctlCadBase
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
            this.btnApaga = new System.Windows.Forms.Button();
            this.btnAtivaInativa = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnEdita = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnApaga);
            this.pnlBotoes.Controls.Add(this.btnAtivaInativa);
            this.pnlBotoes.Controls.Add(this.btnCancela);
            this.pnlBotoes.Controls.Add(this.btnSalva);
            this.pnlBotoes.Controls.Add(this.btnEdita);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.btnFecha);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 344);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1023, 71);
            this.pnlBotoes.TabIndex = 0;
            // 
            // btnApaga
            // 
            this.btnApaga.Location = new System.Drawing.Point(894, 23);
            this.btnApaga.Name = "btnApaga";
            this.btnApaga.Size = new System.Drawing.Size(75, 23);
            this.btnApaga.TabIndex = 6;
            this.btnApaga.Text = "&Apaga";
            this.btnApaga.UseVisualStyleBackColor = true;
            this.btnApaga.Click += new System.EventHandler(this.btnApaga_Click);
            // 
            // btnAtivaInativa
            // 
            this.btnAtivaInativa.Location = new System.Drawing.Point(751, 23);
            this.btnAtivaInativa.Name = "btnAtivaInativa";
            this.btnAtivaInativa.Size = new System.Drawing.Size(75, 23);
            this.btnAtivaInativa.TabIndex = 5;
            this.btnAtivaInativa.Text = "&Inativa";
            this.btnAtivaInativa.UseVisualStyleBackColor = true;
            this.btnAtivaInativa.Click += new System.EventHandler(this.btnAtivaInativa_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.Location = new System.Drawing.Point(605, 23);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(75, 23);
            this.btnCancela.TabIndex = 4;
            this.btnCancela.Text = "&Cancela";
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(464, 23);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(75, 23);
            this.btnSalva.TabIndex = 3;
            this.btnSalva.Text = "&Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnEdita
            // 
            this.btnEdita.Location = new System.Drawing.Point(316, 23);
            this.btnEdita.Name = "btnEdita";
            this.btnEdita.Size = new System.Drawing.Size(75, 23);
            this.btnEdita.TabIndex = 2;
            this.btnEdita.Text = "&Edita";
            this.btnEdita.UseVisualStyleBackColor = true;
            this.btnEdita.Click += new System.EventHandler(this.btnEdita_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(174, 23);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(13, 23);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(75, 23);
            this.btnFecha.TabIndex = 0;
            this.btnFecha.Text = "&Fechar";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // ctlCadBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBotoes);
            this.Name = "ctlCadBase";
            this.Size = new System.Drawing.Size(1023, 415);
            this.Resize += new System.EventHandler(this.ctlCadBase_Resize);
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlBotoes;
        protected System.Windows.Forms.Button btnFecha;
        protected System.Windows.Forms.Button btnNovo;
        protected System.Windows.Forms.Button btnEdita;
        protected System.Windows.Forms.Button btnSalva;
        protected System.Windows.Forms.Button btnCancela;
        protected System.Windows.Forms.Button btnAtivaInativa;
        protected System.Windows.Forms.Button btnApaga;
    }
}

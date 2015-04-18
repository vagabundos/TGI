namespace GerenciadorDomotico
{
	partial class winInicial
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.stpMenu = new System.Windows.Forms.MenuStrip();
            this.pnlGeral = new System.Windows.Forms.Panel();
            this.tabCtrl1 = new System.Windows.Forms.TabControl();
            this.pnlGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpMenu
            // 
            this.stpMenu.Location = new System.Drawing.Point(0, 0);
            this.stpMenu.Name = "stpMenu";
            this.stpMenu.Size = new System.Drawing.Size(792, 24);
            this.stpMenu.TabIndex = 0;
            this.stpMenu.Text = "menuStrip1";
            // 
            // pnlGeral
            // 
            this.pnlGeral.Controls.Add(this.tabCtrl1);
            this.pnlGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeral.Location = new System.Drawing.Point(0, 24);
            this.pnlGeral.Name = "pnlGeral";
            this.pnlGeral.Size = new System.Drawing.Size(792, 549);
            this.pnlGeral.TabIndex = 1;
            // 
            // tabCtrl1
            // 
            this.tabCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabCtrl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabCtrl1.ItemSize = new System.Drawing.Size(120, 20);
            this.tabCtrl1.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl1.Name = "tabCtrl1";
            this.tabCtrl1.SelectedIndex = 0;
            this.tabCtrl1.Size = new System.Drawing.Size(792, 549);
            this.tabCtrl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCtrl1.TabIndex = 1;
            this.tabCtrl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabCtrl1_DrawItem);
            this.tabCtrl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabCtrl1_MouseDown);
            // 
            // winInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.pnlGeral);
            this.Controls.Add(this.stpMenu);
            this.MainMenuStrip = this.stpMenu;
            this.Name = "winInicial";
            this.Text = "Home On";
            this.pnlGeral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip stpMenu;
		private System.Windows.Forms.Panel pnlGeral;
        private System.Windows.Forms.TabControl tabCtrl1;
	}
}


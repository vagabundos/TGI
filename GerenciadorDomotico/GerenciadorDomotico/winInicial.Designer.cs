﻿namespace GerenciadorDomotico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(winInicial));
            this.stpMenu = new System.Windows.Forms.MenuStrip();
            this.pnlGeral = new System.Windows.Forms.Panel();
            this.tabCtrl = new System.Windows.Forms.TabControl();
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
            this.pnlGeral.Controls.Add(this.tabCtrl);
            this.pnlGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeral.Location = new System.Drawing.Point(0, 24);
            this.pnlGeral.Name = "pnlGeral";
            this.pnlGeral.Size = new System.Drawing.Size(792, 549);
            this.pnlGeral.TabIndex = 1;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabCtrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabCtrl.ItemSize = new System.Drawing.Size(150, 20);
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(792, 549);
            this.tabCtrl.TabIndex = 1;
            this.tabCtrl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabCtrl1_DrawItem);
            this.tabCtrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabCtrl_MouseDown);
            // 
            // winInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.pnlGeral);
            this.Controls.Add(this.stpMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.stpMenu;
            this.Name = "winInicial";
            this.Text = "HomeOn";
            this.pnlGeral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip stpMenu;
		private System.Windows.Forms.Panel pnlGeral;
        private System.Windows.Forms.TabControl tabCtrl;
	}
}


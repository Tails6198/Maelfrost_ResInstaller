﻿namespace MaelfrostInstaller
{
    partial class FrmWizard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWizard));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTopText = new Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.navigationButton1 = new MaelfrostInstaller.Controls.FunnyExplorer.Controls.NavigationButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.BtnBack = new MaelfrostInstaller.Controls.WinUIButton();
            this.BtnNext = new MaelfrostInstaller.Controls.WinUIButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Black;
            this.pnlTop.Controls.Add(this.lblTopText);
            this.pnlTop.Controls.Add(this.panel1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(596, 60);
            this.pnlTop.TabIndex = 3;
            // 
            // lblTopText
            // 
            this.lblTopText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTopText.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTopText.ForeColor = System.Drawing.Color.White;
            this.lblTopText.Location = new System.Drawing.Point(51, 0);
            this.lblTopText.Name = "lblTopText";
            this.lblTopText.Size = new System.Drawing.Size(545, 60);
            this.lblTopText.TabIndex = 7;
            this.lblTopText.Text = "Welcome to the Project Maelfrost Installer";
            this.lblTopText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.navigationButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(51, 60);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // navigationButton1
            // 
            this.navigationButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.navigationButton1.BackColor = System.Drawing.Color.Transparent;
            this.navigationButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navigationButton1.Location = new System.Drawing.Point(10, 15);
            this.navigationButton1.Name = "navigationButton1";
            this.navigationButton1.NavigationButtonType = MaelfrostInstaller.Controls.FunnyExplorer.Controls.NavigationButtonType.back;
            this.navigationButton1.Size = new System.Drawing.Size(30, 30);
            this.navigationButton1.TabIndex = 0;
            this.navigationButton1.Text = "navigationButton1";
            this.navigationButton1.Click += new System.EventHandler(this.NavigationButton1_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.BtnBack);
            this.pnlBottom.Controls.Add(this.BtnNext);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 390);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(596, 60);
            this.pnlBottom.TabIndex = 5;
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.Transparent;
            this.BtnBack.ButtonText = "Back";
            this.BtnBack.Enabled = false;
            this.BtnBack.ForeColor = System.Drawing.Color.White;
            this.BtnBack.Location = new System.Drawing.Point(428, 16);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(75, 23);
            this.BtnBack.TabIndex = 1;
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Visible = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackColor = System.Drawing.Color.Transparent;
            this.BtnNext.ButtonText = "Next";
            this.BtnNext.ForeColor = System.Drawing.Color.White;
            this.BtnNext.Location = new System.Drawing.Point(509, 16);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 23);
            this.BtnNext.TabIndex = 0;
            this.BtnNext.UseVisualStyleBackColor = false;
            this.BtnNext.Visible = false;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(596, 330);
            this.pnlMain.TabIndex = 11;
            // 
            // FrmWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(596, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maelfrost Setup";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTop;
        private Panel pnlBottom;
        private Panel pnlMain;
        private Label lblTopText;
        private Panel panel1;
        private Controls.WinUIButton BtnBack;
        private Controls.WinUIButton BtnNext;
        private Controls.FunnyExplorer.Controls.NavigationButton navigationButton1;
    }
}
using MaelfrostInstaller.Controls;

namespace MaelfrostInstaller.Pages
{
    partial class WelcomePage
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
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbInstallNOW = new MaelfrostInstaller.Controls.CommandLinkButton();
            this.cmbUninstall = new MaelfrostInstaller.Controls.CommandLinkButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Please select an installation mode.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::MaelfrostInstaller.Properties.Resources.MaelfrostInstaller;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(8, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 160);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cmbInstallNOW);
            this.flowLayoutPanel1.Controls.Add(this.cmbUninstall);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(306, 67);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(283, 243);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // cmbInstallNOW
            // 
            this.cmbInstallNOW.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbInstallNOW.Location = new System.Drawing.Point(3, 3);
            this.cmbInstallNOW.Name = "cmbInstallNOW";
            this.cmbInstallNOW.Note = "Installs Maelfrost on top of this Windows Installation";
            this.cmbInstallNOW.Size = new System.Drawing.Size(249, 82);
            this.cmbInstallNOW.TabIndex = 7;
            this.cmbInstallNOW.Text = "Install Now";
            this.cmbInstallNOW.UseVisualStyleBackColor = true;
            this.cmbInstallNOW.Click += new System.EventHandler(this.cmbInstallNOW_Click);
            // 
            // cmbUninstall
            // 
            this.cmbUninstall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbUninstall.Location = new System.Drawing.Point(3, 91);
            this.cmbUninstall.Name = "cmbUninstall";
            this.cmbUninstall.Note = "Restores Windows 11";
            this.cmbUninstall.Size = new System.Drawing.Size(249, 82);
            this.cmbUninstall.TabIndex = 8;
            this.cmbUninstall.Text = "Uninstall Maelfrost";
            this.cmbUninstall.UseVisualStyleBackColor = true;
            // 
            // WelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "WelcomePage";
            this.WizardTopText = "Welcome to the Project Maelfrost Installer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private CommandLinkButton cmbInstallNOW;
        private CommandLinkButton cmbUninstall;
    }
}

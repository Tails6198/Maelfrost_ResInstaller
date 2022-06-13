using MaelfrostInstaller.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaelfrostInstaller.Pages
{
    public partial class ProgressPage : WizardPage
    {
        public Label CurrentProgressText
        {
            get
            {
                return lblCurrent;
            }
            set
            {
                lblCurrent = value;
            }
        }
        public CustomProgressBar ProgressBarDef
        {
            get
            {
                return ProgressBar;
            }
            set
            {
                ProgressBar = value;
            }
        }
        public ProgressPage()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextText();
        }

        private int CurrentTextIndex = 0;
        private void NextText()
        {
            CurrentTextIndex++;

            if (CurrentTextIndex >= MaelfrostInstallerTexts.Length)
            {
                CurrentTextIndex = 0;
            }

            var t = MaelfrostInstallerTexts[CurrentTextIndex];
            lblTitle.Text = t.Title;
            lblDescript.Text = t.Description;
        }

        private static InstallerTexts[] MaelfrostInstallerTexts =
        {
            new("Did you know that...", "Project Maelfrost has better DPI scaling support? This is because we scale controls correctly."),
            new("Project Maelfrost has a better theme", "It took months of hard work to create a great consistent light and dark theme!"),
            new("Project Maelfrost has better performance", "Out of the box, we optimize everything, we value performance strongly."),
            new("Project Maelfrost has changed everything", "Maelfrost was designed from the ground up to be a more consistent operating system."),
            new("A framework", "Project Maelfrost is a framework, it can be modified by you and your changes will be reflected on install. Isn't that great?"),
            new("Thank you!", "Maelfrost appreciates your support, thanks for choosing me!")
        };

        private class InstallerTexts
        {
            public string Title { get; set; }
            public string Description { get; set; }

            public InstallerTexts(string Title, string Description)
            {
                this.Title = Title;
                this.Description = Description;
            }
        }
    }
}

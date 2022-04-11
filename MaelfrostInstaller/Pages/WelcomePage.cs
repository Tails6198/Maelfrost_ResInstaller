using MaelfrostInstaller.Controls;

namespace MaelfrostInstaller.Pages
{
    public partial class WelcomePage : WizardPage
    {
        public CommandLinkButton InstallButton
        {
            get
            {
                return cmbInstallNOW;
            }
            set
            {
                cmbInstallNOW = value;
            }
        }
        //public CommandLinkButton UninstallButton
        //{
        //    get
        //    {
        //        return cmbUninstall;
        //    }
        //    set
        //    {
        //        cmbUninstall = value;
        //    }
        //}
        public WelcomePage()
        {
            InitializeComponent();
        }
    }
}

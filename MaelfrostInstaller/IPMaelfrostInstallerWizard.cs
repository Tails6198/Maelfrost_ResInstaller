using MaelfrostInstaller.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaelfrostInstaller
{
    //
    //
    //   IPMaelfrostInstaller Interface
    //
    //

    public interface IPMaelfrostInstallerWizard
    {
        /// <summary>
        /// Sets progress bar value
        /// </summary>
        /// <param name="val"></param>
        void SetProgress(int val);
        /// <summary>
        /// Sets the text by the progress bar
        /// </summary>
        /// <param name="text"></param>
        void SetProgressText(string text);
        /// <summary>
        /// Tell the installer that it's work is completed.
        /// </summary>
        void CompleteInstaller(PMaelfrostInstallerWizardCompleteInstallerEnum type, string ErrorDescription = "");
    }
    public enum PMaelfrostInstallerWizardCompleteInstallerEnum
    {
        Success,
        Fail
    }

    //
    //
    //   PMaelfrostInstallerWizard implementation
    //
    //

    internal class PMaelfrostInstallerWizard : IPMaelfrostInstallerWizard
    {
        private readonly FrmWizard Wizard;
        private readonly ProgressPage ProgressPage;
        internal PMaelfrostInstallerWizard(FrmWizard wizard, ProgressPage pg)
        {
            this.Wizard = wizard;
            this.ProgressPage = pg;
        }

        public void CompleteInstaller(PMaelfrostInstallerWizardCompleteInstallerEnum type, string ErrorDescription = "")
        {
            ProgressPage.Invoke((MethodInvoker)delegate ()
            {
                Wizard.Complete(type, ErrorDescription);
            });    
        }

        public void SetProgress(int val)
        {
            ProgressPage.Invoke((MethodInvoker)delegate ()
            {
                ProgressPage.ProgressBarDef.Value = val;
            });
        }

        public void SetProgressText(string text)
        {
            ProgressPage.Invoke((MethodInvoker)delegate ()
            {
                ProgressPage.CurrentProgressText.Text = text;
            });
        }
    }

    //
    //
    //   PMaelfrostInstaller Interface
    //
    //
    /// <summary>
    /// The class implementing this interface is what installs Project Maelfrost
    /// </summary>
    public interface IPMaelfrostInstaller
    {
        /// <summary>
        /// Used for storing the IPMaelfrostInstallerWizard instance
        /// </summary>
        /// <param name="wiz"></param>
        void SetParentWizard(IPMaelfrostInstallerWizard wiz);
        /// <summary>
        /// Install Project Maelfrost
        /// </summary>
        void Install();
    }
}

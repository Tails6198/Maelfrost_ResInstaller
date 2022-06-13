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
    //   IMaelfrostCoreInstaller Interface
    //
    //

    public interface IMaelfrostCoreInstallerWizard
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
        void CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum type, string ErrorDescription = "");
    }
    public enum MaelfrostCoreInstallerWizardCompleteInstallerEnum
    {
        Success,
        Fail
    }

    //
    //
    //   MaelfrostCoreInstallerWizard implementation
    //
    //

    internal class MaelfrostCoreInstallerWizard : IMaelfrostCoreInstallerWizard
    {
        private readonly FrmWizard Wizard;
        private readonly ProgressPage ProgressPage;
        internal MaelfrostCoreInstallerWizard(FrmWizard wizard, ProgressPage pg)
        {
            this.Wizard = wizard;
            this.ProgressPage = pg;
        }

        public void CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum type, string ErrorDescription = "")
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
    //   MaelfrostCoreInstaller Interface
    //
    //
    /// <summary>
    /// The class implementing this interface is what installs Maelfrost
    /// </summary>
    public interface IMaelfrostCoreInstaller
    {
        /// <summary>
        /// Used for storing the IMaelfrostCoreInstallerWizard instance
        /// </summary>
        /// <param name="wiz"></param>
        void SetParentWizard(IMaelfrostCoreInstallerWizard wiz);
        /// <summary>
        /// Install Maelfrost
        /// </summary>
        void Install();
    }
}

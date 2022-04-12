using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaelfrostInstaller
{
    public class PMaelfrostInstaller : IPMaelfrostInstaller
    {
        private IPMaelfrostInstallerWizard? _Wizard;
        public void Install()
        {
            if (_Wizard == null)
            {
                throw new Exception("SetParentWizard() in IPMaelfrostInstaller was not called!");
            }

            _Wizard.SetProgressText("Copying files");
            if (Directory.Exists("tmp"))
                Directory.Delete("tmp", true);
            Directory.CreateDirectory("tmp");

            File.Copy(@"C:\windows\systemresources\shell32.dll.mun", "tmp/shell32.dll.mun");
            File.Copy(@"C:\windows\systemresources\imageres.dll.mun", "tmp/imageres.dll.mun");



            //_Wizard.CompleteInstaller(PMaelfrostInstallerWizardCompleteInstallerEnum.Fail, "not implemented!");
        }

        public void SetParentWizard(IPMaelfrostInstallerWizard wiz)
        {
            _Wizard = wiz;
        }
    }
}

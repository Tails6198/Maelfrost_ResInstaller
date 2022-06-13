﻿using MaelfrostInstaller.Core;
using MaelfrostInstaller.Win32;
using MaelfrostInstaller.Win32.Maelfrost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MaelfrostInstaller
{
    public class MaelfrostCoreInstaller : IMaelfrostCoreInstaller
    {
        private IMaelfrostCoreInstallerWizard? _Wizard;
        public void Install()
        {
            if (_Wizard == null)
            {
                throw new Exception("SetParentWizard() in IMaelfrostCoreInstaller was not called!");
            }

            try
            {
                _Wizard.SetProgressText("Copying files");

                #region Setup
                if (Directory.Exists("tmp"))
                    Directory.Delete("tmp", true);
                if (Directory.Exists(@"C:/Windows/MaelfrostDeploy/Tmp/"))
                    Directory.Delete(@"C:/Windows/MaelfrostDeploy/Tmp/", true);

                Directory.CreateDirectory("C:/Windows/MaelfrostDeploy/Tmp/");
                Directory.CreateDirectory("C:/Windows/MaelfrostDeploy/Tmp/Wow64");
                Directory.CreateDirectory("C:/Windows/MaelfrostDeploy/Tmp/Amd64");
                Directory.CreateDirectory(@"C:\Windows\MaelfrostDeploy\");
                Directory.CreateDirectory(@"C:\Windows\RectifMaelfrostDeployy11\Backup");
                var backupDir = @"C:\Windows\MaelfrostDeploy\Backup";
                _Wizard.SetProgressText("Taking ownership of system files");
                _Wizard.SetProgress(1);
                TakeOwnership(@"C:\Windows\SystemResources\");

                Directory.CreateDirectory(@"C:/Windows/MaelfrostDeploy/Tmp/");
                #endregion





                foreach (var item in Patches.GetAll())
                {
                    //get the package

                    var usr = GetAMD64Package(item.WinSxSPackageName);
                    if (usr == null)
                    {
                        _Wizard.CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum.Fail, "Cannot find Microsoft.Windows.UserCPL package in the WinSxS folder!");
                        return;
                    }


                    var WinSxSFilePath = usr.Path + @"\" + item.DllName;
                    string dir = Path.GetFileName(usr.Path);
                    string file = dir + "/" + item.DllName;

                    string fileProper = "C:/Windows/MaelfrostDeploy/Tmp/" + file; //relative path to the file location
                    string backupDirW = backupDir + "/" + dir; //backup dir where the file is located at

                    if (!File.Exists(WinSxSFilePath))
                    {
                        _Wizard.CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum.Fail, "Cannot find UserCPL DLL");
                        return;
                    }

                    Directory.CreateDirectory("C:/Windows/MaelfrostDeploy/Tmp/" + dir);
                    File.Copy(WinSxSFilePath, fileProper, true);

                    Directory.CreateDirectory(backupDirW);
                    File.Copy(WinSxSFilePath, backupDirW + "/" + item.DllName, true);

                    foreach (var patch in item.PatchInstructions)
                    {
                        //This is where we mod the file
                        if (!ReshackAddRes(@"C:\Program Files (x86)\Resource Hacker\ResourceHacker.exe",
                            fileProper,
                            fileProper,
                            patch.Action, //"addoverwrite",
                            Application.StartupPath + @"\files\"+patch.Resource, //UserCPL_IconGroup1.ico
                            patch.GroupAndLocation))//ICONGROUP,1,0
                        {
                            _Wizard.CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum.Fail, "Resource hacker failed at DLL: usercpl.dll.mun\nCommand line:\n" + LastCmd);
                            return;
                        }
                    }

                    


                    //Take ownership of orginal file
                    TakeOwnership(WinSxSFilePath);
                    TakeOwnership(fileProper);
                    TakeOwnership(item.Systempath);

                    //Delete old hardlink
                    File.Delete(item.Systempath);

                    //rename old file
                    File.Move(WinSxSFilePath, WinSxSFilePath + ".bak");

                    //copy new file over
                    File.Move(fileProper, WinSxSFilePath, true);

                    //create hardlink
                    if (!Pinvoke.CreateHardLinkA(item.Systempath, WinSxSFilePath, IntPtr.Zero))
                    {
                        _Wizard.CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum.Fail, "CreateHardLinkW() failed: " + new Win32Exception().Message);
                        return;
                    }

                    //schedule .bak for deletion
                    try
                    {
                        File.Delete(WinSxSFilePath + ".bak");
                    }
                    catch
                    {
                        //delete it first
                        if (!Pinvoke.MoveFileEx(WinSxSFilePath + ".bak", null, Pinvoke.MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT))
                        {
                            _Wizard.CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum.Fail, "Deleting usrcpl.man failed: " + new Win32Exception().Message);
                            return;
                        }
                    }
                }



                _Wizard.CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum.Fail, "The rest of the installer is not implemented! but we changed the user account control panel");
                return;
            }
            catch (Exception ex)
            {
                _Wizard.CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum.Fail, ex.ToString());
            }

            //Thread.Sleep(5000);
            ////_Wizard.CompleteInstaller(MaelfrostCoreInstallerWizardCompleteInstallerEnum.Fail, "not implemented!");
        }

        private Package? GetAMD64Package(string name)
        {
            var usercpl = FindPackage(name);
            if (usercpl.Count == 0)
            {
                return null;
            }
            foreach (var item in usercpl)
            {
                if (item.Arch == PackageArch.Amd64)
                {
                    return item;
                }
            }
            return null;
        }

        private void TakeOwnership(string path)
        {
            _ = PatcherHelper.TakeOwnership(path);
            _ = PatcherHelper.GrantFullControl(path, "SYSTEM");
            _ = PatcherHelper.GrantFullControl(path, "Administrators");
        }
        public void SetParentWizard(IMaelfrostCoreInstallerWizard wiz)
        {
            _Wizard = wiz;
        }

        private List<Package> FindPackage(string name)
        {
            List<Package> p = new List<Package>();
            var build = Environment.OSVersion.Version.Build.ToString();
            foreach (var item in Directory.GetDirectories(@"C:\Windows\WinSxS\"))
            {
                if (item.Contains(build) && item.Contains(name + "_"))
                {
                    var path = item.Replace(@"C:\Windows\WinSxS\", "");
                    if (path.StartsWith("amd64_"))
                    {
                        p.Add(new Package(item, PackageArch.Amd64));
                    }
                    else if (path.StartsWith("wow64_"))
                    {
                        p.Add(new Package(item, PackageArch.Wow64));
                    }
                }
            }

            return p;
        }
        private string? LastCmd;
        public bool ReshackAddRes(string reshackerPath, string filename, string destination, string action, string resource, string type)
        {
            LastCmd = " -open " + filename + " -save " + destination + " -action " + action + " -resource " + resource + " -mask " + type;
            Process reshackFileProcess = new Process();
            ProcessStartInfo reshackFileStartInfo = new ProcessStartInfo
            {
                FileName = reshackerPath,
                // Do not write error output to standard stream.
                RedirectStandardError = false,
                // Do not write output to Process.StandardOutput Stream.
                RedirectStandardOutput = false,
                // Do not read input from Process.StandardInput (i/e; the keyboard).
                RedirectStandardInput = false,

                UseShellExecute = false,
                // Do not show a command window.
                CreateNoWindow = true,

                Arguments = LastCmd
            };
            reshackFileProcess.EnableRaisingEvents = true;
            reshackFileProcess.StartInfo = reshackFileStartInfo;
            // Start the process.
            reshackFileProcess.Start();
            // Wait for the process to finish.
            reshackFileProcess.WaitForExit();

            int exitCode = reshackFileProcess.ExitCode;
            bool reshackFileSuccessful = true;

            // Now we need to see if the process was successful.
            if (exitCode != 0)
            {
                reshackFileProcess.Kill();
                reshackFileSuccessful = false;
            }

            // Now clean up after ourselves.
            reshackFileProcess.Dispose();
            return reshackFileSuccessful;
        }

        private class Package
        {
            public string Path { get; set; }
            public PackageArch Arch { get; set; }
            public Package(string Path, PackageArch Arch)
            {
                this.Path = Path;
                this.Arch = Arch;
            }
        }
    }

    public enum PackageArch
    {
        Amd64,
        Wow64
    }
    public class PatchDef
    {
        /// <summary>
        /// The package name. Ex: microsoft-windows-usercpl
        /// </summary>
        public string WinSxSPackageName { get; set; }
        /// <summary>
        /// The package arch
        /// </summary>
        public PackageArch WinSxSPackageArch { get; set; }
        /// <summary>
        /// The name of the DLL in the package to be patched. Example: usercpl.dll.mun
        /// </summary>
        public string DllName { get; set; }
        /// <summary>
        /// The path where the hardlink by default points to. Example: C:\windows\systemresources\usercpl.dll.mun
        /// </summary>
        public string Systempath { get; set; }
        /// <summary>
        /// What the patcher should do
        /// </summary>
        public PatchInstruction[] PatchInstructions { get; set; }

        /// <summary>
        /// Represents a patch
        /// </summary>
        /// <param name="packageName">The package name. Ex: microsoft-windows-usercpl</param>
        /// <param name="packageArch">The package arch</param>
        /// <param name="dllToPatch">The name of the DLL in the package to be patched. Example: usercpl.dll.mun</param>
        public PatchDef(string packageName, PackageArch packageArch, string dllToPatch, string SystemPath, PatchInstruction[] instructions)
        {
            this.WinSxSPackageName = packageName;
            this.WinSxSPackageArch = packageArch;
            this.DllName = dllToPatch;
            this.Systempath = SystemPath;
            this.PatchInstructions = instructions;
        }
    }
    public class PatchInstruction
    {
        /// <summary>
        /// ResourceHacker action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// ResourceHacker resource ico
        /// </summary>
        public string Resource { get; set; }
        public string GroupAndLocation { get; set; }
        public PatchInstruction(string action, string resource, string type)
        {
            this.Action = action;
            this.Resource = resource;
            this.GroupAndLocation = type;
        }
    }
}

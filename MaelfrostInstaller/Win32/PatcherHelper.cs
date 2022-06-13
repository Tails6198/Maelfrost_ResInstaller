﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaelfrostInstaller.Win32
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    namespace Maelfrost
    {
        public class PatcherHelper
        {
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName,
              MoveFileFlags dwFlags);

            [Flags]
            enum MoveFileFlags
            {
                MOVEFILE_REPLACE_EXISTING = 0x00000001,
                MOVEFILE_COPY_ALLOWED = 0x00000002,
                MOVEFILE_DELAY_UNTIL_REBOOT = 0x00000004,
                MOVEFILE_WRITE_THROUGH = 0x00000008,
                MOVEFILE_CREATE_HARDLINK = 0x00000010,
                MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x00000020
            }
            public static bool TakeOwnership(string fileName)
            {
                Process takeOwnProcess = new Process();
                ProcessStartInfo takeOwnStartInfo = new ProcessStartInfo
                {
                    FileName = "takeown.exe",

                    // Do not write error output to standard stream.
                    RedirectStandardError = false,
                    // Do not write output to Process.StandardOutput Stream.
                    RedirectStandardOutput = false,
                    // Do not read input from Process.StandardInput (i/e; the keyboard).
                    RedirectStandardInput = false,

                    UseShellExecute = false,
                    // Do not show a command window.
                    CreateNoWindow = true,

                    Arguments = "/f " + fileName + " /a"
                };

                takeOwnProcess.EnableRaisingEvents = true;
                takeOwnProcess.StartInfo = takeOwnStartInfo;

                // Start the process.
                takeOwnProcess.Start();

                // Wait for the process to exit.
                takeOwnProcess.WaitForExit();

                int exitCode = takeOwnProcess.ExitCode;
                bool takeOwnSuccessful = true;

                // Now we need to see if the process was successful.
                if (exitCode > 0 & !takeOwnProcess.HasExited)
                {
                    takeOwnProcess.Kill();
                    takeOwnSuccessful = false;
                }

                // Now clean up after ourselves.
                takeOwnProcess.Dispose();
                return takeOwnSuccessful;
            }
            public static bool GrantFullControl(string fileName, string userName)
            {
                Process grantFullControlProcess = new Process();
                ProcessStartInfo grantFullControlStartInfo = new ProcessStartInfo();

                grantFullControlStartInfo.FileName = "icacls.exe";

                // Do not write error output to standard stream.
                grantFullControlStartInfo.RedirectStandardError = false;
                // Do not write output to Process.StandardOutput Stream.
                grantFullControlStartInfo.RedirectStandardOutput = false;
                // Do not read input from Process.StandardInput (i/e; the keyboard).
                grantFullControlStartInfo.RedirectStandardInput = false;

                grantFullControlStartInfo.UseShellExecute = false;
                // Do not show a command window.
                grantFullControlStartInfo.CreateNoWindow = true;

                grantFullControlStartInfo.Arguments = fileName + " /grant " + userName + ":(F)";

                grantFullControlProcess.EnableRaisingEvents = true;
                grantFullControlProcess.StartInfo = grantFullControlStartInfo;

                // Start the process.
                grantFullControlProcess.Start();

                // Wait for the process to finish.
                grantFullControlProcess.WaitForExit();

                int exitCode = grantFullControlProcess.ExitCode;
                bool grantFullControlSuccessful = true;

                // Now we need to see if the process was successful.
                if (exitCode > 0 & !grantFullControlProcess.HasExited)
                {
                    grantFullControlProcess.Kill();
                    grantFullControlSuccessful = false;
                }

                // Now clean up after ourselves.
                grantFullControlProcess.Dispose();
                return grantFullControlSuccessful;
            }
            public static bool ResetPermissions(string fileName)
            {
                Process resetPermissionsProcess = new Process();
                ProcessStartInfo resetPermissionsStartInfo = new ProcessStartInfo();

                resetPermissionsStartInfo.FileName = "icacls.exe";

                // Do not write error output to standard stream.
                resetPermissionsStartInfo.RedirectStandardError = false;
                // Do not write output to Process.StandardOutput Stream.
                resetPermissionsStartInfo.RedirectStandardOutput = false;
                // Do not read input from Process.StandardInput (i/e; the keyboard).
                resetPermissionsStartInfo.RedirectStandardInput = false;

                resetPermissionsStartInfo.UseShellExecute = false;
                // Do not show a command window.
                resetPermissionsStartInfo.CreateNoWindow = true;

                resetPermissionsStartInfo.Arguments = fileName + " /reset";

                resetPermissionsProcess.EnableRaisingEvents = true;
                resetPermissionsProcess.StartInfo = resetPermissionsStartInfo;

                // Start the process.
                resetPermissionsProcess.Start();

                // Wair for the process to finish.
                resetPermissionsProcess.WaitForExit();

                int exitCode = resetPermissionsProcess.ExitCode;
                bool resetPermissionsSuccessful = true;

                // Now we need to see if the process was successful.
                if (exitCode > 0 & !resetPermissionsProcess.HasExited)
                {
                    resetPermissionsProcess.Kill();
                    resetPermissionsSuccessful = false;
                }

                // Now clean up after ourselves.
                resetPermissionsProcess.Dispose();
                return resetPermissionsSuccessful;
            }
            public static bool ResetOwner(string fileName)
            {
                Process resetOwnerProcess = new Process();
                ProcessStartInfo resetOwnerStartInfo = new ProcessStartInfo();

                resetOwnerStartInfo.FileName = "icacls.exe";

                // Do not write error output to standard stream.
                resetOwnerStartInfo.RedirectStandardError = false;
                // Do not write output to Process.StandardOutput Stream.
                resetOwnerStartInfo.RedirectStandardOutput = false;
                // Do not read input from Process.StandardInput (i/e; the keyboard).
                resetOwnerStartInfo.RedirectStandardInput = false;

                resetOwnerStartInfo.UseShellExecute = false;
                // Do not show a command window.
                resetOwnerStartInfo.CreateNoWindow = true;

                resetOwnerStartInfo.Arguments = fileName + " /setowner " + "\"" + "NT Service\\TrustedInstaller" + "\"";

                resetOwnerProcess.EnableRaisingEvents = true;
                resetOwnerProcess.StartInfo = resetOwnerStartInfo;

                // Start the process.
                resetOwnerProcess.Start();

                //Wait for the process to finish.
                resetOwnerProcess.WaitForExit();

                int exitCode = resetOwnerProcess.ExitCode;
                bool resetOwnerSuccessful = true;

                // Now we need to see if the process was successful.
                if (exitCode > 0 & !resetOwnerProcess.HasExited)
                {
                    resetOwnerProcess.Kill();
                    resetOwnerSuccessful = false;
                }

                // Now clean up after ourselves.
                resetOwnerProcess.Dispose();
                return resetOwnerSuccessful;
            }
        }
    }
}

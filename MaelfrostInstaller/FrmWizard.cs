using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.InteropServices;
using MaelfrostInstaller.Pages;

namespace MaelfrostInstaller
{
    public partial class Form1 : Form
    {
        private static readonly WelcomePage WelcomePage = new();
        private static readonly EulaPage EulaPage = new();
        private static readonly ConfirmOperationPage ConfirmOpPage = new();
        private static readonly ProgressPage ProgressPage = new();

        private WizardPage CurrentPage;

        //Visual studio does not understand that we assign "CurrentPage" in Navigate()
#pragma warning disable CS8618
        public Form1()
#pragma warning restore CS8618
        {
            InitializeComponent();

            WelcomePage.InstallButton.Click += InstallButton_Click;
            WelcomePage.UninstallButton.Click += UninstallButton_Click;

            Navigate(WelcomePage);

            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
        }

        #region EULA Page
        private void AcceptButton_Click(object? sender, EventArgs e)
        {
            var pg = new TaskDialogPage()
            {
                Icon = TaskDialogIcon.ShieldErrorRedBar,

                Text = "Why did you click this button?",
                Heading = "Failure",
                Caption = "Project Maelfrost - Installer",
                Footnote = new TaskDialogFootnote()
                {
                    Text = "Really though, stop breaking things."
                },
                Expander = new TaskDialogExpander()
                {
                    Text = "You have attempted to navigate to a missing page. Well done you. Unfortunately, this operation has been stopped as it could cause a buffer overrun on your computer. This is bad. Press OK to go back to the welcome page. If this does not solve the issue - which it won't, please don't contact the author of this application."
                }
            };
            TaskDialog.ShowDialog(this, pg);
        }
        private void DenyButton_Click(object? sender, EventArgs e)
        {
            Navigate(WelcomePage);
        }
        #endregion
        #region Welcome Page
        private void InstallButton_Click(object? sender, EventArgs e)
        {

            Navigate(EulaPage);
        }
        private void UninstallButton_Click(object? sender, EventArgs e)
        {
            var pg = new TaskDialogPage()
            {
                Icon = TaskDialogIcon.ShieldErrorRedBar,

                Text = "Why did you click this button?",
                Heading = "Failure",
                Caption = "Project Maelfrost - Installer",
                Footnote = new TaskDialogFootnote()
                {
                    Text = "Really though, stop breaking things."
                },
                Expander = new TaskDialogExpander()
                {
                    Text = "You have attempted to uninstall something that's not even installed. In fact, this installer isn't even remotely complete. Why did you even try to click this button? Seems like a waste of your - and my - time. Thankfully, I did some error handling andthis operation has been stopped as it could cause a buffer overrun on your computer. As you may have guessed, that is bad. It is also not true at all, nothing would happen anyway. I just used this as an excuse to waste your time, as you have wasted mine. Press OK to admit to your mistakes. Perhaps Frozen Snow will forgive you, maybe."
                }
            };
            TaskDialog.ShowDialog(this, pg);
        }
        #endregion
        #region Navigation
        private void Navigate(WizardPage page)
        {
            CurrentPage = page;

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(page);

            lblTopText.Text = page.WizardTopText;

            if (page == EulaPage)
            {
                BtnBack.Visible = true;
                BtnNext.Visible = true;

                BtnBack.Enabled = true;
                BtnNext.Visible = true;

                BtnBack.ButtonText = "Disagree";
                BtnNext.ButtonText = "Agree";
            }
            else if (page == ConfirmOpPage)
            {
                BtnBack.Visible = true;
                BtnNext.Visible = true;

                BtnBack.Enabled = true;
                BtnNext.Enabled = true;

                BtnBack.ButtonText = "Back";
                BtnNext.ButtonText = "Install";
            }
            else
            {
                BtnBack.Visible = false;
                BtnNext.Visible = false;

                BtnBack.Enabled = false;
                BtnNext.Visible = false;

                BtnBack.ButtonText = "Back";
                BtnNext.ButtonText = "Next";
            }

            FixColors();
        }
        #endregion
        private void Form1_Shown(object sender, EventArgs e)
        {
            var buildNumber = Environment.OSVersion.Version.Build;

            _ = SetWindowTheme(this.Handle, "DarkMode_Explorer", null);
            _ = DarkMode.AllowDarkModeForWindow(this.Handle, true);

            SetTitlebarColor();

            try
            {
                //mica


                bool extend = Theme.IsUsingDarkMode;

                if (buildNumber >= 22523)
                {
                    int micaValue = 0x02;
                    _ = DwmSetWindowAttribute(this.Handle, WindowCompositionAttribute.DWMWA_SYSTEMBACKDROP_TYPE, ref micaValue, Marshal.SizeOf(typeof(int)));
                }

                else
                {
                    int trueValue = 0x01;
                    _ = DwmSetWindowAttribute(this.Handle, WindowCompositionAttribute.DWMWA_MICA_EFFECT, ref trueValue, Marshal.SizeOf(typeof(int)));
                }

                MARGINS m = new();
                if (extend)
                {
                    m.cyTopHeight = this.Height - pnlBottom.Height;
                    m.cyBottomHeight = pnlBottom.Height;

                    BackColor = Color.Black;
                }
                else
                {
                    BackColor = Color.White;
                    pnlTop.BackColor = Color.White;

                    m.cyTopHeight = pnlTop.Height;
                    panel1.BackColor = Color.Black;
                }
                _ = DwmExtendFrameIntoClientArea(this.Handle, ref m);
            }
            catch
            {

            }

            try
            {
                var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
                var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
                DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            }
            catch
            {

            }

            FixColors();
        }

        private void FixColors()
        {
            if (Theme.IsUsingDarkMode)
            {
                this.ForeColor = Color.White;
                foreach (var item in GetAllControls(this))
                {
                    if (item is not RichTextBox)
                    {
                        item.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                this.ForeColor = Color.Gray;
                foreach (var item in GetAllControls(this))
                {
                    item.ForeColor = Color.Black;
                }
            }
        }
        private IEnumerable<Control> GetAllControls(Control container)
        {
            List<Control> controlList = new();
            foreach (Control c in container.Controls)
            {
                controlList.AddRange(GetAllControls(c));
                controlList.Add(c);
            }
            return controlList;
        }

        private void SetTitlebarColor()
        {
            bool darkTheme = Theme.IsUsingDarkMode;
            var buildNumber = Environment.OSVersion.Version.Build;

            //Enable dark title bar
            if (buildNumber < 18362)
            {
                SetPropW(this.Handle, "UseImmersiveDarkModeColors", new IntPtr(darkTheme ? 1 : 0));
            }
            else
            {
                WindowCompositionAttributeData d = new()
                {
                    Attribute = WindowCompositionAttribute.WCA_USEDARKMODECOLORS
                };
                int size = Marshal.SizeOf(typeof(bool));
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(darkTheme, ptr, false);

                d.Data = ptr;
                d.SizeOfData = size;
                _ = SetWindowCompositionAttribute(this.Handle, ref d);
            }
            if (Marshal.GetLastWin32Error() != 0) { throw new Win32Exception(); }
        }


        #region Win32

        [DllImport("uxtheme.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        internal static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string? pszSubIdList);
        [DllImport("dwmapi.dll")]
        internal static extern int DwmSetWindowAttribute(IntPtr hwnd, WindowCompositionAttribute dwAttribute, ref int pvAttribute, int cbAttribute);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetPropW(IntPtr hwnd, string prop, IntPtr value);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern long DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }
        public enum WindowCompositionAttribute
        {
            // ...
            WCA_ACCENT_POLICY = 19,
            WCA_USEDARKMODECOLORS = 26,
            DWMWA_MICA_EFFECT = 1029,
            DWMWA_SYSTEMBACKDROP_TYPE = 38
            // ...
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;      // width of left border that retains its size
            public int cxRightWidth;     // width of right border that retains its size
            public int cyTopHeight;      // height of top border that retains its size
            public int cyBottomHeight;   // height of bottom border that retains its size
        };

        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        [DllImport("DwmApi.dll")]
        static extern int DwmExtendFrameIntoClientArea(
         IntPtr hwnd,
         ref MARGINS pMarInset);
        #endregion

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (CurrentPage == EulaPage)
            {
                //We have disagreed with the license
                Navigate(WelcomePage);
            }
            else if (CurrentPage == ConfirmOpPage)
            {
                //The user clicked on "Back" when on the confirm install/uninstall page
                Navigate(EulaPage);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage == EulaPage)
            {
                //We are about to install it
                Navigate(ConfirmOpPage);

                //Change text
                ConfirmOpPage.TextLable.Text = "You are about to do the following operation:\nInstall Project Maelfrost on top of this Windows Installation";
            }
            else if(CurrentPage == ConfirmOpPage)
            {
                //Install/Uninstall the OS
                Navigate(ProgressPage);
            }
        }
        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            switch (e.Category)
            {
                case UserPreferenceCategory.General:
                    Form1_Shown(this, new EventArgs());
                    lblTopText.Invalidate();
                    break;
            }
        }
    }
}
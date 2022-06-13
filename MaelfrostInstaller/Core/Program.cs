namespace MaelfrostInstaller
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Build >= 22000) { }
            else
            {
                Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
                MessageBox.Show("The Project Maelfrost installer is only supported when using the Maelfrost Framewor. Don't run this on Windows 11, it won't work.", "Compatibility Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ = DarkMode.fnAllowDarkModeForApp(DarkMode.PreferredAppMode.AllowDark);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new FrmWizard());
        }
    }
}
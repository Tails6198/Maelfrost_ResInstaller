﻿namespace MaelfrostInstaller.Pages
{
    public partial class ConfirmOperationPage : WizardPage
    {
        public Label TextLable
        {
            get
            {
                return lblOperation;
            }
            set
            {
                lblOperation = value;
            }
        }
        public ConfirmOperationPage()
        {
            InitializeComponent();
        }
    }
}

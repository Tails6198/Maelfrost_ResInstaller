﻿using AeroWizard;
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

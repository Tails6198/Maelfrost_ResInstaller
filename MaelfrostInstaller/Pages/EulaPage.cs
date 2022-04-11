﻿using MaelfrostInstaller.Controls;
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
    public partial class EulaPage : WizardPage
    {
        public WinUIButton DenyButton
        {
            get
            {
                return btnCancel;
            }
            set
            {
                btnCancel = value;
            }
        }
        public WinUIButton AcceptButton
        {
            get
            {
                return btnAccept;
            }
            set
            {
                btnAccept = value;
            }
        }
        public EulaPage()
        {
            InitializeComponent();
        }
    }
}

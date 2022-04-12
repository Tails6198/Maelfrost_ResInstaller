﻿using Microsoft.Win32;
using MaelfrostInstaller.Controls;
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
        public EulaPage()
        {
            InitializeComponent();
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            if (Theme.IsUsingDarkMode)
            {
                richTextBox1.BackColor = Color.Black;
                richTextBox1.ForeColor = Color.White;
            }
            else
            {
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
            }
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            switch (e.Category)
            {
                case UserPreferenceCategory.General:
                    if (Theme.IsUsingDarkMode)
                    {
                        richTextBox1.BackColor = Color.Black;
                        richTextBox1.ForeColor = Color.White;
                    }
                    else
                    {
                        richTextBox1.BackColor = Color.White;
                        richTextBox1.ForeColor = Color.Black;
                    }
                    break;
            }
        }
    }
}

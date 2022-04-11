﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaelfrostInstaller.Controls
{
    public class DarkAwareButton : Button
    {
        protected override void CreateHandle()
        {
            base.CreateHandle();
            _ = Form1.SetWindowTheme(this.Handle, "DarkMode_Explorer", null);
            FlatStyle = FlatStyle.System;
        }
    }
}

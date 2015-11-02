﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormControls
{
    public class MyTextBox:TextBox
    {
        private MyControlType _Type;
        [Category("Appearance"),
         DefaultValueAttribute(typeof(MyControlType), null),
         Description("Standard Appearance or not"),
         Browsable(true)]
        public MyControlType Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                if (_Type == MyControlType.Standard)
                {
                    StandardInitiate();
                }
            }
        }

        public MyTextBox()
        {
            _Type = MyControlType.Standard;
            StandardInitiate();
        }

        public void StandardInitiate()
        {
            StyleInitiate();
            SizeInitiate();
        }
        public void StyleInitiate()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void SizeInitiate()
        {
            this.Font = new Font("宋体", 12F, FontStyle.Bold);
            this.Width = 100;
            this.Height = 26;
        }

    }
}
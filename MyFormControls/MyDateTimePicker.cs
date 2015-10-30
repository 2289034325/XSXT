﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MyFormControls
{
    public class MyDateTimePicker:DateTimePicker
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

        public MyDateTimePicker()
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
            //this.BackColor = Color.Black;
            //this.ForeColor = Color.White;
        }

        public void SizeInitiate()
        {
            this.Font = new Font("宋体", 12F, FontStyle.Regular);
            this.Width = 215;
        }


    }
}

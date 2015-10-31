using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormControls
{
    public class MyGrid:DataGridView
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

        public MyGrid()
        {
            _Type = MyControlType.Standard;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;

            StandardInitiate();
        }

        public void StandardInitiate()
        {
            this.EnableHeadersVisualStyles = false;
            this.BackgroundColor = Color.Black;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;

            DataGridViewCellStyle hstl = new DataGridViewCellStyle();
            hstl.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hstl.BackColor = Color.Black;
            hstl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            hstl.ForeColor = Color.White;
            hstl.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            hstl.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            hstl.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            
            DataGridViewCellStyle cstl = new DataGridViewCellStyle();
            cstl.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cstl.BackColor = Color.Black;
            cstl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            cstl.ForeColor = Color.White;
            cstl.SelectionBackColor = Color.White;
            cstl.SelectionForeColor = Color.Black;
            cstl.WrapMode = System.Windows.Forms.DataGridViewTriState.False;

            DataGridViewCellStyle rhstl = new DataGridViewCellStyle();
            cstl.BackColor = Color.Black;

            this.ColumnHeadersDefaultCellStyle = hstl;
            this.DefaultCellStyle = cstl;
            this.RowHeadersDefaultCellStyle = rhstl;
        }
    }

    
}

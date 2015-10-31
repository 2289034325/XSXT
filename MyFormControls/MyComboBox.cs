using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormControls
{
    public class MyComboBox:ComboBox
    {
        public Color HighlightBackColor { get; set; }
        public Color HighlightForeColor { get; set; }

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

        public MyComboBox()
        {
            _Type = MyControlType.Standard;

            StandardInitiate();

            base.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.HighlightBackColor = Color.White;
            this.HighlightForeColor = Color.Black;
            this.DrawItem += new DrawItemEventHandler(AdvancedComboBox_DrawItem);
        }

        public void StandardInitiate()
        {
            StyleInitiate();
            SizeInitiate();
        }
        public void StyleInitiate()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
        }
        public void SizeInitiate()
        {
            this.Font = new Font("宋体", 12F, FontStyle.Bold);
            this.Width = 100;
        }

        void AdvancedComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(this.HighlightBackColor),
                                         e.Bounds);

                e.Graphics.DrawString(getText(combo.Items[e.Index]), e.Font,
                                      new SolidBrush(this.HighlightForeColor),
                                      new Point(e.Bounds.X, e.Bounds.Y+3));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                                         e.Bounds);

                e.Graphics.DrawString(getText(combo.Items[e.Index]), e.Font,
                                      new SolidBrush(combo.ForeColor),
                                      new Point(e.Bounds.X, e.Bounds.Y+3));
            }


            e.DrawFocusRectangle();
        }

        private string getText(object item)
        {
            string ret ="";
            if (item.GetType().Equals(
                typeof(DataRowView)))
            {
                ret = ((DataRowView)item)[this.DisplayMember].ToString();
            }
            else if (item.GetType().Equals(
                typeof(string)))
            {
                ret = item.ToString();
            }

            return ret;
        }
    }
}

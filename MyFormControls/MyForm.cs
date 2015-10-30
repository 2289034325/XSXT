using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormControls
{
    public enum MyControlType
    {
        Standard,
        Special
    }

    public class MyForm:Form
    {
        public void InitializeComponent()
        {
            //如果是主窗口，去掉窗口标题栏
            if (this.IsMdiContainer)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.ControlBox = false;
            }

            //去掉icon
            this.ShowIcon = false;

            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType().Equals(typeof(MenuStrip)))
                {
                    initMenu(ctrl);
                }
                else if (ctrl.GetType().Equals(typeof(MyPanel)))
                {
                    initPanel(ctrl);
                }
                else if (ctrl.GetType().Equals(typeof(MyLabel)))
                {
                    initLabel(ctrl);
                }
                else if (ctrl.GetType().Equals(typeof(MyButton)))
                {
                    initButton(ctrl);
                }
                else if (ctrl.GetType().Equals(typeof(MyTextBox)))
                {
                    initTextBox(ctrl);
                }
                else if (ctrl.GetType().Equals(typeof(MyDateTimePicker)))
                {
                    initDateTimePicker(ctrl);
                }
                else if (ctrl.GetType().Equals(typeof(MyComboBox)))
                {
                    initComboBox(ctrl);
                }
                

            }
        }

        private void initButton(Control ctrl)
        {
            MyButton bt = ctrl as MyButton;

            if (bt.Type == MyControlType.Standard)
            {
                bt.StandardInitiate();
            }
            else
            {
                bt.StyleInitiate();
            }
        }

        private void initDateTimePicker(Control ctrl)
        {
            MyDateTimePicker dtp = ctrl as MyDateTimePicker;

            if (dtp.Type == MyControlType.Standard)
            {
                dtp.StandardInitiate();
            }
            else
            {
                dtp.StyleInitiate();
            }
        }

        private void initComboBox(Control ctrl)
        {
            MyComboBox cmb = ctrl as MyComboBox;

            if (cmb.Type == MyControlType.Standard)
            {
                cmb.StandardInitiate();
            }
            else
            {
                cmb.StyleInitiate();
            }
        }

        private void initLabel(Control ctrl)
        {
            MyLabel lb = ctrl as MyLabel;
            if (lb.Type == MyControlType.Standard)
            {
                lb.StandardInitiate();
            }
            else
            {
                lb.StyleInitiate();
            }
        }

        private void initTextBox(Control ctrl)
        {
            MyTextBox txb = ctrl as MyTextBox;
            if (txb.Type == MyControlType.Standard)
            {
                txb.StandardInitiate();
            }
            else
            {
                txb.StyleInitiate();
            }
        }

        private void initMenu(Control ctrl)
        {
            MenuStrip mn = ctrl as MenuStrip;
            mn.Renderer = new MyRenderer();
            mn.BackColor = Color.Black;
            mn.CanOverflow = true;

            foreach (ToolStripMenuItem mi in mn.Items)
            {
                mi.ForeColor = Color.White;
                mi.BackColor = Color.Black;
                mi.Font = new Font("宋体", 20F, FontStyle.Bold);
                mi.AutoSize = false;
                mi.Overflow = ToolStripItemOverflow.AsNeeded;

                mi.MouseEnter += new System.EventHandler(this.mi_MouseEnter);
                mi.MouseLeave += new System.EventHandler(this.mi_MouseLeave);

                //子菜单
                mi.DropDown.BackColor = Color.Black;
                (mi.DropDown as ToolStripDropDownMenu).ShowImageMargin = false;
                foreach (ToolStripMenuItem cmi in mi.DropDownItems)
                {
                    cmi.ForeColor = Color.White;
                    cmi.BackColor = Color.Black;
                    cmi.Font = new Font("宋体", 20F, FontStyle.Bold);

                    cmi.MouseEnter += new System.EventHandler(this.mi_MouseEnter);
                    cmi.MouseLeave += new System.EventHandler(this.mi_MouseLeave);
                }
            }
        }

        private void initPanel(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                //grid
                if (c.GetType().Equals(typeof(MyGrid)))
                {
                    initGrid(c);
                }
                else if (c.GetType().Equals(typeof(MyLabel)))
                {
                    initLabel(c);
                }
                else if (c.GetType().Equals(typeof(MyButton)))
                {
                    initButton(c);
                }
                else if (c.GetType().Equals(typeof(MyTextBox)))
                {
                    initTextBox(c);
                }
                else if (c.GetType().Equals(typeof(MyDateTimePicker)))
                {
                    initDateTimePicker(c);
                }
                else if (c.GetType().Equals(typeof(MyComboBox)))
                {
                    initComboBox(c);
                }
            }
        }

        private void initGrid(Control c)
        {
            MyGrid grid = c as MyGrid;
            grid.StandardInitiate();
        }

        /// <summary>
        /// 改变menuItem的背景色
        /// </summary>
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    
                    e.Graphics.FillRectangle(Brushes.White, rc);
                    e.Graphics.DrawRectangle(Pens.White, 1, 0, rc.Width - 2, rc.Height - 1);
                }
            }
        }
        private void mi_MouseEnter(object sender, EventArgs e)
        {
            ToolStripItem mi = sender as ToolStripItem;
            mi.ForeColor = Color.Black;
            mi.BackColor = Color.White;
        }
        private void mi_MouseLeave(object sender, EventArgs e)
        {
            ToolStripItem mi = sender as ToolStripItem;
            mi.ForeColor = Color.White;
            mi.BackColor = Color.Black;
        }

        public virtual void OnScan(string tm)
        {
            //基类中扫描都不做，让子窗口自己实装            
        }
    }
}

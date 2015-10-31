using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormControls
{
    public class MyTitle:Label
    {
        public MyTitle()
        {
            //设计模式下的颜色
            //this.BackColor = Color.White;
            //this.ForeColor = Color.Black;
            this.Font = new Font("宋体", 12F, FontStyle.Bold);

            this.MouseEnter += new System.EventHandler(this.lbl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
            this.BackColor = Color.White;
            
            
        }
        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            ToolStripItem mi = sender as ToolStripItem;
            mi.ForeColor = Color.White;
            mi.BackColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //ControlPaint.DrawBorder(e.Graphics, this.DisplayRectangle, Color.White, ButtonBorderStyle.Solid);
        }
    }
}

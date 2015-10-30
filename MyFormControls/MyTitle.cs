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
            this.MouseEnter += new System.EventHandler(this.tt_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.tt_MouseLeave);
        }

        private void tt_MouseEnter(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
            this.BackColor = Color.White;
        }
        private void tt_MouseLeave(object sender, EventArgs e)
        {
            ToolStripItem mi = sender as ToolStripItem;
            mi.ForeColor = Color.White;
            mi.BackColor = Color.Black;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpFinalTDP2015.UI.AdminModePages
{
    public class AdminModePage : Form
    {
        public AdminModePage() : base() { }
        public AdminModePage GetAsPage()
        {
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            return this;
        }
    }
}
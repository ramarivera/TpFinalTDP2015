using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.UI.AdminModePages;

namespace TpFinalTDP2015.UI
{
    public partial class ModoAdministrador : Form
    {
        public ModoAdministrador()
        {
            InitializeComponent();
            this.Load += ModoAdministrador_Load;
        }

        public string PageName
        {
            set { this.lblPageName.Text = value; }
        }

        private AdminModePage SelectedPage
        {
            set
            {
                if (tableLayoutPanel3.Controls.Count > 1)
                {
                    tableLayoutPanel3.Controls.RemoveAt(1);
                }
                this.tableLayoutPanel3.Controls.Add(value);
                value.Show();
            }
        }

        private void ModoAdministrador_Load(object sender, EventArgs e)
        {
            this.ParseNames();
        }

        private void ParseNames()
        {
            IList<String> lList = AdminModePagesFactory.Instance.PageNames;

            foreach (string name in lList)
            {
                treeView1.Nodes.Add(name);
            }

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string lPageName = String.Empty;

            if (treeView1.SelectedNode != null)
            {
                lPageName = treeView1.SelectedNode.Text;
                AdminModePage lPage = AdminModePagesFactory.Instance.GetAdminModePage(lPageName);
                this.SelectedPage = lPage;
                this.PageName = lPageName;
            }

           // AdminModePage lPage = AdminModePagesFactory.Instance.GetAdminModePage(lPageName);
           // TODO: Pagina Nula

            
        }
    }
}

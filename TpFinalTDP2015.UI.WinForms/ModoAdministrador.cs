using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.UI.AdminModePages;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.UI
{
    public partial class ModoAdministrador : BaseForm
    {
        private IControllerFactory iContFactory;


        public ModoAdministrador(IControllerFactory pFactory)
        {
            this.iContFactory = pFactory; 
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
                if (pnlRightPanel.Controls.Count > 1)
                {
                    pnlRightPanel.Controls.RemoveAt(1);
                }
                this.pnlRightPanel.Controls.Add(value);
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
                trvPageNames.Nodes.Add(name);
            }

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string lPageName = String.Empty;

            if (trvPageNames.SelectedNode != null)
            {
                lPageName = trvPageNames.SelectedNode.Text;
               
            }
            AdminModePage lPage = AdminModePagesFactory.Instance.GetAdminModePage(this.iContFactory, lPageName);
            this.PageName = lPageName;
            this.SelectedPage = lPage;
            

            // AdminModePage lPage = AdminModePagesFactory.Instance.GetAdminModePage(lPageName);
            // TODO: Pagina Nula


        }
    }
}

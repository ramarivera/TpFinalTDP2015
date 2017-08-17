using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    public partial class AdminModePage : BaseForm
    {
        protected IControllerFactory iFactory;

        public AdminModePage(IControllerFactory pFactory) : base()
        {
            this.iFactory = pFactory;
        }

        public AdminModePage GetAsPage()
        {
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            return this;
        }
    }
}
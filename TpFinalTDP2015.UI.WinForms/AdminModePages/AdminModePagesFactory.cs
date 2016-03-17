using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    public class AdminModePagesFactory
    {
        private IDictionary<string, AdminModePage> iAdminModePages;
        private IList<String> iNameList;
        private readonly IControllerFactory iFactory;

        public AdminModePagesFactory(IControllerFactory pFactory)
        {
            this.iFactory = pFactory;
            iAdminModePages = new Dictionary<string, AdminModePage>();

            iNameList = new List<String>();

            foreach (Type t in this.GetType().Assembly.GetTypes())
            {
                Attribute[] attrs = Attribute.GetCustomAttributes(t);

                foreach (Attribute attr in attrs)
                {
                    if (attr is AdminModePageInfo)
                    {
                        string lName = ((AdminModePageInfo)attr).Name;
                        iNameList.Add(lName);
                        AdminModePage lPage = (AdminModePage)Activator.CreateInstance(t, new object[] { this.iFactory });
                        //TODO Ajustar esto, no deberia ser publica?
                        //TODO Ajustar y usar lazy Init
                        //TODO revisar tema excepcion de reflection
                        iAdminModePages.Add(lName, lPage.GetAsPage());
                    }
                }
            }
            /* StringBuilder sb = new StringBuilder();
             foreach (Exception exSub in ex.LoaderExceptions)
             {
                 sb.AppendLine(exSub.Message);
                 FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                 if (exFileNotFound != null)
                 {
                     if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                     {
                         sb.AppendLine("Fusion Log:");
                         sb.AppendLine(exFileNotFound.FusionLog);
                     }
                 }
                 sb.AppendLine();
             }
             string errorMessage = sb.ToString();*/

        }

        public IList<String> PageNames
        {
            get { return iNameList; }
        }

        public AdminModePage GetPage(string lPageName)
        {
            AdminModePage lResult = null;

            if (!iAdminModePages.TryGetValue(lPageName, out lResult))
            {
                lResult = iAdminModePages["Null"];
            }

            return lResult;
        }

    }
}

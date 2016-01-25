using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpFinalTDP2015.UI.AdminModePages
{
    public class AdminModePagesFactory
    {
        private static AdminModePagesFactory cInstance;

        private Dictionary<string, AdminModePage> iAdminModePages;

        private IList<String> iNameList;

        private AdminModePagesFactory()
        {
            iAdminModePages = new Dictionary<string, AdminModePage>();

            iNameList = new List<String>();

            var types = AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .SelectMany(s => s.GetTypes());

            foreach (Type t in types)
            {
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

                foreach (System.Attribute attr in attrs)
                {
                    if (attr is AdminModePageInfo)
                    {
                        string lName = ((AdminModePageInfo)attr).Name;
                        iNameList.Add(lName);
                        AdminModePage lPage = (AdminModePage) Activator.CreateInstance(t);
                        iAdminModePages.Add(lName, lPage.GetAsPage());
                    }
                }
            }
        }

        public static AdminModePagesFactory Instance
        {
            get
            {
                if (cInstance == null)
                    cInstance = new AdminModePagesFactory();
                return cInstance;
            }
        }
        
        public IList<String> PageNames
        {
            get { return iNameList; }
        }

        public AdminModePage GetAdminModePage(string nombre)
        {
            AdminModePage lResult = null;

            if (!iAdminModePages.TryGetValue(nombre, out lResult))
            {
                lResult = iAdminModePages["Null"];
            }

            return lResult.GetAsPage();
        }

        /*public IList<String> Initialize()
        {
            if (cNameList == null)
            {
                cNameList = new List<String>();

                var types = AppDomain
                        .CurrentDomain
                        .GetAssemblies()
                        .SelectMany(s => s.GetTypes());

                foreach (Type t in types)
                {
                    System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

                    foreach (System.Attribute attr in attrs)
                    {
                        if (attr is AdminModePageInfo)
                        {
                            cNameList.Add(((AdminModePageInfo)attr).Name);
                        }
                    }
                }

            }

            return cNameList;
                        
        }*/
    }
}

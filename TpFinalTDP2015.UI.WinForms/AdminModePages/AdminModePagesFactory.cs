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
        private static AdminModePagesFactory cInstance;

        private Dictionary<string, AdminModePage> iAdminModePages;

        private IList<String> iNameList;

        private AdminModePagesFactory()
        {
            try
            {
                iAdminModePages = new Dictionary<string, AdminModePage>();

                iNameList = new List<String>();

                foreach (Type t in this.GetType().Assembly.GetTypes())
                {
                    System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

                    foreach (System.Attribute attr in attrs)
                    {
                        if (attr is AdminModePageInfo)
                        {
                            string lName = ((AdminModePageInfo)attr).Name;
                            iNameList.Add(lName);
                            AdminModePage lPage = (AdminModePage)Activator.CreateInstance(t, new object[] { });
                            //TODO Ajustar esto, no deberia ser publica?
                            //TODO Ajustar y usar lazy Init
                            //TODO revisar tema excepcion de reflection
                            iAdminModePages.Add(lName, lPage.GetAsPage());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                //Display or log the error based on your application.
            }
            
        }

        internal AdminModePage GetAdminModePage(IControllerFactory iContFactory, string lPageName)
        {
            throw new NotImplementedException();
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

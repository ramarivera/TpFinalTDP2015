using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service;

namespace TpFinalTDP2015.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"App.config");
            AutoMapperConfigurations.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ModoAdministrador());
        }
    }
}

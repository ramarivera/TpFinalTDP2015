using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TpFinalTDP2015.BusinessLogic;
using TpFinalTDP2015.BusinessLogic.Services;
using TpFinalTDP2015.BusinessLogic.DTO;
using TpFinalTDP2015.BusinessLogic.Enum;

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

            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"TpFinalTDP2015.config");
            AutoMapperConfiguration.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ModoAdministrador());
        }
    }
}

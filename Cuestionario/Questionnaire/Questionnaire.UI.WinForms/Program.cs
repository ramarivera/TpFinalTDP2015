using Microsoft.Extensions.Logging;
using Questionnaire.CrossCutting.Logging;
using Questionnaire.Handlers;
using Questionnaire.Services.DependencyInjection;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Questionnaire.UI.WinForms
{
    static class Program
    {
        private static IContainer mContainer;
        private static ILogger mLogger;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mContainer = Bootstrapper.BootstrapApplication();
            mLogger = mContainer.Resolve<LoggingFactory>().GetLoggerFor(typeof(Program));

            Application.Run(new StartUpView());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var lEx = (e.ExceptionObject as Exception);
            mLogger.LogError(lEx, "Uh oh. There was a problem");
            MessageBox.Show("Uh oh. There was a problem: " + lEx.Message);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var lEx = (e.Exception as Exception);
            mLogger.LogError(lEx, "Uh oh. There was a problem");
            MessageBox.Show("Uh oh. There was a problem: " + lEx.Message);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpFinalTDP2015.Persistence.EntityFramework;
using Common.Logging;

namespace TpFinalTDP2015.Test.Persistence.EF
{
    [TestClass]
    public class Context
    {
        private static readonly ILog cLogger = LogManager.GetLogger<Context>();

        [TestMethod]
        public void Seed()
        {
            DigitalSignageContext lContext = new DigitalSignageContext();
            cLogger.Info("Hola");
            Assert.IsTrue(true);
        }
    }
}

using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    internal class ServiceFactory : IDisposable
    {
        private IDisposable tran;

        public ServiceFactory(IDisposable tran)
        {
            this.tran = tran;
        }
    }
}
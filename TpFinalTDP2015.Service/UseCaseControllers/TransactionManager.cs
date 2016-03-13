using MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection;
using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using Microsoft.Practices.Unity;
using System.Data;
using System.Linq;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class TransactionManager : IDisposable
    {
        private IUnitOfWork iUnitOfWork;
        private static IUnityContainer cContainer = null;
        private IUnityContainer iContainer;


        private TransactionManager(IUnityContainer pContainer, IUnitOfWork pUoW, IsolationLevel pIsoLvl)
        {
            this.iContainer = pContainer;
            this.iUnitOfWork = pUoW;
            this.iUnitOfWork.BeginTransaction(pIsoLvl);
        }


        public static TransactionManager StartTransaction(IsolationLevel pIsoLvl = IsolationLevel.ReadUncommitted)
        {
            return StartTransaction(cContainer, pIsoLvl);
        }

        public static TransactionManager StartTransaction(IUnityContainer pContainer, IsolationLevel pIsoLvl = IsolationLevel.ReadUncommitted)
        {
            return new TransactionManager(pContainer, pContainer.Resolve<IUnitOfWork>(), pIsoLvl);
        }

        public void CloseTransaction()
        {
            this.iUnitOfWork.Commit();
        }

        public void CancelTransaction()
        {
            this.iUnitOfWork.Rollback();
        }

        public T GetService<T>() where T : class
        {
            // Verifico si T implementa la interfaz IServcice<TEntity>
            bool lIsService = typeof(T).
                                GetInterfaces().
                                Where(i => i.IsGenericType).
                                Any(i => i.GetGenericTypeDefinition() == typeof(IService<>));
            if (lIsService)
            {
                // Resuelvo el servicio usando el contenedor estatico, y me aseguro de que en toda la construccion del grafo
                // se use la misma IunitOfWork
                return iContainer.Resolve<T>(new DependencyOverride<IUnitOfWork>(this.iUnitOfWork));
            }
            else
            {
                throw new InvalidOperationException();

            }
            
        }

        internal static void RegisterContainer(IUnityContainer pContainer)
        {
                // Si no se invoco previamente, guarda la instancia del contenedor para ser usada por las instancias de la clase
                cContainer = pContainer;
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TransactionManager() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
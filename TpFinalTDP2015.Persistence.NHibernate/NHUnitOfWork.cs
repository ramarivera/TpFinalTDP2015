using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MarrSystems.TpFinalTDP2015.Persistence.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private ISession iSession;
        private ITransaction iTransaction;
        private IsolationLevel iIsoLevel;
        private bool iDisposed = false;
        private IDictionary<Type, Object> iRepositories;

        public NHUnitOfWork(IsolationLevel pIsolationLevel = IsolationLevel.ReadCommitted)
        {

            this.OpenSession();
            this.iIsoLevel = pIsolationLevel;
            this.iRepositories = new Dictionary<Type, Object>();
        }


        #region IDisposable
        ~NHUnitOfWork()
        {
            // The object went out of scope and finalized is called
            // Lets call dispose in to release unmanaged resources 
            // the managed resources will anyways be released when GC 
            // runs the next time.
            Dispose(false);
        }

        protected virtual void Dispose(bool pDisposing)
        {
            if (!iDisposed)
            {
                if (pDisposing)
                {
                    //someone want the deterministic release of all resources
                    //Let us release all the managed resources
                    if (this.iRepositories != null)
                    {
                        foreach (var key in this.iRepositories.Keys.ToList<Type>())
                        {
                            this.iRepositories[key] = null;
                        }
                        this.iRepositories.Clear();
                    }

                    if (this.iTransaction != null)
                    {
                        this.iTransaction.Dispose();
                    }

                    if (this.iSession != null)
                    {
                        this.iSession.Dispose();
                    }
                }
                else
                {
                    // Do nothing, no one asked a dispose, the object went out of
                    // scope and finalized is called so lets next round of GC 
                    // release these resources
                }

                // Release the unmanaged resource in any case as they will not be 
                // released by GC

                this.iTransaction = null;
                this.iSession = null;
                this.iRepositories = null;


                this.iDisposed = true;
            }
        }

        public virtual void Dispose()
        {
            // If this function is being called the user wants to release the
            // resources. lets call the Dispose which will do this for us.
            Dispose(true);

            // Now since we have done the cleanup already there is nothing left
            // for the Finalizer to do. So lets tell the GC not to call it later.
            GC.SuppressFinalize(this);
        }

        #endregion


        private void OpenSession()
        {
            if (this.iSession == null || !this.iSession.IsConnected)
            {
                if (this.iSession != null)
                    this.iSession.Dispose();

                this.iSession = NHSessionFactory.SessionFactory.OpenSession();
            }
        }

        IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
        {
            IRepository<TEntity> lRepo;

            if (this.iRepositories.ContainsKey(typeof(TEntity)))
            {
                lRepo = (IRepository<TEntity>)this.iRepositories[typeof(TEntity)];
            }
            else
            {
                lRepo = new NHRepository<TEntity>(this.iSession);
                this.iRepositories.Add(typeof(TEntity), lRepo);
            }

            return lRepo;

        }

        void IUnitOfWork.BeginTransaction()
        {
            if (this.iTransaction == null || !this.iTransaction.IsActive)
            {
                if (this.iTransaction != null)
                    this.iTransaction.Dispose();

                this.iTransaction = this.iSession.BeginTransaction(iIsoLevel);
            }
        }

        void IUnitOfWork.Commit()
        {
            try
            {
                this.iTransaction.Commit();
            }
            catch
            {
                //TODO convertir excepcion de EF a excepcion general de persistencia y arrojarla
                throw;
            }
        }

        void IUnitOfWork.Rollback()
        {
            this.iTransaction.Rollback();
        }


    }
}

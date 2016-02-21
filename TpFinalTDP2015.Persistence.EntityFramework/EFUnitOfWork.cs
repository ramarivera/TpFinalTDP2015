﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Persistence.Interfaces;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IDbContext iContext;
        private DbContextTransaction iTransaction;
        private bool iDisposed = false;
        private IDictionary<Type, Object> iRepositories;

        public EFUnitOfWork(IDbContext pContext)
        {
            this.iContext = pContext;
            this.iRepositories = new Dictionary<Type, Object>();
            //TODO levantar el dato de un archivo de configuracion
        }

        #region IDisposable
        ~EFUnitOfWork()
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

                    if (this.iContext != null)
                    {
                        this.iContext.Database.Connection.Close();
                        this.iContext.Dispose();
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
                this.iContext = null;
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

        void IUnitOfWork.BeginTransaction(IsolationLevel pIsolationLevel)
        {
            if (this.iTransaction == null)
            {
                if (this.iTransaction != null)
                {
                    this.iTransaction.Dispose();
                }

                this.iTransaction = this.iContext.BeginTransaction(pIsolationLevel);
            }
        }

        void IUnitOfWork.Commit()
        {
            try
            {
                this.iContext.SaveChanges();
                this.iTransaction.Commit();
            }
            catch (Exception e)
            {
                //TODO convertir excepcion de EF a excepcion general de persistencia y arrojarla
                this.iTransaction.Rollback();
                throw e;
            }
        }

        void IUnitOfWork.Rollback()
        {
            this.iTransaction.Rollback();
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
                lRepo = new EFRepository<TEntity>(this.iContext);
                this.iRepositories.Add(typeof(TEntity), lRepo);
            }

            return lRepo;

        }

    }
}

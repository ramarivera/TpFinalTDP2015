using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Persistence.Interfaces;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Service.Controllers
{
    public abstract class BaseController<TDto> : IController<TDto> where TDto : IDTO
    {
        protected IUnitOfWork iUoW;

        public BaseController(IUnitOfWork pUoW)
        {
            this.iUoW = pUoW;
        }

        public abstract void Delete(TDto pId);

        public abstract IList<TDto> GetAll();

        public abstract TDto Get(int pId);

        public abstract int Save(TDto pDTO);

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (this.iUoW != null)
                    {
                        this.iUoW.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.


                //TODO necesito probar asi que POR AHORA esto queda aca

                this.iUoW = null;

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~BaseController()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

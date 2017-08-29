using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageSourceHandler: IController, IDisposable
    {
        private readonly IUnitOfWork iUoW;
        private readonly IRssSourceService iServ;

        public ManageSourceHandler(IUnitOfWork pUoW, IRssSourceService pService)
        {
            this.iUoW = pUoW;
            this.iServ = pService;
        }

        public int AddSource(RssSourceDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                RssSource lSource = Mapper.Map<RssSourceDTO, RssSource>(pDto);
                iServ.Create(lSource);
                iUoW.Commit();
                return lSource.Id;
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }
        }

        public void ModifySource(RssSourceDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                RssSource lSource = Mapper.Map<RssSourceDTO, RssSource>(pDto);
                iServ.Update(lSource);
                iUoW.Commit();
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }

        }

        public void DeleteSource(RssSourceDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                RssSource lSource = Mapper.Map<RssSourceDTO, RssSource>(pDto);
                iServ.Delete(pDto.Id);
                iUoW.Commit();
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }
        }


        public IList<RssSourceDTO> ListSources()
        {
            IList<RssSourceDTO> lResult = new List<RssSourceDTO>();
            iUoW.BeginTransaction();
            try
            {
                foreach (var rss in iServ.GetAll())
                {
                    RssSourceDTO lDto = Mapper.Map<RssSource, RssSourceDTO>(rss);
                    lResult.Add(lDto);
                }

            }
            finally
            {
                iUoW.Rollback();
            }

            return lResult;
        }

        public RssSourceDTO GetSource(int pId)
        {
            RssSourceDTO lResult = new RssSourceDTO();

            iUoW.BeginTransaction();
            try
            {
                var tipos = Mapper.GetAllTypeMaps();
                lResult = Mapper.Map<RssSource, RssSourceDTO>(iServ.Read(pId));
            }
            finally
            {
                iUoW.Rollback();
            }
            return lResult;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.iUoW.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}

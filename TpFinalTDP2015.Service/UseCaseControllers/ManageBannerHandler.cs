using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using AutoMapper;
using System;
using MarrSystems.TpFinalTDP2015.Persistence;
using System.Collections.Generic;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageBannerHandler : IController, IDisposable
    {
        private readonly IUnitOfWork iUoW;
        private readonly IBannerService iServ;

        public ManageBannerHandler(IUnitOfWork pUow, IBannerService pServ)
        {
            this.iUoW = pUow;
            this.iServ = pServ;
        }

        public void AddBanner(AdminBannerDTO pDto) { }
        /* {
             using (var serv = BusinessServiceLocator.Resolve<BannerService>())
             {
                 Banner lBanner = Mapper.Map<AdminBannerDTO, Banner>(pDto);
                 serv.Save(lBanner);
             }
         }*/

        public void ModifyBanner(AdminBannerDTO pDto) { }
        //TODO: update

        public void DeleteBanner(int pId)
        {
        }

        public IList<AdminBannerDTO> ListBanner()
        {
            IList<AdminBannerDTO> lResult = new List<AdminBannerDTO>();

                foreach (var banner in iServ.GetAll())
                {
                    AdminBannerDTO lDto = Mapper.Map<Banner, AdminBannerDTO>(banner);
                    lResult.Add(lDto);
                }
            return lResult;
        }

        public AdminBannerDTO GetBanner(int pId)
        {
            AdminBannerDTO lResult = new AdminBannerDTO();

                lResult = Mapper.Map<Banner, AdminBannerDTO>(iServ.Read(pId));
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

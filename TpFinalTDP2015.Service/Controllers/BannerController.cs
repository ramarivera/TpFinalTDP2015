using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using TpFinalTDP2015.Persistence.Interfaces;
using Microsoft.Practices.Unity;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.DTO;
using AutoMapper;
using TpFinalTDP2015.CrossCutting;

namespace TpFinalTDP2015.Service.Controllers
{
    public class BannerController
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<BannerController>();

        private IUnitOfWork iUoW;


        public BannerController()
        {
            cLogger.Info("Fachada instanciada");

            using (iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();

                cLogger.InfoFormat("Usando {0} como implementacion de {1}", new[] { iUoW.GetType().Name, typeof(IUnitOfWork).Name });


                iUoW.Commit();
            }
        }

        private IUnitOfWork GetUnitOfWork()
        {
            return IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>();
        }
        public IList<AdminBannerDTO> GetBanners()
        {
            IList<AdminBannerDTO> lResult = new List<AdminBannerDTO>();

            using (this.iUoW = GetUnitOfWork())
            {
                IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
                IList<Banner> lTemp = lRepo.GetAll().ToList();

                foreach (var banner in lTemp)
                {
                    AdminBannerDTO lDto = Mapper.Map<Banner, AdminBannerDTO>(banner);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public void SaveBanner(AdminBannerDTO pBanner)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
                Banner lBanner = Mapper.Map<AdminBannerDTO, Banner>(pBanner);
                if (pBanner.Id == 0)
                {
                    lRepo.Add(lBanner);
                }
                else
                {
                    lRepo.Update(lBanner);
                }
                iUoW.Commit();
            }
        }

        public void DeleteBanner(AdminBannerDTO pBanner)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
                Banner lBanner = Mapper.Map<AdminBannerDTO, Banner>(pBanner);
                lRepo.Delete(lBanner.Id);
                iUoW.Commit();
            }
        }
    }
}

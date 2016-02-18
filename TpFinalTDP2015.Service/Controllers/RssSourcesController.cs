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


namespace TpFinalTDP2015.Service.Controllers
{
    public class RssSourcesController
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<RssSourcesController>();

        private IUnitOfWork iUoW;

        public RssSourcesController()
        {
        }

        private IUnitOfWork GetUnitOfWork()
        {
            return IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>();
        }
        public IList<RssSourceDTO> GetRssSources()
        {
            IList<RssSourceDTO> lResult = new List<RssSourceDTO>();

            using (this.iUoW = GetUnitOfWork())
            {
                IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();
                IList<RssSource> lTemp = lRepo.GetAll().ToList();

                foreach (var rssSource in lTemp)
                {
                    RssSourceDTO lDto = Mapper.Map<RssSource, RssSourceDTO>(rssSource);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public void SaveRssSource(RssSourceDTO pRssSource)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();
                RssSource lRssSource = Mapper.Map<RssSourceDTO, RssSource>(pRssSource);
                if (pRssSource.Id == 0)
                {
                    lRepo.Add(lRssSource);
                }
                else
                {
                    lRepo.Update(lRssSource);
                }
                iUoW.Commit();
            }
        }

        public void DeleteRssSource(RssSourceDTO pRssSource)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();
                RssSource lRssSource = Mapper.Map<RssSourceDTO, RssSource>(pRssSource);
                lRepo.Delete(lRssSource.Id);
                iUoW.Commit();
            }
        }
    }
}

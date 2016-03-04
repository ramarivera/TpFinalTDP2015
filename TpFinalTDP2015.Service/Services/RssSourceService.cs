using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using MarrSystems.TpFinalTDP2015.Persistence;
using Microsoft.Practices.Unity;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using AutoMapper;


namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class RssSourceService : BaseService<RssSourceDTO>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<RssSourceService>();

        public RssSourceService(IUnitOfWork iUoW): base(iUoW)
        {
        }

        public override int Save(RssSourceDTO pRssSource)
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
            return lRssSource.Id;
        }

        public override void Delete(RssSourceDTO pRssSource)
        {
            iUoW.BeginTransaction();
            IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();
            RssSource lRssSource = Mapper.Map<RssSourceDTO, RssSource>(pRssSource);
            lRepo.Delete(lRssSource.Id);
            iUoW.Commit();
        }
        public override IList<RssSourceDTO> GetAll()
        {
            IList<RssSourceDTO> lResult = new List<RssSourceDTO>();

            IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();
            IList<RssSource> lTemp = lRepo.GetAll().ToList();

            foreach (var rssSource in lTemp)
            {
                RssSourceDTO lDto = Mapper.Map<RssSource, RssSourceDTO>(rssSource);
                lResult.Add(lDto);
            }

            return lResult.ToList<RssSourceDTO>();
        }

        public override RssSourceDTO Get(int pId)
        {
            RssSourceDTO lResult = new RssSourceDTO();

            IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();

            var lTemp = lRepo.GetByID(pId);

            lResult = Mapper.Map<RssSource, RssSourceDTO>(lTemp);

            return lResult;
        }
    }
}

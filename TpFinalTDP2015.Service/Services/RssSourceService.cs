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
    public class RssSourceService : BaseService<RssSource>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<RssSourceService>();

        public RssSourceService(IUnitOfWork iUoW): base(iUoW)
        {
        }

        public override int Save(RssSource pRssSource)
        {
            iUoW.BeginTransaction();
            IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();

            if (pRssSource.Id == 0)
            {
                lRepo.Add(pRssSource);
            }
            else
            {
                lRepo.Update(pRssSource);
            }

            iUoW.Commit();
            return pRssSource.Id;
        }

        public override void Delete(int pId)
        {
            iUoW.BeginTransaction();
            iUoW.GetRepository<RssSource>().Delete(pId);
            iUoW.Commit();
        }
        public override IList<RssSource> GetAll()
        {
            IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();
            IList<RssSource> lResult = lRepo.GetAll().ToList();

            return lResult;
        }

        public override RssSource Get(int pId)
        {
            RssSource lResult = new RssSource();

            IRepository<RssSource> lRepo = iUoW.GetRepository<RssSource>();

            var lTemp = lRepo.GetByID(pId);

            lResult = Mapper.Map<RssSource, RssSource>(lTemp);

            return lResult;
        }
    }
}

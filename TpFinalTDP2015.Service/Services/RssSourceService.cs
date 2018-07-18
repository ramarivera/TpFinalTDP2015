using log4net;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class RssSourceService : IRssSourceService
    {
        private readonly IRepository<RssSource> iRepo;

        public RssSourceService(IRepository<RssSource> pRepo)
        {
            this.iRepo = pRepo;
        }

        int ICrudService<RssSource>.Create(RssSource pSource)
        {
            iRepo.Add(pSource);
            return pSource.Id;
        }

        RssSource ICrudService<RssSource>.Read(int pId)
        {
            return iRepo.GetByID(pId);
        }

        int ICrudService<RssSource>.Update(RssSource pSource)
        {
            iRepo.Update(pSource);
            return pSource.Id;
        }

        void ICrudService<RssSource>.Delete(int pId)
        {
            iRepo.Delete(pId);
        }

        IEnumerable<RssSource> ICrudService<RssSource>.GetAll()
        {
            return iRepo.GetAll().ToList();
        }
    }
}

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
    public class CampaignService : BaseService<Campaign>
    { 
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<CampaignService>();

        public CampaignService(IUnitOfWork iUoW) : base(iUoW) { }

        public override int Save(Campaign pCampaign)
        {
            iUoW.BeginTransaction();
            IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();

            //Campaign lCampaign = Mapper.Map<CampaignDTO, Campaign>(pCampaign);
            if (pCampaign.Id == 0)
            {
                lRepo.Add(pCampaign);
            }
            else
            {
                lRepo.Update(pCampaign);
            }
            iUoW.Commit();
            return pCampaign.Id;
        }

        public override void Delete(int pId)
        {
            iUoW.BeginTransaction();
            IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
            //Campaign lCampaign = Mapper.Map<CampaignDTO, Campaign>(pCampaign);
            lRepo.Delete(pId);
            iUoW.Commit();
        }

        public override IList<Campaign> GetAll()
        {
            IList<Campaign> lResult = new List<Campaign>();

            IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
            IList<Campaign> lTemp = lRepo.GetAll().ToList();

            foreach (var campaign in lTemp)
            {
                //CampaignDTO lDto = Mapper.Map<Campaign, CampaignDTO>(campaign);
                lResult.Add(campaign);
            }

            return lResult;
        }

        public override Campaign Get(int pId)
        {
            Campaign lResult = new Campaign();

            IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();

            var lTemp = lRepo.GetByID(pId);

            return lResult;
        }



        /*public List<Campaign> GetAllCampaigns()
        {
            List<Campaign> lResultado = new List<Campaign>();
            using (this.iUoW)
            {
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                var query = lRepo.Queryable. Include(p => p.);
                lResultado = query.ToList<Persona>();
            }
            return lResultado;*/


        //public 
        // agregar verificaciones de intervalos
    }
    }

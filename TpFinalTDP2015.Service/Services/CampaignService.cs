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
using MarrSystems.TpFinalTDP2015.Model.DomainServices;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class CampaignService : ICampaignService //: BaseService<CampaignDTO>
    { 
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<CampaignService>();
        private readonly IScheduleService iSchServ;
        private readonly IRepository<Campaign> iRepo;
        private readonly IScheduleChecker iSchChecker;

        public CampaignService(IRepository<Campaign> pRepo, IScheduleService pScheService, IScheduleChecker pCheckService)
        {
            this.iRepo = pRepo;
            this.iSchServ = pScheService;
            this.iSchChecker = pCheckService;
        }


        public void SaveCampaign(CampaignDTO pCampaign)
        {
                Campaign lCampaign = Mapper.Map<CampaignDTO, Campaign>(pCampaign);
                if (pCampaign.Id == 0)
                {
                    iRepo.Add(lCampaign);
                }
                else
                {
                    iRepo.Update(lCampaign);
                }
            
        }



        public IEnumerable<Campaign> GetAll()
        {
            throw new NotImplementedException();
        }

        int ICrudService<Campaign>.Create(Campaign pEntity)
        {
            var lSchedules = pEntity.Schedules;
            pEntity.RemoveAllSchedules();

            foreach (var sche in lSchedules)
            {
                pEntity.AddSchedule(iSchChecker, sche);
            }

            iRepo.Add(pEntity);
            return pEntity.Id;
        }

        Campaign ICrudService<Campaign>.Read(int pId)
        {
            return iRepo.GetAll(c => c.Id == pId).FirstOrDefault();
        }

        int ICrudService<Campaign>.Update(Campaign pEntity)
        {
            throw new NotImplementedException();
        }

        void ICrudService<Campaign>.Delete(int pId)
        {
            iRepo.Delete(pId);
        }

        IEnumerable<Campaign> ICrudService<Campaign>.GetAll()
        {
            return iRepo.GetAll();
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

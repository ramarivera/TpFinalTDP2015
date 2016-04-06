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
    public class CampaignService : ServiceWithLogger, ICampaignService //: BaseService<CampaignDTO>
    { 
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<CampaignService>();
        private readonly IScheduleService iSchServ;
        private readonly IRepository<Campaign> iRepo;
        private readonly IScheduleChecker iSchChecker;

        public CampaignService(ILog pLogger, IRepository<Campaign> pRepo, IScheduleService pScheService, IScheduleChecker pCheckService) : base(pLogger)
        {
            this.iRepo = pRepo;
            this.iSchServ = pScheService;
            this.iSchChecker = pCheckService;
        }

        int ICrudService<Campaign>.Create(Campaign pEntity)
        {
            var lSchedules = pEntity.Schedules.ToList();
            pEntity.RemoveAllSchedules();

            iRepo.Add(pEntity);

            foreach (var sche in lSchedules)
            {
                if (sche.Id == 0)
                {
                    iSchServ.Create(sche);
                }
                else if (sche.Id > 0)
                {
                    iSchServ.Update(sche);
                }
                else
                {

                }
                pEntity.AddSchedule(iSchChecker, sche);
            }

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

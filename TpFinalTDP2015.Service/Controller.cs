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

namespace TpFinalTDP2015.Service
{
    public class Controller //: IController
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<Controller>();

        private IUnitOfWork iUoW;


        public Controller()
        {
            cLogger.Info("Fachada instanciada");

            using (iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();

                cLogger.InfoFormat("Usando {0} como implementacion de {1}", new[] { iUoW.GetType().Name, typeof(IUnitOfWork).Name });


                iUoW.Commit();
            }
        }

        public IList<CampaignDTO> GetCampaigns()
        {
            IList<CampaignDTO> lResult = new List<CampaignDTO>();

            using (iUoW = GetUnitOfWork())
            {
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                IList<Campaign> lTemp = lRepo.GetAll().ToList();

                foreach (var campaign in lTemp)
                {
                    CampaignDTO lDto = Mapper.Map<Campaign, CampaignDTO>(campaign);
                    lResult.Add(lDto);
                }

            }

            return lResult;
        }

        public void CreateCampaign(Campaign pCampaign)
        {
            using (this.iUoW)
            {
                iUoW.BeginTransaction();
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                lRepo.Add(pCampaign);
                iUoW.Commit();
            }
        }

        public void UpdateCampaign(Campaign pCampaign)
        {
            using (this.iUoW)
            {
                iUoW.BeginTransaction();
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                lRepo.Update(pCampaign);
                iUoW.Commit();
            }
        }

        private IUnitOfWork GetUnitOfWork()
        {
            return IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>();
        }

        public void DeleteCampaign(Campaign pCampaign)
        {
            using (this.iUoW)
            {
                iUoW.BeginTransaction();
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                Campaign mCampaign = lRepo.GetByID(pCampaign.Id);
                lRepo.Delete(mCampaign);
                iUoW.Commit();
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

        }
        //public 
    }
}

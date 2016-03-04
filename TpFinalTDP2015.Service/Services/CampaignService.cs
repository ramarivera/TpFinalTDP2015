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
    public class CampaignService //: BaseService<CampaignDTO>
    { 
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
    private static readonly ILog cLogger = LogManager.GetLogger<CampaignService>();

        private IUnitOfWork iUoW;


        public CampaignService()
        {
        }

        private IUnitOfWork GetUnitOfWork()
        {
            throw new NotImplementedException();
        }

        public IList<CampaignDTO> GetCampaigns()
        {
            IList<CampaignDTO> lResult = new List<CampaignDTO>();

            using (this.iUoW = GetUnitOfWork())
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

        public void SaveCampaign(CampaignDTO pCampaign)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                Campaign lCampaign = Mapper.Map<CampaignDTO, Campaign>(pCampaign);
                if (pCampaign.Id == 0)
                {
                    lRepo.Add(lCampaign);
                }
                else
                {
                    lRepo.Update(lCampaign);
                }
                iUoW.Commit();
            }
        }

        public void DeleteCampaign(CampaignDTO pCampaign)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                Campaign lCampaign = Mapper.Map<CampaignDTO, Campaign>(pCampaign);
                lRepo.Delete(lCampaign.Id);
                iUoW.Commit();
            }
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

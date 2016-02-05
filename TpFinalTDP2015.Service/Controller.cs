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

        private IUnitOfWork GetUnitOfWork()
        {
            return IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>();
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

        public IList<BannerDTO> GetBanners()
        {
            IList<BannerDTO> lResult = new List<BannerDTO>();

            using (this.iUoW = GetUnitOfWork())
            {
                IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
                IList<Banner> lTemp = lRepo.GetAll().ToList();

                foreach (var banner in lTemp)
                {
                    BannerDTO lDto = Mapper.Map<Banner, BannerDTO>(banner);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public void SaveBanner(BannerDTO pBanner)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
                Banner lBanner = Mapper.Map<BannerDTO, Banner>(pBanner);
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

        public void DeleteBanner(BannerDTO pBanner)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
                Banner lBanner = Mapper.Map<BannerDTO, Banner>(pBanner);
                lRepo.Delete(lBanner.Id);
                iUoW.Commit();
            }
        }

        public IList<DateIntervalDTO> GetDateIntervals()
        {
            IList<DateIntervalDTO> lResult = new List<DateIntervalDTO>();

            using (this.iUoW = GetUnitOfWork())
            {
                IRepository<DateInterval> lRepo = iUoW.GetRepository<DateInterval>();
                IList<DateInterval> lTemp = lRepo.GetAll().ToList();

                foreach (var dateInterval in lTemp)
                {
                    DateIntervalDTO lDto = Mapper.Map<DateInterval, DateIntervalDTO>(dateInterval);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public void SaveDateInterval(DateIntervalDTO pDateInterval)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<DateInterval> lRepo = iUoW.GetRepository<DateInterval>();
                DateInterval lDateInterval = Mapper.Map<DateIntervalDTO, DateInterval>(pDateInterval);
                if (pDateInterval.Id == 0)
                {
                    lRepo.Add(lDateInterval);
                }
                else
                {
                    lRepo.Update(lDateInterval);
                }
                iUoW.Commit();
            }
        }

        public void DeleteDateInterval(DateIntervalDTO pDateInterval)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<DateInterval> lRepo = iUoW.GetRepository<DateInterval>();
                DateInterval lDateInterval = Mapper.Map<DateIntervalDTO, DateInterval>(pDateInterval);
                lRepo.Delete(lDateInterval.Id);
                iUoW.Commit();
            }

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

        public IList<StaticTextDTO> GetStaticTexts()
        {
            IList<StaticTextDTO> lResult = new List<StaticTextDTO>();

            using (this.iUoW = GetUnitOfWork())
            {
                IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
                IList<StaticText> lTemp = lRepo.GetAll().ToList();

                foreach (var staticText in lTemp)
                {
                    StaticTextDTO lDto = Mapper.Map<StaticText, StaticTextDTO>(staticText);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public void SaveStaticText(StaticTextDTO pStaticText)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pStaticText);
                if (pStaticText.Id == 0)
                {
                    lRepo.Add(lStaticText);
                }
                else
                {
                    lRepo.Update(lStaticText);
                }
                iUoW.Commit();
            }
        }

        public void DeleteStaticText(StaticTextDTO pStaticText)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pStaticText);
                lRepo.Delete(lStaticText.Id);
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

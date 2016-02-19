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
    public class BannerController: BaseController<AdminBannerDTO>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<BannerController>();

        public BannerController(IUnitOfWork iUoW):base(iUoW)
        {
        }

        public override int Save(AdminBannerDTO pBanner)
        {
            iUoW.BeginTransaction();
            IRepository<Banner> lBannerRepo = iUoW.GetRepository<Banner>();
            IRepository<DateInterval> lIntervalRepo = iUoW.GetRepository<DateInterval>();
            IRepository<StaticText> lStaticTextRepo = iUoW.GetRepository<StaticText>();
            IRepository<RssSource> lRssSourceRepo = iUoW.GetRepository<RssSource>();

            Banner lBanner = Mapper.Map<AdminBannerDTO, Banner>(pBanner);

            if (pBanner.Id == 0)
            {
                lBannerRepo.Add(lBanner);
            }
            else
            {
                lBannerRepo.Update(lBanner);

                Banner lOrigBanner = lBannerRepo.GetByID(lBanner.Id);

                foreach (DateInterval lInterval in lBanner.ActiveIntervals)
                {
                    if (lInterval.Id == 0)
                    {
                        lOrigBanner.AddDateInterval(lInterval);
                    }
                    else
                    {
                        lIntervalRepo.Update(lInterval);
                    }
                }
                
                foreach (DateInterval lOrigDateInterval in lOrigBanner.ActiveIntervals.Reverse<DateInterval>())
                {
                    if (!lBanner.ActiveIntervals.Any(di => di.Id == lOrigDateInterval.Id))
                    {
                        lOrigBanner.RemoveDateInterval(lOrigDateInterval);
                        lIntervalRepo.Delete(lOrigDateInterval.Id);
                    }
                }

                foreach (StaticText lText in lBanner.Items)
                {
                    if (lText.Id == 0)
                    {
                        lOrigBanner.AddBannerItem(lText);
                    }
                    else
                    {
                        lStaticTextRepo.Update(lText);
                    }
                }

                foreach (StaticText lOrigStaticText in lOrigBanner.Items.Reverse<BaseBannerItem>())
                {
                    if (!lBanner.Items.Any(st => st.Id == lOrigStaticText.Id))
                    {
                        lOrigBanner.RemoveBannerItem(lOrigStaticText);
                        lStaticTextRepo.Delete(lOrigStaticText.Id);
                    }
                }

                foreach (RssSource lSource in lBanner.RssSources)
                {
                    if (lSource.Id == 0)
                    {
                        lOrigBanner.AddSource(lSource);
                    }
                    else
                    {
                        lRssSourceRepo.Update(lSource);
                    }
                }

                foreach (RssSource lOrigRssSource in lOrigBanner.RssSources.Reverse<RssSource>())
                {
                    if (!lBanner.RssSources.Any(rs => rs.Id == lOrigRssSource.Id))
                    {
                        lOrigBanner.RemoveSource(lOrigRssSource);
                        lRssSourceRepo.Delete(lOrigRssSource.Id);
                    }
                }
            }
            iUoW.Commit();
            return lBanner.Id;
        }

        public override void Delete(AdminBannerDTO pBanner)
        {
            iUoW.BeginTransaction();
            IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
            Banner lBanner = Mapper.Map<AdminBannerDTO, Banner>(pBanner);
            lRepo.Delete(lBanner.Id);
            iUoW.Commit();
        }

        public override IList<AdminBannerDTO> GetAll()
        {
            IList<AdminBannerDTO> lResult = new List<AdminBannerDTO>();

            IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
            IList<Banner> lTemp = lRepo.GetAll().ToList();

            foreach (var banner in lTemp)
            {
                AdminBannerDTO lDto = Mapper.Map<Banner, AdminBannerDTO>(banner);
                lResult.Add(lDto);
            }

            return lResult.ToList<AdminBannerDTO>();
        }

        public override AdminBannerDTO Get(int pId)
        {
            AdminBannerDTO lResult = new AdminBannerDTO();

            IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();

            var lTemp = lRepo.GetByID(pId);

            lResult = Mapper.Map<Banner, AdminBannerDTO>(lTemp);

            return lResult;
        }

    }
}

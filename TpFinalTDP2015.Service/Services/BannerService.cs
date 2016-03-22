using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Microsoft.Practices.Unity;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using AutoMapper;
using MarrSystems.TpFinalTDP2015.Persistence;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class BannerService : IBannerService
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<BannerService>();
        private IUnitOfWork iUoW;

        public BannerService(IUnitOfWork iUoW) { }

        public int Create(Banner pEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int pId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Banner> GetAll()
        {
            throw new NotImplementedException();
        }

        public Banner Read(int pId)
        {
            throw new NotImplementedException();
        }

        public int Update(Banner pEntity)
        {
            throw new NotImplementedException();
        }

        /*
        public override int Save(AdminBannerDTO pBanner)
        {
            iUoW.BeginTransaction();
            IRepository<Banner> lBannerRepo = iUoW.GetRepository<Banner>();
            IController<DateIntervalDTO> lIntervalController = ControllerFactory.GetController<DateIntervalDTO>();
            IController<StaticTextDTO> lStaticTextController = ControllerFactory.GetController<StaticTextDTO>();
            IController<RssSourceDTO> lRssSourceController = ControllerFactory.GetController<RssSourceDTO>();

            // un banner tiene rss, intervalaos y textos. Todos participan en una muchos a muchos
            Banner lTempBanner = Mapper.Map<AdminBannerDTO, Banner>(pBanner);
            Banner lBanner;

            if (lTempBanner.Id == 0)
            {
                lBannerRepo.Add(lTempBanner);
                lBanner = new Banner();
            }
            else
            {
                lBannerRepo.Update(lTempBanner);
                lBanner = lBannerRepo.GetByID(lTempBanner.Id);
            }

            foreach (DateInterval lInterval in lTempBanner.ActiveIntervals)
            {
                if (lInterval.Id == 0)
                {
                    lBanner.AddDateInterval(lInterval);
                }
                else
                {
                    lIntervalController.Save(lInterval);
                }
            }
            //TODO demasiados errores. deberia frenar antes del mapeo
            // o definir otro mapeo que no toque las colecciones, ya que yo tengo que pasart
            // dtos a los otros controladores


            foreach (var interval in lTempBanner.ActiveIntervals)
            {

            }


            if (pBanner.Id == 0)
            {
                lBannerRepo.Add(lTempBanner);
            }
            else
            {
                lBannerRepo.Update(lTempBanner);

                Banner lOrigBanner = lBannerRepo.GetByID(lTempBanner.Id);

                foreach (DateInterval lInterval in lTempBanner.ActiveIntervals)
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
                    if (!lTempBanner.ActiveIntervals.Any(di => di.Id == lOrigDateInterval.Id))
                    {
                        lOrigBanner.RemoveDateInterval(lOrigDateInterval);
                        lIntervalRepo.Delete(lOrigDateInterval.Id);
                    }
                }

                foreach (StaticText lText in lTempBanner.Items)
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
                //TODO no estoy seguro si los tipos están bien puestos tanto arriba como abajo de esta linea
                foreach (StaticText lOrigStaticText in lOrigBanner.Items.Reverse<BaseBannerItem>())
                {
                    if (!lTempBanner.Items.Any(st => st.Id == lOrigStaticText.Id))
                    {
                        lOrigBanner.RemoveBannerItem(lOrigStaticText);
                        lStaticTextRepo.Delete(lOrigStaticText.Id);
                    }
                }

                foreach (RssSource lSource in lTempBanner.RssSources)
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
                    if (!lTempBanner.RssSources.Any(rs => rs.Id == lOrigRssSource.Id))
                    {
                        lOrigBanner.RemoveSource(lOrigRssSource);
                        lRssSourceRepo.Delete(lOrigRssSource.Id);
                    }
                }
            }
            iUoW.Commit();
            return lTempBanner.Id;
        }*/

        /*
    public  void Delete(int pId)
    {
        iUoW.BeginTransaction();
        IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
        lRepo.Delete(pId);
        iUoW.Commit();
    }

    public  IList<Banner> GetAll()
    {
        IList<Banner> lResult = new List<Banner>();

        IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();
        IList<Banner> lTemp = lRepo.GetAll().ToList();

        foreach (var banner in lTemp)
        {
            lResult.Add(banner);
        }

        return lResult;
    }

    public  Banner Get(int pId)
    {
        Banner lResult = new Banner();

        IRepository<Banner> lRepo = iUoW.GetRepository<Banner>();

        var lTemp = lRepo.GetByID(pId);

        return lResult;
    }

    public  int Save(Banner pDTO)
    {
        throw new NotImplementedException();
    }*/
    }
}

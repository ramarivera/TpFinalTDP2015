using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TpFinalTDP2015.Service.AutoMapper;
using Common.Logging;

namespace TpFinalTDP2015.Service
{
    public class AutoMapperConfigurations
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<AutoMapperConfigurations>();

        static public void  Configure()
        {
            Mapper.Initialize(cfg => {//ida
                cfg.AddProfile<BannerProfile>();
                cfg.AddProfile<CampaignProfile>();
                cfg.AddProfile<DateIntervalProfile>();
                cfg.AddProfile<ModelDayProfile>();
                cfg.AddProfile<RssItemProfile>();
                cfg.AddProfile<RssSourceProfile>();
                cfg.AddProfile<ServiceDaysDTOProfile>();
                cfg.AddProfile<SlideProfile>();
                cfg.AddProfile<StaticTextProfile>();
                cfg.AddProfile<TimeIntervalProfile>();
                //vuelta
                cfg.AddProfile<AdminBannerDTOProfile>();
                cfg.AddProfile<CampaignDTOProfile>();
                cfg.AddProfile<DateIntervalDTOProfile>();
                cfg.AddProfile<ModelDaysProfile>();
                cfg.AddProfile<RssItemDTOProfile>();
                cfg.AddProfile<RssSourceDTOProfile>();
                cfg.AddProfile<ServiceDaysProfile>();
                cfg.AddProfile<SlideDTOProfile>();
                cfg.AddProfile<SlideTransitioProfile>();
                cfg.AddProfile<StaticTextDTOProfile>();
                cfg.AddProfile<TimeIntervalDTOProfile>();
            });
        }
    }  
}

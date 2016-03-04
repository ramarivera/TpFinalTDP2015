using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper;
using Common.Logging;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<AutoMapperConfiguration>();

        static public void  Configure()
        {
            Mapper.Initialize(cfg => {//ida
                cfg.AddProfile<AdminBannerProfile>();
                cfg.AddProfile<OperativeBannerProfile>();
                cfg.AddProfile<CampaignProfile>();
                cfg.AddProfile<DateIntervalProfile>();
                cfg.AddProfile<DayProfile>();
                cfg.AddProfile<RssItemProfile>();
                cfg.AddProfile<RssSourceProfile>();
                cfg.AddProfile<SlideProfile>();
                cfg.AddProfile<StaticTextProfile>();
                cfg.AddProfile<TimeIntervalProfile>();
                //vuelta
                cfg.AddProfile<AdminBannerDTOProfile>();
                cfg.AddProfile<CampaignDTOProfile>();
                cfg.AddProfile<DateIntervalDTOProfile>();
                cfg.AddProfile<RssItemDTOProfile>();
                cfg.AddProfile<RssSourceDTOProfile>();
                cfg.AddProfile<DaysEnumProfile>();
                cfg.AddProfile<SlideDTOProfile>();
                cfg.AddProfile<SlideTransitioProfile>();
                cfg.AddProfile<StaticTextDTOProfile>();
                cfg.AddProfile<TimeIntervalDTOProfile>();
            });
        }
    }  
}

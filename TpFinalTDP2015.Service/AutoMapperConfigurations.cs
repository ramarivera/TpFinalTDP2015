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
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DateIntervalProfile>();
                cfg.AddProfile<TimeIntervalProfile>();
                cfg.AddProfile<RssItemProfile>();
                cfg.AddProfile<RssSourceProfile>();
                cfg.AddProfile<BannerProfile>();
                cfg.AddProfile<StaticTextProfile>();
                cfg.AddProfile<CampaignProfile>();
                cfg.AddProfile<DaysProfile>();
                cfg.AddProfile<DayProfile>();
                cfg.AddProfile<SlideTransitioProfile>();
            });
        }
    }  
}

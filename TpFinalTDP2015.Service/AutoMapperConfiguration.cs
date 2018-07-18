using AutoMapper;
using log4net;
using MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<AutoMapperConfiguration>();

        static public void  Configure()
        {
            Mapper.Reset();

            Mapper.Initialize(cfg => {
                //ida
                cfg.AddProfile<AdminBannerProfile>();
                cfg.AddProfile<OperativeBannerProfile>();
                cfg.AddProfile<CampaignProfile>();
                cfg.AddProfile<DateIntervalProfile>();
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
                cfg.AddProfile<SlideDTOProfile>();
                cfg.AddProfile<SlideTransitionProfile>();
                cfg.AddProfile<StaticTextDTOProfile>();
                cfg.AddProfile<ScheduleEntryDTOProfile>();
            });
        }
    }  
}

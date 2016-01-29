using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Service
{
    interface IController
    {

        IList<CampaignDTO> GetActiveCampaigns();

        //  IList<IBannerItemDTO> GetBannerItems

        void FetchRss();
    }
}

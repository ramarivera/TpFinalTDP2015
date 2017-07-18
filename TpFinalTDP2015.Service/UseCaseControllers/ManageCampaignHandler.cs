using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageCampaignHandler : IController
    {
        public void AddCampaign(CampaignDTO pDto) { }

        public void ModifyCampaign(CampaignDTO pDto) { }
        //TODO: update

        public void DeleteCampaign(CampaignDTO pDto)
        {
        }

        public IList<CampaignDTO> ListCampaign()
        {
            IList<CampaignDTO> lResult = new List<CampaignDTO>();

            return lResult;
        }

        public CampaignDTO GetCampaign(int pId)
        {
            CampaignDTO lResult = new CampaignDTO();

            return lResult;
        }
    }
}

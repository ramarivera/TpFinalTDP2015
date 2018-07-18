using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using System.Collections.Generic;

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

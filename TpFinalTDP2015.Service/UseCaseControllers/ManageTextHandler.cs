using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    class ManageTextHandler
    {


        public void AddText(StaticTextDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                serv.Save(pDto);
            }
        }

        public void UpdateText(StaticTextDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                serv.Save(pDto);
            }
        }

        public void DeleteText(StaticTextDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                serv.Delete(pDto);
            }
        }


        public IList<StaticTextDTO> ListTexts()
        {
            IList<StaticTextDTO> lResult = new List<StaticTextDTO>();

            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                lResult = serv.GetAll();
            }

            return lResult;
        }
    }
}

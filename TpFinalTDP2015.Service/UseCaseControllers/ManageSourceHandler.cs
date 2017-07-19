using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageSourceHandler: IController
    {
        private IRssSourceService serv;

        public ManageSourceHandler(IRssSourceService pService)
        {
            this.serv = pService;
        }

        public int AddSource(RssSourceDTO pDto)
        {
                RssSource lSource = Mapper.Map<RssSourceDTO, RssSource>(pDto);
                serv.Create(lSource);
                return lSource.Id;
        }

        public void ModifySource(RssSourceDTO pDto)
        {
                RssSource lSource = Mapper.Map<RssSourceDTO, RssSource>(pDto);
                serv.Update(lSource);
        }

        public void DeleteSource(RssSourceDTO pDto)
        {
                serv.Delete(pDto.Id);
        }


        public IList<RssSourceDTO> ListSources()
        {
            IList<RssSourceDTO> lResult = new List<RssSourceDTO>();
                foreach (var rss in serv.GetAll())
                {
                    RssSourceDTO lDto = Mapper.Map<RssSource, RssSourceDTO>(rss);
                    lResult.Add(lDto);
                }

            return lResult;
        }

        public RssSourceDTO GetSource(int pId)
        {
            RssSourceDTO lResult = new RssSourceDTO();

                var tipos = Mapper.GetAllTypeMaps();
                lResult = Mapper.Map<RssSource, RssSourceDTO>(serv.Read(pId));
            return lResult;
        }
    }
}

﻿using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
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
    public class ManageTextHandler
    {
        public void AddText(StaticTextDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pDto);
                serv.Save(lStaticText);
            }
        }

        public void UpdateText(StaticTextDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pDto);
                serv.Save(lStaticText);
            }
        }

        public void DeleteText(StaticTextDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                serv.Delete(pDto.Id);
            }
        }


        public IList<StaticTextDTO> ListTexts()
        {
            IList<StaticTextDTO> lResult = new List<StaticTextDTO>();

            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                foreach (var text in serv.GetAll())
                {
                    StaticTextDTO lDto = Mapper.Map<StaticText, StaticTextDTO>(text);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public StaticTextDTO GetText(int pId)
        {
            StaticTextDTO lResult = new StaticTextDTO();

            using (var serv = BusinessServiceLocator.Resolve<StaticTextService>())
            {
                lResult = Mapper.Map<StaticText, StaticTextDTO>(serv.Get(pId));
            }
            return lResult;
        }
    }
}

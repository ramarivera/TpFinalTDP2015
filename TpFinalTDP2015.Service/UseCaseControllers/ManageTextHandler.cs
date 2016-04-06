using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Persistence;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageTextHandler
    {

        private readonly IUnitOfWork iUoW;
        private readonly IStaticTextService iServ;

        internal ManageTextHandler(IUnitOfWork pUoW, IStaticTextService pService)
        {
            this.iUoW = pUoW;
            this.iServ = pService;
        }


        
        public int AddText(StaticTextDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pDto);
                iServ.Create(lStaticText);
                iUoW.Commit();
                return lStaticText.Id;
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }
        }

        public void ModifyText(StaticTextDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pDto);
                iServ.Update(lStaticText);
                iUoW.Commit();
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }
        }

        public void DeleteText(StaticTextDTO pDto)
        {
            iUoW.BeginTransaction();
            try
            {
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pDto);
                iServ.Delete(pDto.Id);
                iUoW.Commit();
            }
            catch (Exception)
            {
                iUoW.Rollback();
                throw;
            }
        }


        public IList<StaticTextDTO> ListTexts()
        {
            IList<StaticTextDTO> lResult = new List<StaticTextDTO>();

            iUoW.BeginTransaction();
            try
            {
                foreach (var text in iServ.GetAll())
                {
                    StaticTextDTO lDto = Mapper.Map<StaticText, StaticTextDTO>(text);
                    lResult.Add(lDto);
                }
            }
            finally
            {
                iUoW.Rollback();
            }

            return lResult;

        }

        public StaticTextDTO GetText(int pId)
        {
            StaticTextDTO lResult = new StaticTextDTO();

            iUoW.BeginTransaction();
            try
            {
                lResult = Mapper.Map<StaticText, StaticTextDTO>(iServ.Read(pId));
            }
            finally
            {
                iUoW.Rollback();
            }

            return lResult;
        }
    }
}

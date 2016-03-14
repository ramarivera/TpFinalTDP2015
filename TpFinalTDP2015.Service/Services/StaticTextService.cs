using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using MarrSystems.TpFinalTDP2015.Persistence;
using Microsoft.Practices.Unity;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using AutoMapper;


namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class StaticTextService : BaseService<StaticText>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<StaticTextService>();
        private readonly IRepository<StaticText> iRepo;

        public StaticTextService(IRepository<StaticText> pRepo, IUnitOfWork iUoW = null) : base(iUoW) //TODO  revisame, sacame Uow
        {
            this.iRepo = pRepo;
        }

        public override int Save(StaticText pStaticText)
        {
            if (pStaticText.Id == 0)
            {
                iRepo.Add(pStaticText);
            }
            else
            {
                iRepo.Update(pStaticText);
            }
            return pStaticText.Id;
        }

        public override void Delete(int pId)
        {
            iRepo.Delete(pId);
        }

        public override IList<StaticText> GetAll()
        {
            IList<StaticText> lResult = iRepo.GetAll().ToList();
            return lResult;//.ToList<StaticText>();
        }

        public override StaticText Get(int pId)
        {
            StaticText lResult = new StaticText();
            lResult = iRepo.GetByID(pId);
            return lResult;
        }
    }
}

using System.Collections.Generic;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    internal interface IStaticTextService
    {
        void Save(StaticText lStaticText);
        void Delete(int id);
        IEnumerable<StaticText> GetAll();
        StaticText Get(int pId);
    }
}
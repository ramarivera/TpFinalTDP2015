using AutoMapper;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers
{
    public class AnswerSessionHandler : BaseHandler, IAnswerSessionHandler
    {
        private readonly IAnswerSessionServices iAnswerSessionServices;
        private readonly ICategoryServices iCategoryServices;

        public AnswerSessionHandler(
            IAnswerSessionServices pAnswerSessionServices,
            ICategoryServices pCategoryServices,
            IMapper pMapper)
            : base(pMapper)
        {
            this.iAnswerSessionServices = pAnswerSessionServices;
            this.iCategoryServices = pCategoryServices;
        }

        [Transactional]
        public int StartAnswerSession(AnswerSessionStartData pSessionStartData)
        {
            var lAnswerSession = this.iAnswerSessionServices.StartSession(pSessionStartData);

            return lAnswerSession.Id;
        }

        [Transactional]
        public IEnumerable<AnswerSessionData> GetAll()
        {
            var lAnswerSessions = iAnswerSessionServices.GetAll();

            var lResult = Mapper.Map<IList<AnswerSessionData>>(lAnswerSessions);
            return lResult;
        }

        [Transactional]
        public AnswerSessionData GetById(int pId)
        {
            var lAnswerSession = iAnswerSessionServices.GetById(pId);

            var lResult = Mapper.Map<AnswerSessionData>(lAnswerSession);
            return lResult;
        }

        [Transactional]
        public int EndAnswerSession(int pId)
        {
            var lAnswerSession = this.iAnswerSessionServices.EndSession(pId);

            return lAnswerSession.Id;
        }

        //[Transactional]
        //public int StartAnswerSession2()
        //{
        //    var cat = this.iCategoryServices.Create(new CategoryData
        //    {
        //        Description = "test",
        //    });


        //    return cat.Id;
        //}
    }
}

using AutoMapper;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;

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
        public AnswerSessionData GetById(int pId)
        {
            var lAnswerSession = iAnswerSessionServices.GetById(pId);

            var lResult = Mapper.Map<AnswerSessionData>(lAnswerSession);
            return lResult;
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

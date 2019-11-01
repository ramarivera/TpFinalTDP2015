using AutoMapper;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using Questionnaire.Handlers.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Handlers.Handlers
{
    public class UserAnswerHandler : BaseHandler, IUserAnswerHandler
    {
        private readonly IUserAnswerServices iUserAnswerServices;

        public UserAnswerHandler(
            IUserAnswerServices pUserAnswerServices,
            IMapper pMapper)
            : base(pMapper)
        {
            iUserAnswerServices = pUserAnswerServices;
        }

        public int SaveUserAnswer(UserAnswerCreationData pUserAnswer)
        {
            var lUserAnswer = this.iUserAnswerServices.Create(pUserAnswer);

            return lUserAnswer.Id;
        }
    }
}

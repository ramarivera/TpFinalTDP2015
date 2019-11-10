﻿using AutoMapper;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Model;
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

        private readonly IAnswerSessionServices iAnswerSessionServices;

        public UserAnswerHandler(
            IUserAnswerServices pUserAnswerServices,
            IAnswerSessionServices pAnswerSessionServices,
            IMapper pMapper)
            : base(pMapper)
        {
            iUserAnswerServices = pUserAnswerServices;
            iAnswerSessionServices = pAnswerSessionServices;
        }

        public int SaveUserAnswer(UserAnswerCreationData pUserAnswer, int pAnswerSessionId)
        {
            AnswerSession lAnswerSession = iAnswerSessionServices.GetById(pAnswerSessionId);//esto podría no estar bien
            var lUserAnswer = this.iUserAnswerServices.Create(pUserAnswer, lAnswerSession);

            return lUserAnswer.Id;
        }
    }
}
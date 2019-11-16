﻿using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System.Linq;

namespace Questionnaire.Services.Interfaces
{
    public interface IUserAnswerServices
    {
        IQueryable<UserAnswer> GetAll();

        UserAnswer GetById(long pUserAnswerId);

        UserAnswer Create(UserAnswerCreationData pUserAnswerData, AnswerSession pAnswerSession);

        UserAnswer Update(long pUserAnswerId, UserAnswerData pUpdateUserAnswer);

        void Delete(long pUserAnswerId);
    }
}

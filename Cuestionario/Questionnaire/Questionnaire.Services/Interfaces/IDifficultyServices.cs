using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.Services.Interfaces
{
    public interface IDifficultyServices
    {
        IEnumerable<Difficulty> GetAll();

        Difficulty GetById(int pDifficultyId);

        Difficulty Create(DifficultyData pDifficultyData);

        DifficultyData RetrieveOrCreateByDescription(string pDifficultyDescription);

        int GetDifficultyFactor(string pDescription);
    }
}

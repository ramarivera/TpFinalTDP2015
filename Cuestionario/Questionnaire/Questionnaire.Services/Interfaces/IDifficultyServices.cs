using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.Services.Interfaces
{
    public interface IDifficultyServices
    {
        IEnumerable<Difficulty> GetAll();
        Difficulty GetById(long pDifficultyId);
        Difficulty Create(DifficultyData pDifficultyData);
        Difficulty Update(long pDifficultyId, DifficultyData pUpdateDifficulty);
        void Delete(long pDifficultyId);
        DifficultyData RetrieveByDescription(string pDifficultyDescription);
        int GetDifficultyFactor(string pDescription);
    }
}

﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers
{
    /// <summary>
    /// Handler class for <see cref="Model.AnswerSession"/> related use cases such as: <see cref="StartAnswerSession"/> 
    /// and <see cref="EndAnswerSession"/>
    /// </summary>
    public class AnswerSessionHandler : BaseHandler, IAnswerSessionHandler
    {
        private readonly IAnswerSessionServices iAnswerSessionServices;
        private readonly ILogger iLogger;

        public AnswerSessionHandler(
            IAnswerSessionServices pAnswerSessionServices,
            ILogger pLogger,
            IMapper pMapper)
            : base(pMapper)
        {
            this.iAnswerSessionServices = pAnswerSessionServices;
            this.iLogger = pLogger;
        }

        /// <summary>
        /// Starts a new Answer Session, according to the data chosen by user
        /// </summary>
        /// <param name="pSessionStartData">Answer Session start data</param>
        /// <returns> New Answer Session Id</returns>
        [Transactional]
        public long StartAnswerSession(AnswerSessionStartData pSessionStartData)
        {
            this.iLogger.LogInformation("Request received for starting a new AnswerSession");

            var lAnswerSession = this.iAnswerSessionServices.StartSession(pSessionStartData);

            this.iLogger.LogInformation("Request finished for starting AnswerSession with id {AnswerSessionId}", lAnswerSession.Id);
            return lAnswerSession.Id;
        }

        /// <summary>
        /// Gets all Answer Sessions
        /// </summary>
        /// <returns>A list of <see cref="AnswerSessionData"/></returns>
        [Transactional]
        public IEnumerable<AnswerSessionData> GetAll()
        {
            this.iLogger.LogInformation("Request received for getting all existing AnswerSessions");
            
            var lAnswerSessions = iAnswerSessionServices.GetAll();

            var lResult = Mapper.Map<IList<AnswerSessionData>>(lAnswerSessions);

            this.iLogger.LogInformation("Request finished for getting all existing AnswerSessions");
            return lResult;
        }

        /// <summary>
        /// Gets a specific Answer Session, according to a given Id
        /// </summary>
        /// <param name="pId">Answer Session Id</param>
        /// <returns><see cref="AnswerSessionData"/> for the given Id</returns>
        [Transactional]
        public AnswerSessionData GetById(long pId)
        {
            this.iLogger.LogInformation("Request received for getting AnswerSession with id {pId}", pId);
            
            var lAnswerSession = iAnswerSessionServices.GetById(pId);

            var lResult = Mapper.Map<AnswerSessionData>(lAnswerSession);
            this.iLogger.LogInformation("Request finished for getting AnswerSession with id {pId}", pId);
            return lResult;
        }

        /// <summary>
        /// Finalizes a specific Answer Session, updating its data
        /// </summary>
        /// <param name="pId">Answer Session Id</param>
        /// <returns></returns>
        [Transactional]
        public long EndAnswerSession(long pId)
        {
            this.iLogger.LogInformation("Request received for ending AnswerSession with id {pId}", pId);
            
            var lAnswerSession = this.iAnswerSessionServices.EndSession(pId);

            this.iLogger.LogInformation("Request finished for ending AnswerSession with id {pId}", pId);
            return lAnswerSession.Id;
        }
    }
}

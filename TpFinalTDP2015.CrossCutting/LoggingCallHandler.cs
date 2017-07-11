using Common.Logging;
using MarrSystems.TpFinalTDP2015.CrossCutting.Logging;
using MarrSystems.TpFinalTDP2015.CrossCutting;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;

namespace MarrSystems.TpFinalTDP2015.CrossCutting
{
    public class LoggingCallHandler : ICallHandler
    {

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var lLogger = LogManagerWrapper.GetLogger(input.Target.GetType());
          // var lLogger2 = Logging.LogManagerWrapper.GetLogger(input.Target.GetType());
          // var istrue = lLogger == lLogger2;
          // var othertrue = Object.ReferenceEquals(lLogger2, lLogger);
            var lTypeString = (input.Target.GetType().GetFriendlyTypeName());
            var lMethodSignature = (input.MethodBase as MethodInfo).GetSignature();

            lLogger.TraceFormat("Entering {0}",lMethodSignature);

            for (int i = 0; i < input.Arguments.Count; i++)
            {
                var argInfo = input.Arguments.GetParameterInfo(i);
                var value = input.Arguments[i].ToJson();
                lLogger.TraceFormat("{{\"Name\": \"{0}\", \"Type\": \"{1}\", \"Value\": {2}}}",
                    argInfo.Name, argInfo.ParameterType.GetFriendlyTypeName(), value);
            }
        
            IMethodReturn methodReturn = getNext().Invoke(input, getNext);
           

            if (methodReturn.Exception == null)
            {
                string lMsg;
                if (methodReturn.ReturnValue == null)
                {
                    lMsg = String.Format("Method {0}::{1} finished", lTypeString, lMethodSignature);
                }
                else
                {
                    lMsg = String.Format("Method {0}::{1} returned: [{2}]",
                        lTypeString, lMethodSignature, methodReturn.ReturnValue.ToJson());
                }
                lLogger.Trace(lMsg);
            }
            else
            {
                lLogger.ErrorFormat("Method {0}::{1} threw exception {2}",
                    methodReturn.Exception,
                    lTypeString, lMethodSignature, methodReturn.Exception.ToString());
            }

            return methodReturn;
        }

        public int Order { get; set; }

    }
}

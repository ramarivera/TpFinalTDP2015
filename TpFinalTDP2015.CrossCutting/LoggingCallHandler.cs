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

namespace MarrSystems.TpFinalTDP2015.CrossCutting
{
    public class LoggingCallHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input,GetNextHandlerDelegate getNext)
        {
            var lLogger = Logging.LogManagerWrapper.GetLogger(input.Target.GetType());
            var lTypeString = (input.Target.GetType().GetFriendlyTypeName());
            var lMethodSignature = (input.MethodBase as MethodInfo).GetSignature();

            lLogger.TraceFormat("Entering {0}::{1} with {2} argument(s)",
                 lTypeString, lMethodSignature, input.Arguments.Count);

            for (int i = 0; i < input.Arguments.Count; i++)
            {
                var argInfo = input.Arguments.GetParameterInfo(i);
                var arg = input.Arguments[i];
                lLogger.TraceFormat("\tName: {0}\t Type: {1} \tValue: {2}",
                    argInfo.Name, argInfo.ParameterType.GetFriendlyTypeName(), arg);
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
                        lTypeString, lMethodSignature,
                        methodReturn.ReturnValue.ToString().RemoveNamespacePrefix());
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

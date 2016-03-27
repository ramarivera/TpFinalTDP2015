using Common.Logging;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.CrossCutting
{
    public class LoggingCallHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input,GetNextHandlerDelegate getNext)
        {
            var lLogger = LogManager.GetLogger(input.MethodBase.ReflectedType);

            lLogger.TraceFormat("Entering {0}::{1} with {2} argument(s)",
                input.Target, input.MethodBase.Name, input.Arguments.Count);

            for (int i = 0; i < input.Arguments.Count; i++)
            {
                var argInfo = input.Arguments.GetParameterInfo(i);
                var arg = input.Arguments[i];
                lLogger.TraceFormat("\tName: {0}\t Type: {1} \tValue: {2}",
                    argInfo.Name, argInfo.ParameterType, arg);
            }

            IMethodReturn methodReturn = getNext().Invoke(input, getNext);

            if (methodReturn.Exception == null)
            {
                lLogger.TraceFormat(" Method {0}::{1} returned: [{2}]",
                               input.Target, input.MethodBase.Name, methodReturn.ReturnValue);
            }
            else
            {
                lLogger.ErrorFormat("Method {0}::{1} threw exception {2}",
                    methodReturn.Exception,
                    input.Target, input.MethodBase.Name, methodReturn.Exception.ToString());
            }

            return methodReturn;
        }

        public int Order { get; set; }

    }
}

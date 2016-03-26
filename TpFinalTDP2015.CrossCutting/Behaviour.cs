using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using Common.Logging;

namespace MarrSystems.TpFinalTDP2015.CrossCutting.Interceptor
{
    public class MyBehavior : IInterceptionBehavior
    {
        /// <summary>
        /// Returns the interfaces required by the behavior for the objects it intercepts.
        /// </summary>
        /// <returns>
        /// The required interfaces.
        /// </returns>
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        /// <summary>
        /// Implement this method to execute your behavior processing.
        /// </summary>
        /// <param name="input">Inputs to the current call to the target.</param>
        /// <param name="getNext">Delegate to execute to get the next delegate 
        /// in the behavior chain</param>
        /// <returns>
        /// Return value from the target.
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var lLogger = LogManager.GetLogger(input.MethodBase.ReflectedType);

            lLogger.DebugFormat("Entering {0}::{1} with {2} argument(s)",
                input.Target,input.MethodBase.Name,input.Arguments.Count);
            IMethodReturn methodReturn;


            for (int i = 0; i < input.Arguments.Count; i++)
            {
                var argInfo = input.Arguments.GetParameterInfo(i);
                var arg = input.Arguments[i];
                lLogger.DebugFormat("\tName: {0}\t Type: {1} \tValue: {2}",
                    argInfo.Name, argInfo.ParameterType, arg);
            }

            methodReturn = getNext().Invoke(input, getNext);

            lLogger.DebugFormat("Leaving method with result: [{0}]",
                methodReturn.ReturnValue);

            return methodReturn;
        }

        /// <summary>
        /// Optimization hint for proxy generation - will this behavior actually
        /// perform any operations when invoked?
        /// </summary>
        public bool WillExecute
        {
            get { return true; }
        }

    }
}
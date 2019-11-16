using Castle.Core.Interceptor;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Persistence.UnitOfWork;
using Questionnaire.Utilities;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Questionnaire.Handlers.Proxies
{
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    class TransactionalMethodInterceptor : Castle.Core.Interceptor.IInterceptor
    {
        private readonly IUnitOfWork iUnitOfWork;

        public TransactionalMethodInterceptor(IUnitOfWork pUnitOfWork)
        {
            this.iUnitOfWork = pUnitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            if (ShouldIntercept(invocation))
            {
                if (ShouldInterceptAsync(invocation))
                {
                    var takCompletionSource = BuildTaskCompletionSource(invocation);
                    invocation.ReturnValue = GetTaskFromTaskCompletionSource(takCompletionSource);

                    PerformAsyncInterception(invocation).ContinueWith(_ =>
                    {
                        SetTaskCompletionSourceResult(takCompletionSource, invocation.ReturnValue);
                    });
                }
                else
                {
                    PerformSyncInterception(invocation);
                }
            }
            else
            {
                invocation.Proceed();
            }
        }

        private bool ShouldInterceptAsync(IInvocation invocation)
        {
            return typeof(Task).IsAssignableFrom(invocation.MethodInvocationTarget.ReturnType);
        }

        private void PerformSyncInterception(IInvocation invocation)
        {
            this.iUnitOfWork.BeginTransaction();

            try
            {
                invocation.Proceed();
                this.iUnitOfWork.Commit();
            }
            catch (Exception e)
            {
                this.iUnitOfWork.Rollback();
                throw;
            }
        }

        private Task PerformAsyncInterception(IInvocation invocation)
        {
            return Task.Run(() => PerformSyncInterception(invocation));
        }

        private object BuildTaskCompletionSource(IInvocation invocation)
        {
            var taskCompletionSourceResultType = typeof(object);
            var invocationResultType = invocation.Method.ReturnType;

            if (IsGenericTask(invocationResultType))
            {
                taskCompletionSourceResultType = invocationResultType.GetGenericArguments()[0];
            }

            var taskCompletionType = typeof(TaskCompletionSource<>)
                    .MakeGenericType(taskCompletionSourceResultType);

            var taskCompletionSource = Activator.CreateInstance(taskCompletionType);

            return taskCompletionSource;
        }

        private object GetTaskFromTaskCompletionSource(object taskCompletionSource)
        {
            return taskCompletionSource.GetType()
                                       .GetProperty("Task")
                                       .GetValue(taskCompletionSource, null);
        }

        private void SetTaskCompletionSourceResult(object taskCompletionSource, object result)
        {
            taskCompletionSource.GetType()
                                .GetMethod("SetResult")
                                .Invoke(taskCompletionSource, new object[] { result });
        }

        private bool ShouldIntercept(IInvocation pInvocation)
        {
            return pInvocation.MethodInvocationTarget.GetCustomAttribute<TransactionalAttribute>() != null;
        }

        private bool IsGenericTask(Type pTaskType)
        {
            return typeof(Task).IsAssignableFrom(pTaskType) && pTaskType.IsGenericType;
        }
    }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
}

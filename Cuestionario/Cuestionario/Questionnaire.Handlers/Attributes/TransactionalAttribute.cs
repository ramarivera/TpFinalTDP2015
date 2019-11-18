using System;

namespace Questionnaire.Handlers.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    class TransactionalAttribute : Attribute
    {
    }
}

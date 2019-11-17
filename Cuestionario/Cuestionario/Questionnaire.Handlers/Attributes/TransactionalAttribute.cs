using System;

namespace Questionnaire.Handlers.Attributes
{
    // TODO missing documentation
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    class TransactionalAttribute : Attribute
    {
    }
}

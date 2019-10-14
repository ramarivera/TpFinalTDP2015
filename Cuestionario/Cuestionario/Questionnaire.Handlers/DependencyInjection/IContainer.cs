using System;

namespace Questionnaire.Handlers.DependencyInjection
{
    public interface IContainer
    {
        object Resolve(Type pType);

        TType Resolve<TType>();
    }
}

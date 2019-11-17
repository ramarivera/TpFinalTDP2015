using System;

namespace Questionnaire.Services.DependencyInjection
{
    // TODO missing documentation
    public interface IContainer
    {
        TType Resolve<TType>();

        TType Resolve<TType>(string pConfigurationName);
    }
}

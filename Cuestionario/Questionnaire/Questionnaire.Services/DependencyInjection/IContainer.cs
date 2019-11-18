using System;

namespace Questionnaire.Services.DependencyInjection
{
    public interface IContainer
    {
        TType Resolve<TType>();

        TType Resolve<TType>(string pConfigurationName);
    }
}

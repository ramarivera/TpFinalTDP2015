namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public interface IDomainServiceFactory
    {
        T GetService<T>() where T : IDomainService;
    }
}
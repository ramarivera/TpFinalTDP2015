namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public interface IBusinessServiceFactory
    {
        T GetService<T>() where T : IBusinessService;
    }
}
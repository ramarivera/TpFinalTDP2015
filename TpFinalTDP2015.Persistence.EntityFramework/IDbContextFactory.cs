namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    public interface IDbContextFactory
    {
        IDbContext CreateContext();
    }
}
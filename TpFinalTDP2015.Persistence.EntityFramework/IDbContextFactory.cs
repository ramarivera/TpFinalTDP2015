namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    internal interface IDbContextFactory
    {
        IDbContext CreateContext();
    }
}
using System.Data.Entity;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    public static class EFConfiguration
    {
        public static void Configure(DbModelBuilder pModel)
        {
            pModel.HasDefaultSchema("MARR");
            pModel.Configurations.AddFromAssembly(typeof(EFConfiguration).Assembly);
        }
    }
}

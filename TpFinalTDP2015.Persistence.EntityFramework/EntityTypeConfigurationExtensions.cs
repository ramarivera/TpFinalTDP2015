using DelegateDecompiler;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework.Mapping
{
    public static class EntityTypeConfigurationEx
    {
        private static readonly EntityFrameworkMappingConfiguration cfg = new EntityFrameworkMappingConfiguration();

        static EntityTypeConfigurationEx()
        {
            Configuration.Configure(cfg);
        }

   
        public static ManyNavigationPropertyConfiguration<TEntityType, TTargetEntity> HasMany<TEntityType, TTargetEntity>(
            this EntityTypeConfiguration<TEntityType> c,
            Expression<Func<TEntityType, IEnumerable<TTargetEntity>>> navigationPropertyExpression)
            where TTargetEntity : class 
            where TEntityType : class
        {
            try
            {
                //The code that causes the error goes here.
                var body = navigationPropertyExpression.Body;
                var member = (PropertyInfo)((MemberExpression)body).Member;
                cfg.RegisterForDecompilation(member);
                var decompile = DecompileExpressionVisitor.Decompile(body);
                var convert = Expression.Convert(decompile, typeof(ICollection<TTargetEntity>));
                var expression = Expression.Lambda<Func<TEntityType, ICollection<TTargetEntity>>>(convert, navigationPropertyExpression.Parameters);
                return c.HasMany(expression);
            }
            catch (ReflectionTypeLoadException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Exception exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (exFileNotFound != null)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();
                //Display or log the error based on your application.
                throw;
            }

           
        }
    }
}

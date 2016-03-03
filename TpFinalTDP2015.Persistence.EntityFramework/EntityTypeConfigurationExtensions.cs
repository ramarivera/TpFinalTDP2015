using DelegateDecompiler;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.EntityFramework.Mapping
{
    public static class EntityTypeConfigurationEx
    {
        private static readonly EntityFrameworkMappingConfiguration cfg = new EntityFrameworkMappingConfiguration();

        static EntityTypeConfigurationEx()
        {
            Configuration.Configure(cfg);
        }

    /*    public ManyNavigationPropertyConfiguration<TEntityType, TTargetEntity> HasMany<TTargetEntity>(
            Expression<Func<TEntityType, ICollection<TTargetEntity>>> navigationPropertyExpression)
            where TTargetEntity : class;

        */
        public static ManyNavigationPropertyConfiguration<TEntityType, TTargetEntity> HasMany<TEntityType, TTargetEntity>(
            this EntityTypeConfiguration<TEntityType> c,
            Expression<Func<TEntityType, IEnumerable<TTargetEntity>>> navigationPropertyExpression)  where TTargetEntity : class where TEntityType : class
        {
            var body = navigationPropertyExpression.Body;
            var member = (PropertyInfo)((MemberExpression)body).Member;
            cfg.RegisterForDecompilation(member);
            var decompile = DecompileExpressionVisitor.Decompile(body);
            var convert = Expression.Convert(decompile, typeof(ICollection<TTargetEntity>));
            var expression = Expression.Lambda<Func<TEntityType, ICollection<TTargetEntity>>>(convert, navigationPropertyExpression.Parameters);
            return c.HasMany(expression);
        }
    }
}

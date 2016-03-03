using DelegateDecompiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    public class EntityFrameworkMappingConfiguration : DefaultConfiguration
    {
        private readonly HashSet<MemberInfo> members = new HashSet<MemberInfo>();

        public void RegisterForDecompilation(MemberInfo member)
        {
            members.Add(member);
        }
        public override bool ShouldDecompile(MemberInfo member)
        {
            return members.Contains(member) || base.ShouldDecompile(member);
        }
    }
}

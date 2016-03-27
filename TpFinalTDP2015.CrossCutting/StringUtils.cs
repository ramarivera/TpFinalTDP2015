using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.CrossCutting
{
    internal static class StringUtils
    {
        internal static string RemoveNamespacePrefix(this string pString)
        {
            return pString.Replace("MarrSystems.TpFinalTDP2015.", String.Empty);
        }

        /// <summary>
        /// From http://stackoverflow.com/questions/401681/how-can-i-get-the-correct-text-definition-of-a-generic-type-using-reflection
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static string GetFriendlyTypeName(this Type type)
        {
            string lResult;
            if (type.IsGenericParameter)
            {
                lResult = type.Name;
            }
            else if (!type.IsGenericType)
            {
                lResult = type.FullName;
            }
            else
            {
                var builder = new StringBuilder();
                var name = type.Name;
                var index = name.IndexOf("`");
                builder.AppendFormat("{0}.{1}", type.Namespace, name.Substring(0, index));
                builder.Append('<');
                var first = true;
                foreach (var arg in type.GetGenericArguments())
                {
                    if (!first)
                    {
                        builder.Append(',');
                    }
                    builder.Append(GetFriendlyTypeName(arg));
                    first = false;
                }
                builder.Append('>');
                lResult = builder.ToString();
            }

            return lResult.RemoveNamespacePrefix();
        }

    }
}

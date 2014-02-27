using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparrow.External.Properties;

namespace Sparrow.External
{
    public static class Validate
    {
        [StringFormatMethod("messageFormat")]
        [ContractAnnotation("item:null => halt")]
        public static void IsNotNull<T>(T item, string messageFormat, params object[] args)
            where T : class
        {
            Condition(!ReferenceEquals(null, item), messageFormat, args);
        }

        [StringFormatMethod("messageFormat")]
        [ContractAnnotation("condition:false => halt")]
        public static void Condition(bool condition, string messageFormat, params object[] args)
        {
            if (!condition)
                throw new InvalidOperationException(string.Format(messageFormat, args));
        }
    }
}

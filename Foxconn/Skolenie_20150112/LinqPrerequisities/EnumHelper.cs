using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPrerequisities
{
    public static class EnumHelper
    {
        public static IList<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
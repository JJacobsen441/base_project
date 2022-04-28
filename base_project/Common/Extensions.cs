using System.Collections.Generic;
using System.Linq;

namespace Base.Common
{
    public static class Extensions
    {
        public static bool IsNull<T>(this T me)
        {
            return me == null;
        }
               
        public static bool IsNullOrEmpty<T>(this ICollection<T> me) where T : class
        {
            return me == null || me.Count() == 0;
        }

        public static bool IsNullOrEmpty(this string me)
        {
            return me == null || me.Length == 0;
        }

        public static bool HasValue(this string me)
        {
            return me != null && me != "";
        }
    }
}

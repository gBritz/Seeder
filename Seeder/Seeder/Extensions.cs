using System;
using System.Collections.Generic;
using System.Linq;

namespace Seeder
{
    public static class Extensions
    {
        private static readonly Type stringType = typeof(String);

        public static Boolean IsString(this Type type)
        {
            return type == stringType;
        }

        public static Boolean IsEmpty<T>(this ICollection<T> col)
        {
            return col == null || col.Count == 0;
        }

        public static T[] GetAll<T>()
        {
            var type = typeof(T);
            return Enum.GetValues(type).OfType<T>().ToArray();
        }
    }
}
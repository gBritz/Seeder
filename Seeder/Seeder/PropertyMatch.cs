using System;
using System.Reflection;

namespace Seeder
{
    public struct PropertyMatch
    {
        public PropertyInfo property;
        public Func<Object> getValue;
        public IConvention convention;
        public ClassMatch nested;

        public static PropertyMatch Create(PropertyInfo property, Func<Object> getValue, IConvention convention)
        {
            return new PropertyMatch
            {
                property = property,
                getValue = getValue,
                convention = convention
            };
        }
    }
}
using System;

namespace Seeder
{
    public struct ClassMatch
    {
        public Type type;
        public Func<Object> getInstance;
        public PropertyMatch[] properties;
    }
}
using System;

namespace Seeder.Structures
{
    public class ClassStructure : IStructure
    {
        public Type Instance { get; set; }

        public Boolean EqualName(String name)
        {
            return Instance.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase);
        }

        public Boolean StartName(String name)
        {
            return Instance.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase);
        }

        public Boolean ContainsName(String name)
        {
            return Instance.Name.ToLower().Contains(name.ToLower());
        }

        public Boolean EndName(String name)
        {
            return Instance.Name.EndsWith(name, StringComparison.InvariantCultureIgnoreCase);
        }

        public Boolean Accept<T>()
        {
            return Accept(typeof(T));
        }

        public Boolean Accept(Type type)
        {
            return false;
        }
    }
}
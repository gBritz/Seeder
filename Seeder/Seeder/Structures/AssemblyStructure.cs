using System;
using System.Reflection;

namespace Seeder.Structures
{
    public class AssemblyStructure : IStructure
    {
        public Assembly Instance { get; set; }

        public Boolean EqualName(String name)
        {
            return this.Instance.FullName.Equals(name, StringComparison.InvariantCultureIgnoreCase);
        }

        public Boolean StartName(String name)
        {
            return this.Instance.FullName.StartsWith(name, StringComparison.InvariantCultureIgnoreCase);
        }

        public Boolean ContainsName(String name)
        {
            return this.Instance.FullName.ToLower().Contains(name.ToLower());
        }

        public Boolean EndName(String name)
        {
            return this.Instance.FullName.EndsWith(name, StringComparison.InvariantCultureIgnoreCase);
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
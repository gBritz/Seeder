using Seeder.Structures;
using System;
using System.Reflection;

namespace Seeder
{
    public class StructureCode
    {
        private AssemblyStructure assemblyStruct = new AssemblyStructure();
        private ClassStructure classStruct = new ClassStructure();
        private PropertyStructure propertyStruct = new PropertyStructure();

        internal void Set(PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            this.assemblyStruct.Instance = property.ReflectedType.Assembly;
            this.classStruct.Instance = property.ReflectedType;
            this.propertyStruct.Instance = property;
        }

        public IStructure Assembly
        {
            get { return this.assemblyStruct; }
        }

        public IStructure Class
        {
            get { return this.classStruct; }
        }

        public IStructure Property
        {
            get { return this.propertyStruct; }
        }
    }
}
using System;

namespace Seeder.Conventions
{
    public class PersonNameConvention : IConvention
    {
        public Boolean IsSpecifiedBy(StructureCode structure)
        {
            return (structure.Class.EqualName("cliente") ||
                    structure.Class.StartName("cliente") ||
                    structure.Class.EndName("cliente")
                   ) &&
                   structure.Property.EqualName("nome");
        }
    }
}
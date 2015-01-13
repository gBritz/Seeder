using System;

namespace Seeder.Conventions
{
    public class CpfConvention : IConvention
    {
        public Boolean IsSpecifiedBy(StructureCode structure)
        {
            return structure.Property.EqualName("cpf") ||
                   structure.Property.StartName("cpf");
        }
    }
}
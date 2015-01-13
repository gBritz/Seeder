using System;

namespace Seeder.Conventions
{
    public class EmailConvention : IConvention
    {
        public Boolean IsSpecifiedBy(StructureCode structure)
        {
            return structure.Property.EqualName("email");
        }
    }
}
using System;

namespace Seeder.Conventions
{
    public class IdConvention : IConvention
    {
        public Boolean IsSpecifiedBy(StructureCode structure)
        {
            return structure.Property.EqualName("id") ||
                   structure.Property.EqualName("codigo") ||
                   structure.Property.EndName("id") ||
                   structure.Property.EndName("codigo");
        }
    }
}
using System;

namespace Seeder.Conventions
{
    public class AgeConvention : IConvention
    {
        public Boolean IsSpecifiedBy(StructureCode structure)
        {
            return structure.Property.EqualName("idade") &&
                   (
                    structure.Class.StartName("cliente") ||
                    structure.Class.EqualName("cliente") ||

                    structure.Class.StartName("pessoa") ||
                    structure.Class.EqualName("pessoa") ||

                    structure.Class.StartName("usuario") ||
                    structure.Class.EqualName("usuario") ||

                    structure.Class.StartName("user") ||
                    structure.Class.EqualName("user")
                   );
        }
    }
}
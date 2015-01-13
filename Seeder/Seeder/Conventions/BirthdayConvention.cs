using System;

namespace Seeder.Conventions
{
    public class BirthdayConvention : IConvention
    {
        public Boolean IsSpecifiedBy(StructureCode structure)
        {
            return structure.Property.EqualName("dataNascimento") &&
                  (
                   structure.Class.EqualName("cliente") ||
                   structure.Class.EndName("cliente") ||
                   structure.Class.EqualName("usuario") ||
                   structure.Class.EndName("usuario")
                  );
        }
    }
}
using System;

namespace Seeder
{
    public interface IConvention
    {
        Boolean IsSpecifiedBy(StructureCode structure);
    }
}
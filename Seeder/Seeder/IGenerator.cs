using System;

namespace Seeder
{
    public interface IGenerator
    {
        Object Generate(Randomizer randomizer);
    }
}
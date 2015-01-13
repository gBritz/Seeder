using System;

namespace Seeder.Generators
{
    public class YearGenerator : IGenerator
    {
        public Object Generate(Randomizer randomizer)
        {
            return NextYear(randomizer);
        }

        public Int32 NextYear(Randomizer randomizer)
        {
            var min = DateTime.Now.Year;
            var max = min + 100;

            return randomizer.Next(min, max);
        }
    }
}
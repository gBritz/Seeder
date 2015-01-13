using System;

namespace Seeder.Generators
{
    public class CpfGenerator : IGenerator
    {
        private readonly String format = "{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}{10}";

        public Object Generate(Randomizer randomizer)
        {
            var options = new Randomizer.Options
            {
                MaxLength = 9,
                Min = 0,
                Max = 9
            };
            var integers = randomizer.NextIntegers(options);
            return Generate(integers);
        }

        public String Generate(Int32[] n)
        {
            var d1 = n[8] * 2 + n[7] * 3 + n[6] * 4 + n[5] * 5 + n[4] * 6 + n[3] * 7 + n[2] * 8 + n[1] * 9 + n[0] * 10;
            d1 = 11 - (d1 % 11);
            if (d1 >= 10)
                d1 = 0;

            var d2 = d1 * 2 + n[8] * 3 + n[7] * 4 + n[6] * 5 + n[5] * 6 + n[4] * 7 + n[3] * 8 + n[2] * 9 + n[1] * 10 + n[0] * 11;
            d2 = 11 - (d2 % 11);
            if (d2 >= 10)
                d2 = 0;

            return String.Format(format, n[0], n[1], n[2], n[3], n[4], n[5], n[6], n[7], n[8], d1, d2);
        }
    }
}
using System;

namespace Seeder
{
    public class Randomizer
    {
        private Random randomizer;

        public Randomizer(Random randomizer)
        {
            if (randomizer == null)
                throw new ArgumentNullException("randomizer");

            this.randomizer = randomizer;
        }

        public Randomizer() : this(new Random()) { }

        public Int32 Next(Options options)
        {
            return Next(options.Min, options.Max);
        }

        public Int32 Next(Int32 min, Int32 max)
        {
            return this.randomizer.Next(min, max);
        }

        public Boolean NextBoolean()
        {
            var result = randomizer.Next(0, 1);
            return Convert.ToBoolean(result);
        }

        public T Shuffle<T>(T[] items)
        {
            if (items.IsEmpty())
                throw new ArgumentException("Parâmetro não pode ser nulo ou vazio.", "items");

            return items[Next(0, items.Length - 1)];
        }

        public Int32 NextNatural(Int32 max)
        {
            return Next(0, max);
        }

        public String NextString(Options options)
        {
            var values = NextIntegers(options);
            return String.Join(String.Empty, values);
        }

        public Int32[] NextIntegers(Options options)
        {
            var result = new Int32[options.MaxLength];

            for (var i = 0; i < result.Length; i++)
                result[i] = randomizer.Next(options.Min, options.Max);

            return result;
        }

        public static Options CreateRange(Int32 min, Int32 max)
        {
            return new Options
            {
                Min = min,
                Max = max
            };
        }

        public struct Options
        {
            public Int32 MaxLength { get; set; }
            public Int32 Min { get; set; }
            public Int32 Max { get; set; }
        }
    }
}
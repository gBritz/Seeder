using System;
using System.Linq;
using System.Text;

namespace Seeder.Generators
{
    public class SyllableGenerator : IGenerator
    {
        private readonly Char[] consonants = "bcdfghjklmnprstvwz".ToCharArray();
        private readonly Char[] vowels = "aeiou".ToCharArray();
        private readonly Char[] all;

        public SyllableGenerator()
        {
            this.all = this.consonants.Concat(vowels).ToArray();
        }

        public Object Generate(Randomizer randomizer)
        {
            var length = randomizer.Next(2, 3);
            return Generate(length, randomizer);
        }

        public String Generate(Int32 count, Randomizer randomizer)
        {
            if (count < 0)
                throw new ArgumentException("Should be positive number.", "count");

            var sb = new StringBuilder();

            var letters = this.all;
            var chr = randomizer.Shuffle(letters);

            for (var i = 0; i < count; i++)
            {
                sb.Append(chr);

                letters = consonants.Contains(chr) ? this.vowels : this.consonants;
                chr = randomizer.Shuffle(letters);
            }

            return sb.ToString();
        }
    }
}
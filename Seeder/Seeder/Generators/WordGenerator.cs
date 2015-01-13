using System;
using System.Text;

namespace Seeder.Generators
{
    public class WordGenerator : IGenerator
    {
        private SyllableGenerator syllable;

        public WordGenerator(SyllableGenerator syllable)
        {
            if (syllable == null)
                throw new ArgumentNullException("syllable");

            this.syllable = syllable;
        }

        public Object Generate(Randomizer randomizer)
        {
            return Generate(0, randomizer);
        }

        public String Generate(Int32 wordSize, Randomizer randomizer)
        {
            var syllables = randomizer.Next(1, 3);
            return Generate(syllables, wordSize, randomizer);
        }

        public String Generate(Int32 syllables, Int32 wordSize, Randomizer randomizer)
        {
            var result = String.Empty;
            var sb = new StringBuilder();

            if (wordSize > 0)
            {
                // Either bound word by length
                do
                {
                    sb.Append(this.syllable.Generate(randomizer));
                }
                while (sb.Length < wordSize);

                result = sb.ToString(0, wordSize);
            }
            else
            {
                // Or by number of syllables
                for (var i = 0; i < syllables; i++)
                    sb.Append(this.syllable.Generate(randomizer));

                result = sb.ToString();
            }

            return result;
        }
    }
}
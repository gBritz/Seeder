using System;

namespace Seeder.Generators
{
    public class BirthdayGenerator : IGenerator
    {
        private AgeGenerator age;

        public BirthdayGenerator(AgeGenerator age)
        {
            if (age == null)
                throw new ArgumentNullException("age");

            this.age = age;
        }

        public Object Generate(Randomizer randomizer)
        {
            return GenererateDate(randomizer);
        }

        public DateTime GenererateDate(Randomizer randomizer)
        {
            var yearAge = age.Next(randomizer);
            return DateTime.Now.AddYears(-yearAge);
        }
    }
}
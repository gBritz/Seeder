using System;
using System.Linq;

namespace Seeder.Generators
{
    public class GenderGenerator : IGenerator
    {
        public enum Type
        {
            Male = 0,
            Female = 1,
            All = 2
        }

        private Type[] genders;

        public Type[] Genders
        {
            get
            {
                if (this.genders == null)
                    this.genders = Enum.GetValues(typeof(Type)).OfType<Type>().ToArray();

                return this.genders;
            }
        }

        public Object Generate(Randomizer randomizer)
        {
            return Next(randomizer).ToString();
        }

        public Type Next(Randomizer randomizer)
        {
            return randomizer.Shuffle(Genders);
        }
    }
}
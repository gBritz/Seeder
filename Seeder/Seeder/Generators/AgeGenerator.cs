using System;

namespace Seeder.Generators
{
    public class AgeGenerator : IGenerator
    {
        public enum Type
        {
            None,
            Child,
            Teen,
            Adult,
            Senior,
            All
        }

        public Object Generate(Randomizer randomizer)
        {
            return Next(Type.All, randomizer);
        }

        public Int32 Next(Randomizer randomizer)
        {
            return Next(Type.All, randomizer);
        }

        public Int32 Next(Type type, Randomizer randomizer)
        {
            var options = CreateRangeBy(type);
            return randomizer.Next(options);
        }

        private Randomizer.Options CreateRangeBy(Type type)
        {
            switch (type)
            {
                case Type.Child:
                    return Randomizer.CreateRange(1, 12);

                case Type.Teen:
                    return Randomizer.CreateRange(13, 19);

                case Type.Adult:
                    return Randomizer.CreateRange(18, 65);

                case Type.Senior:
                    return Randomizer.CreateRange(65, 100);

                case Type.All:
                    return Randomizer.CreateRange(1, 100);

                default:
                    return Randomizer.CreateRange(18, 65);
            }
        }
    }
}
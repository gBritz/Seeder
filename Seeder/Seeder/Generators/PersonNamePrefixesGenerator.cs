using System;
using System.Collections.Generic;

namespace Seeder.Generators
{
    public class PersonNamePrefixesGenerator : IGenerator
    {
        public struct PrefixeInfo
        {
            public String name;
            public String abbreviation;

            public static PrefixeInfo Create(String name, String abbreviation)
            {
                return new PrefixeInfo
                {
                    name = name,
                    abbreviation = abbreviation
                };
            }
        }

        public Object Generate(Randomizer randomizer)
        {
            return Generate(GenderGenerator.Type.All, randomizer).name;
        }

        public PrefixeInfo Generate(GenderGenerator.Type genderType, Randomizer randomizer)
        {
            var prefixes = GetInfosBy(genderType);
            return randomizer.Shuffle(prefixes);
        }

        public virtual PrefixeInfo[] GetInfosBy(GenderGenerator.Type type)
        {
            var prefixes = new List<PrefixeInfo>
            {
                PrefixeInfo.Create("Doctor", "Dr.")
            };

            if (type == GenderGenerator.Type.Male || type == GenderGenerator.Type.All)
                prefixes.Add(PrefixeInfo.Create("Mister", "Mr."));

            if (type == GenderGenerator.Type.Female || type == GenderGenerator.Type.All)
            {
                prefixes.Add(PrefixeInfo.Create("Miss", "Miss"));
                prefixes.Add(PrefixeInfo.Create("Misses", "Mrs."));
            }

            return prefixes.ToArray();
        }
    }
}
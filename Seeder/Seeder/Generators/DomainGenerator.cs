using System;

namespace Seeder.Generators
{
    public class DomainGenerator : IGenerator
    {
        private readonly String[] domains = new[] { "com", "org", "edu", "gov", "co.uk", "net", "io" };

        public Object Generate(Randomizer randomizer)
        {
            return GenerateDomain(randomizer);
        }

        public String GenerateDomain(Randomizer randomizer)
        {
            return randomizer.Shuffle(domains);
        }
    }
}
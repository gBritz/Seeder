using System;

namespace Seeder.Generators
{
    public class EmailGenerator : IGenerator
    {
        private static readonly String format = "{0}@{1}.{2}";

        private WordGenerator word;
        private DomainGenerator domain;

        public EmailGenerator(WordGenerator word, DomainGenerator domain)
        {
            if (word == null)
                throw new ArgumentNullException("word");
            if (domain == null)
                throw new ArgumentNullException("domain");

            this.word = word;
            this.domain = domain;
        }

        public Object Generate(Randomizer randomizer)
        {
            var domain = this.domain.GenerateDomain(randomizer);
            return Generate(domain, randomizer);
        }

        public String Generate(String domain, Randomizer randomizer)
        {
            if (String.IsNullOrEmpty(domain))
                throw new ArgumentNullException("domain");

            return Generate(0, domain, randomizer);
        }

        public String Generate(Int32 sizeWord, String domain, Randomizer randomizer)
        {
            var userName = this.word.Generate(sizeWord, randomizer);
            var mailService = this.word.Generate(sizeWord, randomizer);
            var domainName = domain ?? this.word.Generate(sizeWord, randomizer);

            return String.Format(format, userName, mailService, domainName);
        }
    }
}
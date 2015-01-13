using Seeder.Conventions;
using Seeder.Generators;
using System;

namespace Seeder
{
    public static class Seeder
    {
        public static ConventionExecuter CreateInstance()
        {
            var randomizer = new Randomizer();
            var syllable = new SyllableGenerator();
            var word = new WordGenerator(syllable);
            var domain = new DomainGenerator();
            var age = new AgeGenerator();


            var chance = new Chance(randomizer)
                .Add("cpf", new CpfGenerator())
                .Add("age", age)
                .Add("syllable", syllable)
                .Add("word", word)
                .Add("domain", domain)
                .Add("email", new EmailGenerator(word, domain))
                .Add("name", new PersonNameGenerator())
                .Add("birthday", new BirthdayGenerator(age))
                ;


            return new ConventionExecuter()
                .Add<Int32>(new IdConvention(), chance.GetPositive)
                .Add<Int32>(new AgeConvention(), chance.GetAge)
                .Add(new CpfConvention(), chance.GetCpf)
                .Add(new PersonNameConvention(), chance.GetName)
                .Add(new EmailConvention(), chance.GetEmail)
                .Add<DateTime>(new BirthdayConvention(), chance.GetBirthday)
                ;
        }
    }
}
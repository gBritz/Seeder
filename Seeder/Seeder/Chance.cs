using System;
using System.Collections.Generic;

namespace Seeder
{
    /// <summary>
    /// http://chancejs.com/
    /// </summary>
    public class Chance
    {
        private Randomizer randomizer;
        private IDictionary<String, IGenerator> generators;

        public Chance(Randomizer randomizer)
        {
            if (randomizer == null)
                throw new ArgumentNullException("randomizer");

            this.randomizer = randomizer;
            this.generators = new Dictionary<String, IGenerator>();
        }

        public Chance Add(String name, IGenerator creator)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (creator == null)
                throw new ArgumentNullException("creator");

            if (this.generators.ContainsKey(name))
                this.generators[name] = creator;
            else
                this.generators.Add(name, creator);

            return this;
        }

        #region Numbers

        public Int32 GetInteger()
        {
            return this.randomizer.Next(Int32.MinValue, Int32.MaxValue);
        }

        public Int32 GetNatural()
        {
            return this.randomizer.Next(0, Int32.MaxValue);
        }

        public Int32 GetPositive()
        {
            return this.randomizer.Next(1, Int32.MaxValue);
        }

        public Int32 GetNegative()
        {
            return this.randomizer.Next(Int32.MinValue, -1);
        }

        #endregion

        #region Person

        public String GetGender()
        {
            return GetNext<String>("gender");
        }

        public Int32 GetAge()
        {
            return GetNext<Int32>("age");
        }

        public String GetName()
        {
            return GetNext<String>("name");
        }

        public String GetCpf()
        {
            return GetNext<String>("cpf");
        }

        public DateTime GetBirthday()
        {
            return GetNext<DateTime>("birthday");
        }

        #endregion

        #region Web/Net

        public String GetEmail()
        {
            return GetNext<String>("email");
        }

        public String GetDomain()
        {
            return GetNext<String>("domain");
        }

        #endregion

        #region Language

        public String GetWord()
        {
            return GetNext<String>("word");
        }

        public String GetSyllable()
        {
            return GetNext<String>("syllable");
        }

        #endregion

        protected virtual T GetNext<T>(String name)
        {
            var value = CreateData(name);
            return value == null ? default(T) : (T)value;
        }

        protected Object CreateData(String name)
        {
            if (!this.generators.ContainsKey(name))
                return String.Empty;

            var generator = this.generators[name];
            return generator == null ? null : generator.Generate(randomizer);
        }
    }
}
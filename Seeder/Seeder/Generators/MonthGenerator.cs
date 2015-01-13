using System;

namespace Seeder.Generators
{
    public class MonthGenerator : IGenerator
    {
        public struct MonthInfo
        {
            public String Name;
            public String ShortName;
            public Int16 Numeric;
            public Int16 Days;

            public static MonthInfo Create(String name, String shortName, Int16 numeric, Int16 days)
            {
                return new MonthInfo
                {
                    Name = name,
                    ShortName = shortName,
                    Numeric = numeric,
                    Days = days
                };
            }
        }

        private MonthInfo[] infos;

        public MonthInfo[] Infos
        {
            get
            {
                if (this.infos == null)
                    this.infos = CreateInfos();
                return this.infos;
            }
        }

        protected virtual MonthInfo[] CreateInfos()
        {
            return new[]
            {
                MonthInfo.Create("January", "Jan", 01, 31),
                // Not messing with leap years...
                MonthInfo.Create("February", "Feb", 02, 28),
                MonthInfo.Create("March", "Mar", 03, 31),
                MonthInfo.Create("April", "Apr", 04, 30),
                MonthInfo.Create("May", "May", 05, 31),
                MonthInfo.Create("June", "Jun", 06, 30),
                MonthInfo.Create("July", "Jul", 07, 31),
                MonthInfo.Create("August", "Aug", 08, 31),
                MonthInfo.Create("September", "Sep", 09, 30),
                MonthInfo.Create("October", "Oct", 10, 31),
                MonthInfo.Create("November", "Nov", 11, 30),
                MonthInfo.Create("December", "Dec", 12, 31)
            };
        }

        public Object Generate(Randomizer randomizer)
        {
            return Next(randomizer);
        }

        public MonthInfo Next(Randomizer randomizer)
        {
            return randomizer.Shuffle(Infos);
        }

        public Int32 NextMonth(Randomizer randomizer)
        {
            var days = randomizer.Shuffle(Infos).Days;
            return randomizer.Next(1, days);
        }
    }
}
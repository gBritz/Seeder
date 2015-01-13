using System;

namespace Seeder.Generators
{
    public class DateGenerator : IGenerator
    {
        private MonthGenerator monthGen;
        private YearGenerator yearGen;

        public DateGenerator(MonthGenerator month, YearGenerator year)
        {
            if (month == null)
                throw new ArgumentNullException("month");
            if (year == null)
                throw new ArgumentNullException("year");

            this.monthGen = month;
            this.yearGen = year;
        }

        public Object Generate(Randomizer randomizer)
        {
            return NextDate(randomizer);
        }

        public DateTime NextDate(Randomizer randomizer)
        {
            var monthInfo = monthGen.Next(randomizer);

            var year = yearGen.NextYear(randomizer);
            var month = monthInfo.Numeric;
            var day = randomizer.Next(1, monthInfo.Days);
            var hour = NextHour(randomizer, randomizer.NextBoolean());
            var minute = NextMinute(randomizer);
            var second = NextSecond(randomizer);

            return new DateTime(year, month, day, hour, minute, second);
        }

        protected Int32 NextHour(Randomizer randomizer, Boolean twentyFour)
        {
            var max = twentyFour ? 23 : 12;
            return randomizer.Next(1, max);
        }

        protected Int32 NextMinute(Randomizer randomizer)
        {
            return randomizer.NextNatural(59);
        }

        protected Int32 NextSecond(Randomizer randomizer)
        {
            return randomizer.NextNatural(59);
        }
    }
}
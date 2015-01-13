using System;
using System.Collections.Generic;
using System.Linq;

namespace Seeder
{
    public class ConventionExecuter
    {
        private IDictionary<IConvention, Func<Object>> conventions;

        public ConventionExecuter()
        {
            this.conventions = new Dictionary<IConvention, Func<Object>>();
        }

        public ConventionExecuter Add(IConvention convention, Func<Object> getData)
        {
            if (convention == null)
                throw new ArgumentNullException("specification");

            if (getData == null)
                throw new ArgumentNullException("getData");

            if (this.conventions.ContainsKey(convention))
                this.conventions[convention] = getData;
            else
                this.conventions.Add(convention, getData);

            return this;
        }

        public ConventionExecuter Add<T>(IConvention convention, Func<T> getData)
        {
            return Add(convention, () => (Object)getData());
        }

        public ConventionExecuter Remove(IConvention convention)
        {
            if (convention == null)
                throw new ArgumentNullException("specification");

            if (this.conventions.ContainsKey(convention))
                this.conventions.Remove(convention);

            return this;
        }

        public ClassMatch Analyze<TModel>() where TModel : class, new()
        {
            return AnalyseClass(typeof(TModel));
        }

        protected virtual ClassMatch AnalyseClass(Type type)
        {
            return new ClassMatch
            {
                getInstance = () => System.Activator.CreateInstance(type),
                properties = AnalyzeProperties(type),
                type = type
            };
        }

        protected virtual PropertyMatch[] AnalyzeProperties(Type type)
        {
            var result = new List<PropertyMatch>();

            var structureCode = new StructureCode();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (!property.CanWrite)
                    continue;

                structureCode.Set(property);

                var prop = new PropertyMatch();
                if (property.PropertyType.IsClass && !property.PropertyType.IsString())
                    prop.nested = AnalyseClass(property.PropertyType);
                else
                {
                    var dg = conventions.Where(d => d.Key.IsSpecifiedBy(structureCode));

                    if (!dg.Any())
                        continue;

                    var item = dg.First();

                    //var prop = PropertyMatch.Create(property, item.Value, item.Key);
                }

                result.Add(prop);
            }

            return result.ToArray();
        }

        public TModel Seed<TModel>() where TModel : class, new()
        {
            return Seed(new TModel());
        }

        public TModel[] Seed<TModel>(UInt32 count) where TModel : class, new()
        {
            var result = new TModel[count];

            for (var i = 0; i < count; i++)
                result[i] = Seed(new TModel());

            return result;
        }

        public TModel Seed<TModel>(TModel model) where TModel : class
        {
            var type = typeof(TModel);

            var structureCode = new StructureCode();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (!property.CanWrite)
                    continue;

                structureCode.Set(property);
                var dg = conventions.Where(d => d.Key.IsSpecifiedBy(structureCode));

                if (!dg.Any())
                    continue;

                var item = dg.First();
                property.SetValue(model, item.Value(), null);
            }

            return model;
        }
    }
}
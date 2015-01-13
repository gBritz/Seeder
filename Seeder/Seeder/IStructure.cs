using System;

namespace Seeder
{
    public interface IStructure
    {
        Boolean EqualName(String name);
        Boolean StartName(String name);
        Boolean ContainsName(String name);
        Boolean EndName(String name);

        Boolean Accept<T>();
        Boolean Accept(Type type);
    }
}
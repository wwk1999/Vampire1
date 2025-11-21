using System;

namespace Com.Tal.Unity.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonNameAttribute:Attribute
    {
        public string SingletonName { set; get; }

        public bool IsStatic { set; get; } = false;

        public SingletonNameAttribute(string name) => SingletonName = name;
    }
}
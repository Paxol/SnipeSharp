using System;

namespace SnipeSharp.Common
{
    public class NameAttribute : Attribute
    {
        public NameAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
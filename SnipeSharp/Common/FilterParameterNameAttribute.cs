using System;

namespace SnipeSharp.Common
{
    /// <summary>
    /// Used to tag class properties with the name we should use in the URL query
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterParameterNameAttribute : NameAttribute
    {
        public FilterParameterNameAttribute(string name) : base(name)
        {
        }
    }
}



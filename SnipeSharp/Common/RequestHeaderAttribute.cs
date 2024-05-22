using System;

namespace SnipeSharp.Common
{
    /// <summary>
    /// Since the SnipeIT Api uses inconsistent names between returned data and the headers needed on create we can use this attribute
    /// to pass in the header name we need when creating something
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RequestHeaderAttribute : NameAttribute
    {
        public RequestHeaderAttribute(string headerName)
            : this(headerName, false)
        {
        }

        public RequestHeaderAttribute(string headerName, bool isRequired)
            : base(headerName)
        {
            this.IsRequired = isRequired;
        }
               
        public bool IsRequired { get; }
    }
}

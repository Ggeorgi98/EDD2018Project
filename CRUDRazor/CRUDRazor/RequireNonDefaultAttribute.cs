using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDRazor
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequireNonDefaultAttribute : RequiredAttribute
    {
        public RequireNonDefaultAttribute()
        {
            this.ErrorMessage = "The {0} field requires a non-default value";
        }

        public override bool IsValid(object value)
        {
            return !Equals(value, Activator.CreateInstance(value.GetType()));
        }
    }
}

using System;
namespace ValidationComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute: Attribute
    {
        public string ErrorMessage { get; set; }
        public RequiredAttribute()
        {
            ErrorMessage = "You cannot leave filed, {0}, empty";
        }

        public RequiredAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}


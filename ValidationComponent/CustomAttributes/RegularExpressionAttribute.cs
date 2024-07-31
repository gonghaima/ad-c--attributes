using System;
namespace ValidationComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class RegularExpressionAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
        public string Pattern { get; set; }
        
        public RegularExpressionAttribute()
        {
            ErrorMessage = "You cannot leave filed, {0}, empty";
        }

        public RegularExpressionAttribute(string pattern)
        {
            Pattern = pattern;
            ErrorMessage = $"The field {0} must match the regular expression {pattern}";
        }

        public RegularExpressionAttribute(string pattern, string errorMessage)
        {
            Pattern = pattern;
            ErrorMessage = errorMessage;
        }
        
    }
}


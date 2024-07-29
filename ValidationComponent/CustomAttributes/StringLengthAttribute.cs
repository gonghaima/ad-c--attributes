using System;
namespace ValidationComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class StringLengthAttribute: Attribute
    {
        public int MaxLength {get; set;}
        public int MinLength {get; set;}
        public string ErrorMessage { get; set; }
        public StringLengthAttribute()
        {
            ErrorMessage = "You cannot leave filed, {0}, empty";
        }

        public StringLengthAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public StringLengthAttribute(int maxLength)
        {
            SetProperties(maxLength);
        }

        public StringLengthAttribute(int maxLength, string errorMessage)
        {
            SetProperties(maxLength, errorMessage);
        }

        public StringLengthAttribute(int maxLength, int minLength)
        {
            SetProperties(maxLength, minLength: minLength);
        }

        public StringLengthAttribute(int maxLength, int minLength, string errorMessage)
        {
            SetProperties(maxLength, errorMessage, minLength);
        }



        private void SetProperties( int maxLength, string errorMessage = "", int? minLength = null)
        {
            if(errorMessage =="")
            {
                if(minLength==null)
                {
                    ErrorMessage = "The field {0} must be a string with a maximum length of {1}";
                }
                else
                {
                    ErrorMessage = "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}";
                }
            }else
            {
                ErrorMessage = errorMessage;
            }
            MaxLength = maxLength;
            MinLength = minLength ?? 0;
        }
    }
}


using System;
using System.Reflection;
using ValidationComponent.CustomAttributes;
namespace ValidationComponent.CustomAttributes
{
    public static class Validation
    {
        public static bool PropertyValueIsValid (Type t, string enteredValue, string elementName, out string errorMessage)
        {
            PropertyInfo prop = t.GetProperty(elementName);
            Attribute[] attributes = prop.GetCustomAttributes().ToArray();

            errorMessage = string.Empty;
            foreach (Attribute attribute in attributes)
            {
                switch(attribute)
                {
                    case RequiredAttribute requiredAttribute:
                        if (!FieldRequiredIsValid(enteredValue))
                        {
                            errorMessage = requiredAttribute.ErrorMessage;
                            return false;
                        }
                        break;
                    case StringLengthAttribute stringLengthAttribute:
                        if (!StringLengthIsValid(stringLengthAttribute, enteredValue))
                        {
                            errorMessage = stringLengthAttribute.ErrorMessage;
                            return false;
                        }
                        break;
                    case RegularExpressionAttribute regularExpressionAttribute:
                        if (!FieldPatternMatchIsValid(regularExpressionAttribute, enteredValue))
                        {
                            errorMessage = regularExpressionAttribute.ErrorMessage;
                            return false;
                        }
                        break;
                }
            }
            return true;
        }
        private static bool FieldRequiredIsValid(string enteredVvalue)
        {
            if (string.IsNullOrEmpty(enteredVvalue))
            {
                Console.WriteLine("You cannot leave field, {0}, empty", enteredVvalue);
                return false;
            }
            return true;
        }

        private static bool StringLengthIsValid(StringLengthAttribute stringLengthAttribute, string enteredValue)
        {
            if (enteredValue.Length < stringLengthAttribute.MinLength || enteredValue.Length > stringLengthAttribute.MaxLength)
            {
                Console.WriteLine(stringLengthAttribute.ErrorMessage, enteredValue, stringLengthAttribute.MaxLength, stringLengthAttribute.MinLength);
                return false;
            }
            return true;
        }

        private static bool FieldPatternMatchIsValid(RegularExpressionAttribute regularExpressionAttribute, string enteredValue)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(enteredValue, regularExpressionAttribute.Pattern))
            {
                Console.WriteLine(regularExpressionAttribute.ErrorMessage, enteredValue);
                return false;
            }
            return true;
        }


    }
}


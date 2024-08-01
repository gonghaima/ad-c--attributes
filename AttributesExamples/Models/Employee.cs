using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

using ValidationComponent.CustomAttributes;

namespace AttributesExamples.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        [JsonIgnore]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        [RegularExpression(@"\s*\(?0\d{4}\)?\s*\d{6}\s*)|(\s*\(?0\d{3}\)?\s*\d{3}\s*\d{4}\s*")]
        [JsonIgnore]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        [JsonIgnore]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        [RegularExpression(@"^ ?(([BEGLMNSWbeglmnsw][0-9][0-9]?)|(([A-PR-UWYZa-pr-uwyz][A-HK-Ya-hk-y][0-9][0-9]?)|(([ENWenw][0-9][A-HJKSTUWa-hjkstuw])|([ENWenw][A-HK-Ya-hk-y][0-9][ABEHMNPRVWXYabehmnprvwxy])))) ?[0-9][ABD-HJLNP-UW-Zabd-hjlnp-uw-z]{2}$")]
        // [JsonIgnore]
        public string PostCode { get; set; }
    }
}
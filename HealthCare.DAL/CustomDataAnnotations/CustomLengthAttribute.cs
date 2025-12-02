using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.CustomDataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class CustomLengthAttribute:ValidationAttribute
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public CustomLengthAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }
        public override bool IsValid(object? value)
        {
            if (value is string result)
            {
                if (result.Length > _minLength && result.Length < _maxLength) 
                return true;
            }
            return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return $"the length of the {name} Field must be between {_minLength} and {_maxLength}";
        }
    }
}

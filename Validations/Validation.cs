using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Validations
{
    public class Validation : IValidation
    {
        private readonly ValidationResultCollection _result;

        private object _target;
        public Validation()
        {
            _result = new ValidationResultCollection();
        }


        public ValidationResultCollection Validate(object target)
        {
            if (target == null)
                return _result;
            _target = target;
            Type type = _target.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var propertie in properties)
            {
                ValidateProperty(propertie);
            }
            return _result;
        }

        private void ValidateProperty(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
            foreach (var attribute in attributes)
            {
                ValidationAttribute validationAttribute = attribute as ValidationAttribute;
                if (validationAttribute == null)
                    continue;
                ValidateAttribute(property, validationAttribute);
            }
        }

        private void ValidateAttribute(PropertyInfo property, ValidationAttribute attribute)
        {
            bool isValid = attribute.IsValid(property.GetValue(_target));
            if (isValid)
                return;
            _result.Add(new ValidationResult(GetErrorMessage(attribute)));
        }

        private string GetErrorMessage(ValidationAttribute attribute)
        {
            if (!string.IsNullOrEmpty(attribute.ErrorMessage))
                return attribute.ErrorMessage;
            return string.Format("{0},{1}，{2}", attribute.ErrorMessageResourceType.FullName,
                attribute.ErrorMessageResourceName, attribute.ErrorMessageResourceType.Assembly);

        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace InputValidation.DataAnnotations
{
    public class AtLeastOneRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string[] _properties;

        public AtLeastOneRequiredAttribute(params string[] properties)
        {
            _properties = properties;
        }

        /// <summary>
        /// 設定後端驗證規則
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Person person = validationContext.ObjectInstance as Person;

            if (_properties == null || _properties.Length < 1)
            {
                return null;
            }

            foreach (var property in _properties)
            {
                var propertyInfo = validationContext.ObjectType.GetProperty(property);
                if (propertyInfo == null)
                {
                    return new ValidationResult(string.Format("unknown property {0}", property));
                }

                var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
                if (propertyValue is string && !string.IsNullOrEmpty(propertyValue as string))
                {
                    return null;
                }

                if (propertyValue != null)
                {
                    return null;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        /// <summary>
        /// 設定前端的 html attribute, 供 jQuery validation 辨認
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                // 此 2 property 必填
                ErrorMessage = ErrorMessage,
                // ValidationType 必須唯一
                ValidationType = "atleastonerequired"
            };
            rule.ValidationParameters["myparams"] = string.Join(",", _properties);

            yield return rule;
        }
    }
}
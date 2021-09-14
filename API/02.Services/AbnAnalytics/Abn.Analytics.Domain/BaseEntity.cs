using Abn.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Domain
{
    public class DomainEntity:BaseEntity<Guid>
    {
         

        public virtual ValidationMessage Validate()
        {
            var result = new ValidationMessage();
            var modelToValidate = this;
            if (modelToValidate == null)
            {
                result.Failed("the input object is null");
                return result;
            }

            var context = new ValidationContext(modelToValidate, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(modelToValidate, context, validationResults, true);
            if (isValid)
            {

                result.SetSuccess();
                return result;
            }
            else
            {
                var errors = validationResults.Select(a => a.ErrorMessage).ToList();
                result.Failed(errors);
                return result;
            }
        }
    }
}

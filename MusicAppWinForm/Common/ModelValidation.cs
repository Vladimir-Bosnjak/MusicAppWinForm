using System.ComponentModel.DataAnnotations;
using System.Text;


/*
   Usage:

YourModel model = new YourModel();
// Set the properties of the model

ModelValidator<YourModel> validator = new ();
ICollection<ValidationResult> validationResults;

bool isValid = validator.ValidateModel(model, out validationResults);

if (!isValid)
{
    // Handle validation errors
    foreach (var validationResult in validationResults)
    {
        // Process each validation error
        // e.g., log the error, display error messages, etc.
    }
}

 */

namespace PresentationLayer.Common
{
    public class ModelValidator<TModel>
    {
        public ICollection<ValidationResult>? ValidationResults { get; private set; }

        public bool ValidateModel(TModel modelInstance)
        {
            ValidationResults = new List<ValidationResult>();

            if (modelInstance == null)
            {
                // Optionally, you can add a specific validation result for null modelInstance
                var nullModelError = new ValidationResult("The model instance is null.");
                ValidationResults.Add(nullModelError);

                return false;
            }

            var context = new ValidationContext(modelInstance);
            return Validator.TryValidateObject(modelInstance, context, ValidationResults, validateAllProperties: true);
        }

        //--

        public string GetFormattedValidationResults()
        {
            var sb = new StringBuilder();

            if (ValidationResults != null && ValidationResults.Any())
            {
                foreach (var result in ValidationResults)      
                    sb.AppendLine(result.ErrorMessage);        
            }

            return sb.ToString();
        }
    }
}

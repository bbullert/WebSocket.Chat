using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Chat.Api.Extnesions
{
    internal static class ModelStateDictionaryExtension
    {
        public static void AddValidation(this ModelStateDictionary modelState, ValidationResult result)
        {
            if (result.IsValid) return;
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
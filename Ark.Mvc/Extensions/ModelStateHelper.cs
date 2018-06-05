using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ark.Mvc.Extensions
{
    public static class ModelStateHelper
    {
        public static ContentResult ErrorsToJsonResult(this ModelStateDictionary modelState)
        {
            IEnumerable<KeyValuePair<string, string[]>> errors = modelState.IsValid
                ? null
                : modelState
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray())
                    .Where(m => m.Value.Any());
            return new ContentResult
            {
                //Content = JsonConvert.SerializeObject(errors, settings),
                ContentType = "application/json"
            };
        }

        public static string GetModelStateErrors(this ModelStateDictionary modelState)
        {
            IEnumerable<KeyValuePair<string, string[]>> errors = modelState.IsValid
                ? null
                : modelState
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray())
                    .Where(m => m.Value.Any());

            string output = "{";

            if (errors != null)
            {
                foreach (KeyValuePair<string, string[]> kvp in errors)
                {
                    output += "\"" + kvp.Key.Replace(".", "") + "\":\"" + String.Join(", ", kvp.Value) + "\",";
                }
            }
            output = output.TrimEnd(',');
            output += "}";
            return output;
        }
    }
}

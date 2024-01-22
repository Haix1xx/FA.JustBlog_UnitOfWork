using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FA.JustBlog.Helpers
{
    public static class ModelValidateMessage
    {
        public static string GenerateMessages(ModelStateDictionary ModelState)
        {
            var errorMessage = "";
            foreach (var modelStateKey in ModelState.Keys)
            {
                var modelStateVal = ModelState[modelStateKey];

                foreach (var error in modelStateVal.Errors)
                {
                    var key = modelStateKey;
                    errorMessage += error.ErrorMessage + "\n";
                }
            }
            return errorMessage;
        }
    }
}

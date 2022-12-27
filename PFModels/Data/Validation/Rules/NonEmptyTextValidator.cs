using System;

namespace PFModels.Data.Validation.Rules
{
    public class NonEmptyTextValidator : IValidator
    {
        public bool Validate(string Input, out string error)
        {
            error = "";

            if (String.IsNullOrWhiteSpace(Input))
            {
                error = "The Input cannot be empty.";
                return false;
            }

            return true;
        }
    }
}
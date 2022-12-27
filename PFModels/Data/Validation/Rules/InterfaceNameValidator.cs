using System;

namespace PFModels.Data.Validation.Rules
{
    public class InterfaceNameValidator : IValidator
    {
        public bool Validate(string Input, out string error)
        {
            error = "";

            if (String.IsNullOrWhiteSpace(Input))
            {
                error = "The Interface name cannot be empty.";
                return false;
            }

            return true;
        }
    }
}
using System;

namespace PFModels.Data.Validation.Rules
{
    public class NonNegativeIntValidator : IValidator
    {
        public bool Validate(string Input, out string error)
        {
            error = "";
            int value;

            if (!Int32.TryParse(Input, out value) || value < 0)
            {
                error = "The Input should be A NonNegative Integer.";
                return false;
            }

            return true;
        }
    }
}
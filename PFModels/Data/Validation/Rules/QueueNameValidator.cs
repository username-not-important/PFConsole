using System;

namespace PFModels.Data.Validation.Rules
{
    public class QueueNameValidator : IValidator
    {
        public bool Validate(string Input, out string error)
        {
            error = "";

            if (String.IsNullOrWhiteSpace(Input))
            {
                error = "The Queue name cannot be empty.";
                return false;
            }

            if (Input.Length > 15)
            {
                error = "Queue names cannot be longer than 15 characters.";
                return false;
            }

            return true;
        }
    }
}
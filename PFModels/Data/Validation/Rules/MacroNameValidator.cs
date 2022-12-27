using System;
using System.Linq;

namespace PFModels.Data.Validation.Rules
{
    public class MacroNameValidator : IValidator
    {
        public bool Validate(string Input, out string error)
        {
            error = "";

            if (String.IsNullOrWhiteSpace(Input))
            {
                error = "Macro Name cannot be empty.";
                return false;
            }

            if (Input.Any(c => !Char.IsLetterOrDigit(c) && c != '_'))
            {
                error = "Macro Name can only contain letters and digits.";
                return false;
            }

            if (!char.IsLetter(Input[0]))
            {
                error = "Macro Names should start with a letter.";
                return false;
            }

            return true;
        }
    }
}
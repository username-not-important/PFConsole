using PFModels.Data.Validation.Rules;

namespace PFModels.Data.Validation
{
    public class Validator
    {
        public static bool Validate(string Input, out string error, params IValidator[] rules)
        {
            bool flag = true;
            error = "";

            foreach (var validationRule in rules)
                if (!Validate(Input, out error, validationRule))
                    return false;

            return true;
        }

        private static bool Validate(string Input, out string error, IValidator rule)
        {
            return rule.Validate(Input, out error);
        }
    }
}
namespace PFModels.Data.Validation.Rules
{
    public class TextValidator : IValidator
    {
        public bool Validate(string Input, out string error)
        {
            error = "";
            return true;
        }
    }
}
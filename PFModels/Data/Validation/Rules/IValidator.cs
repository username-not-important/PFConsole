namespace PFModels.Data.Validation.Rules
{
    public interface IValidator
    {
        bool Validate(string Input, out string error);
    }
}
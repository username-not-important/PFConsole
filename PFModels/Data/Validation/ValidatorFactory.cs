using System;
using PFModels.Data.Validation.Rules;

namespace PFModels.Data.Validation
{
    public static class ValidatorFactory
    {
        public static IValidator CreateValidator(string name)
        {
            name += "Validator";

            Type t = Type.GetType(name);

            var constructor = t.GetConstructor(new Type[0]);
            return (IValidator) constructor.Invoke(new object[0]);
        }
    }
}
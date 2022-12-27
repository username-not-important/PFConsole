using System;

namespace PFModels.Data.Validation.Rules
{
    public class RangedIntValidator : IValidator
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public bool Validate(string Input, out string error)
        {
            error = "";

            int x = -1;
            if (!Int32.TryParse(Input, out x))
            {
                error = "The Input should be an integer number.";
                return false;
            }

            if (x > Max || x < Min)
            {
                error = "The Input number should be in range [" + Min + "," + Max + "].";
                return false;
            }

            return true;
        }
    }
}
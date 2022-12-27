using System;
using System.Linq;

namespace PFModels.Data.Validation.Rules
{
    public class IPv4SubnetValidator : IValidator
    {
        public bool Validate(string Input, out string error)
        {
            error = "";

            //ex: 192.168.0.1/24
            if (String.IsNullOrWhiteSpace(Input))
            {
                error = "An IP Address cannot be empty.";
                return false;
            }

            if (Input[0] == '$')
                return true;

            if (Input[0] == '!' && Input.Length > 2)
                Input = Input.Substring(1);

            var split = Input.Split('.');

            if (split.Length < 4)
            {
                error = "IPv4 and Subnet should be defined like XXX.XXX.XXX.XXX[/XX]";
                return false;
            }

            string subnet = "0";
            if (split[3].Contains('/'))
            {
                var lastpart = split[3].Split('/');

                subnet = lastpart[1];
                split[3] = lastpart[0];
            }

            int[] parts = new int[4];
            int subnetVal = 0;
            if (!Int32.TryParse(split[0], out parts[0]) ||
                !Int32.TryParse(split[1], out parts[1]) ||
                !Int32.TryParse(split[2], out parts[2]) ||
                !Int32.TryParse(split[3], out parts[3]) ||
                !Int32.TryParse(subnet, out subnetVal))
            {
                error = "Input each part correctly.";
                return false;
            }

            return true;
        }
    }
}
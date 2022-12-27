using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFModels.Data;

namespace PFConsole.Project.Compiler.Assets
{
    class OptionAsset : IAsset
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public OptionAsset(Option option)
        {
            Key = option.Meta.Code;
            Value = option.Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFModels.Data;

namespace PFConsole.Project.Compiler.Assets
{
    class TableAsset : IAsset
    {
        public string Assignment { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }

        public TableAsset(Table t)
        {
            Assignment = string.Format("<{0}>", t.Name);
            Attribute = t.Attribute;
            Value = t.Content != null ? t.Content.GetInlineDefinition(false) : "";
        }
    }
}

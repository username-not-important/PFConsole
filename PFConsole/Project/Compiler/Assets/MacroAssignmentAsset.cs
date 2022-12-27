using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PFModels.Data;

namespace PFConsole.Project.Compiler.Assets
{
    class MacroAssignmentAsset : IAsset
    {
        public string MacroAssignment { get; set; }
        public string Value { get; set; }

        public MacroAssignmentAsset(Macro macro)
        {
            MacroAssignment = macro.Name;

            Value = string.Format("\"{0}\"", macro.Content.GetInlineDefinition(true));
            Value = Value.Replace("\" \"", "").Replace("\"\"", "").Replace("  "," ").Replace("{ \"", "{\"").Replace("\" }", "\"}");

            Regex rg = new Regex("\"[^\"]+\"");

            string temp = Value;

            var matches = rg.Matches(Value);
            for (int i = 0; i < matches.Count; i++)
            {
                temp = temp.Replace(matches[i].Value, "'" + matches[i].Value + "'");
            }

            Value = temp;
        }

        public MacroAssignmentAsset(string macroAssignment, string value)
        {
            MacroAssignment = macroAssignment;

            Value = string.Format("\"{0}\"", value);
        }
    }
}

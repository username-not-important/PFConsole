using System;
using System.Collections.Generic;
using System.Linq;
using PFModels.Data;

namespace PFConsole.Project.DataHelpers
{
    /// <summary>
    ///     Used to Find usages of a specific Macro by Traversing macro-tree of the project.
    /// </summary>
    internal class TraverseMacroHelper
    {
        public List<Macro> GetMacroUsage(PFProject project, Macro target)
        {
            return project.Macros.Macros.Where(macro => !macro.Equals(target))
                .Where(macro => findUsage(target, macro.Content))
                .ToList();
        }

        private bool findUsage(Macro target, MacroContent findIn)
        {
            Type contentType = findIn.GetType();

            if (contentType == typeof(Macro) && findIn.Equals(target))
                return true;

            if (contentType == typeof(NegatedMacroContent))
                return findUsage(target, ((NegatedMacroContent) findIn).Content);

            if (contentType == typeof(PFList))
                return (findIn as PFList).Items.Any(item => findUsage(target, item));

            return false;
        }
    }
}
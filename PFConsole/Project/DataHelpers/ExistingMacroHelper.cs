using System;
using System.Collections.ObjectModel;
using PFModels.Data;

namespace PFConsole.Project.DataHelpers
{
    /// <summary>
    ///     Used to assign existing objects for duplicate Macro Objects with the same Name Property.
    /// </summary>
    internal class ExistingMacroHelper
    {
        public static void AssignExistingMacros(PFProject project)
        {
            foreach (var macro in project.Macros.Macros)
                fixMacro(project, macro);
        }

        public static ObservableCollection<MacroContent> AssignExistingMacros(ObservableCollection<MacroContent> collection)
        {
            ObservableCollection<MacroContent> newCollection = new ObservableCollection<MacroContent>();
            if (collection == null)
                return newCollection;

            foreach (var content in collection)
                if (content is Macro)
                    newCollection.Add(PFProject.Instance.Macros[(content as Macro).Name]);
                else if (content is NegatedMacroContent || content is PFList)
                {
                    fix(PFProject.Instance, content);
                    newCollection.Add(content);
                }
                else
                    newCollection.Add(content);

            return newCollection;
        }

        private static void fixMacro(PFProject project, Macro macro)
        {
            if (macro.Content as Macro != null)
                macro.Content = assignOldMacro(project, macro.Content as Macro);
            else if (macro.Content as NegatedMacroContent != null || macro.Content as PFList != null)
                fix(project, macro.Content);
        }

        // FIX A Content that is not a Macro itself...
        private static void fix(PFProject project, MacroContent content)
        {
            Type contentType = content.GetType();

            if (contentType == typeof(NegatedMacroContent))
            {
                var macroContent = (content as NegatedMacroContent).Content as Macro;

                if (macroContent == null)
                    fix(project, (content as NegatedMacroContent).Content);
                else
                    (content as NegatedMacroContent).Content = assignOldMacro(project, macroContent);
            }
            else if (contentType == typeof(PFList))
            {
                var list = (content as PFList);
                for (int i = 0; i < list.Items.Count; i++)
                {
                    var item = list.Items[i];
                    if (item as Macro != null)
                        list.Items[i] = assignOldMacro(project, item as Macro);
                    else
                        fix(project, item);
                }
            }
        }

        private static Macro assignOldMacro(PFProject project, Macro input)
        {
            var find = project.Macros[input.Name];
            return find ?? input;
        }
    }
}
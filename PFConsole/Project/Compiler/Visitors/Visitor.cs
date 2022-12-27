using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;

namespace PFConsole.Project.Compiler.Visitors
{
    class Visitor
    {
        private static readonly Dictionary<Type, IVisitor> _visitors = new Dictionary<Type, IVisitor>()
        {
            {typeof(OptionAsset), new OptionsVisitor()}, 
            {typeof(CommentAsset), new CommentsVisitor()},
            {typeof(MacroAssignmentAsset), new MacroAssignmentVisitor()},
            {typeof(TableAsset), new TableVisitor()},
            {typeof(FilteringAsset), new FilteringVisitor()},
            {typeof(QueueMacroAsset), new QueueMacroVisitor()},
            {typeof(SchedulerMacroAsset), new SchedulerMacroVisitor()}
        };

        public static string Accept(IAsset asset)
        {
            return _visitors[asset.GetType()].Accept(asset);
        }
    }
}

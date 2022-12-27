using System;
using System.Collections.Generic;
using System.Windows;
using PFConsole.Views.Nodes;
using PFModels.Data;

namespace PFConsole.Views.Macros
{
    public class MacroUIElementSelector
    {
        public List<Tuple<Type, Type>> Views = new List<Tuple<Type, Type>>
        {
            new Tuple<Type, Type>(typeof(Interface), typeof(InterfaceNodeView)),
            new Tuple<Type, Type>(typeof(IPv4Address), typeof(IPAddressNodeView)),
            new Tuple<Type, Type>(typeof(NegatedMacroContent), typeof(NegatedMacroNodeView)),
            new Tuple<Type, Type>(typeof(Macro), typeof(MacroNodeView)),
            new Tuple<Type, Type>(typeof(HostName), typeof(HostNodeView)),
            new Tuple<Type, Type>(typeof(PFList), typeof(PFListNodeView)),
            new Tuple<Type, Type>(typeof(PortValue), typeof(PortValueNodeView)),
            new Tuple<Type, Type>(typeof(FileIPAddressList), typeof(FileNodeView))
        };

        public UIElement SelectElement(MacroContent content)
        {
            var type = Views.Find(c => c.Item1 == content.GetType());
            return CreateNew(type.Item2, content);
        }

        private UIElement CreateNew(Type T, object dataContext)
        {
            var cons = T.GetConstructor(new Type[0]);
            var obj = cons.Invoke(new object[0]);

            (obj as UIElement).SetValue(FrameworkElement.DataContextProperty, dataContext);

            return (obj as UIElement);
        }
    }
}
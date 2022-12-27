using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Infragistics.DragDrop;
using PFConsole.ContentPages;
using PFConsole.Project;
using PFConsole.Util;
using PFConsole.Views.Nodes;
using PFModels.Data;

namespace PFConsole.VisualResources.Behaviors
{
    public partial class ProjectTreeStyles : ResourceDictionary
    {
        private IDragDropHandler GetHandler(UIElement dropElement)
        {
            var element = (dropElement as FrameworkElement);

            if (element != null)
                return element.Tag as IDragDropHandler;

            return null;
        }

        private void _OnDragLeave(object sender, DragDropEventArgs e)
        {
            e.OperationType = OperationType.DropNotAllowed;
            e.Data = (e.DragSource as FrameworkElement).Tag;
        }

        private void _OnDragEnd(object sender, DragDropEventArgs e)
        {
            if (e.OperationType == OperationType.DropNotAllowed)
                return;

            var handler = GetHandler(e.DropTarget);

            if (handler == null)
                e.OperationType = OperationType.DropNotAllowed;
            else
                handler.CommitDrop(e);
        }

        private void _OnDragEnter(object sender, DragDropCancelEventArgs e)
        {
            var handler = GetHandler(e.DropTarget);

            if (handler == null)
                e.OperationType = OperationType.DropNotAllowed;
            else
                e.OperationType = handler.IsDropTarget(e, (sender as DragSource).DragChannels.ToArray()) ? OperationType.Move : OperationType.DropNotAllowed;
        }

        private void Macro_OnDragStart(object sender, DragDropStartEventArgs e)
        {
            if (!((e.DragSource as Border).Child as MacroNodeView).IsExpanded)
            {
                e.Cancel = true;
                ((e.DragSource as Border).Child as MacroNodeView).IsExpanded = true;
            }
        }

        private void _Interface_RemoveClick(object sender, RoutedEventArgs e)
        {
            Interface target = (sender as MenuItem).Tag as Interface;

            var prompt = JMessageBox.Show("Do you really want to delete Interface " + target.Name + "?", "Delete Interface", MessageBoxButton.YesNo);
            if (prompt == MessageBoxResult.No)
                return;

            PFProject.Instance.Interfaces.RemoveInterface(target);
        }

        private void _Interface_EditClick(object sender, RoutedEventArgs e)
        {
            Interface target = (sender as MenuItem).Tag as Interface;
        }

        private void _Macro_EditClick(object sender, RoutedEventArgs e)
        {}

        private void _Macro_RemoveClick(object sender, RoutedEventArgs e)
        {
            Macro target = (sender as MenuItem).Tag as Macro;

            var prompt = JMessageBox.Show("Do you really want to delete Macro " + target.Name + "?", "Delete Macro", MessageBoxButton.YesNo);
            if (prompt == MessageBoxResult.No)
                return;

            PFProject.Instance.Macros.RemoveMacro(target);
        }

        private void _Diagram_OpenClick(object sender, RoutedEventArgs e)
        {
            DiagramInfo target = (sender as MenuItem).Tag as DiagramInfo;

            WindowManager.CreateDocument<PFDiagramPage>(true, target.Name);
        }
    }
}
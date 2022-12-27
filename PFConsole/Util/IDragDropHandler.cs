using Infragistics.DragDrop;

namespace PFConsole.Util
{
    public interface IDragDropHandler
    {
        void CommitDrop(DragDropEventArgs e);
        bool IsDropTarget(DragDropEventArgs e, params string[] channel);
    }
}
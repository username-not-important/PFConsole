using PFConsole.Project.Compiler.Assets;

namespace PFConsole.Project.Compiler.Visitors
{
    interface IVisitor
    {
        string Accept(IAsset asset);
    }
}

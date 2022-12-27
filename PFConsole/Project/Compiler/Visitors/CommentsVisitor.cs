using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;

namespace PFConsole.Project.Compiler.Visitors
{
    class CommentsVisitor : IVisitor
    {
        public string Accept(Assets.IAsset asset)
        {
            var comment = asset as CommentAsset;

            return string.Format("\r\n{0}", comment.Comment);
        }
    }
}

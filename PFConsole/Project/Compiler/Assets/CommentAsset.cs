using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFConsole.Project.Compiler.Assets
{
    class CommentAsset : IAsset
    {
        public string Comment { get; set; }

        public CommentAsset(string comment)
        {
            Comment = comment;
        }
    }
}

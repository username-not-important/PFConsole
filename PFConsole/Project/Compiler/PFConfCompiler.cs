using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;
using PFConsole.Project.Compiler.Visitors;

namespace PFConsole.Project.Compiler
{
    public class PFConfCompiler
    {
        #region Singleton

        private static PFConfCompiler _instance;
        private static object _lock = true;

        public static PFConfCompiler Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ?? (_instance = new PFConfCompiler());
                }
            }
        }

        #endregion

        private AssetFactory factory;

        private PFConfCompiler()
        {
            factory = new AssetFactory();
        }

        public string Compile(PFProject project)
        {
            string result = "";

            var assets = factory.CreateAssets(project);

            foreach (var asset in assets)
            {
                var acc = Visitor.Accept(asset);
                if (acc != "")
                    result += string.Format(" {0}\r\n", acc);
            }

            return result;
        }

    }
}

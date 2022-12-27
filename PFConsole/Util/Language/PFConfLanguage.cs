
using System;
using System.Collections.Generic;
using System.IO;
using Infragistics.Documents.Parsing;
using Infragistics.Documents.Tagging;

namespace PFConsole.Util.Language
{
    #region PFConfLanguage

    [System.CodeDom.Compiler.GeneratedCode("Infragistics.Documents.Parsing.LanguageGenerator", "15.2.20152.1000")]
    public sealed partial class PFConfLanguage : global::Infragistics.Documents.Parsing.LanguageBase
    {
        #region Static Variables
        private static global::Infragistics.Documents.Parsing.Grammar _grammarInstance;
        private static PFConfLanguage _instance;
        private static object _syncLock = new object();
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new <see cref="PFConfLanguage"/> instance.
        /// </summary>
        public PFConfLanguage()
            : base(PFConfLanguage.GrammarInstance)
        {
        }
        #endregion

        #region Properties

        #region Instance
        /// <summary>
        /// Returns a static instance of the language (read-only)
        /// </summary>
        public static PFConfLanguage Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {

                            // Create a grammar from the EBNF script.
                            _grammarInstance = (Grammar.LoadEbnf(File.ReadAllText(Environment.CurrentDirectory + "\\PFConfLanguage.EBNF"))).Grammar;
                            _instance = new PFConfLanguage();
                        }
                    }
                }

                return _instance;
            }
        }
        #endregion

        #region GrammarInstance
        private static global::Infragistics.Documents.Parsing.Grammar GrammarInstance
        {
            get
            {
                return _grammarInstance;
            }
        }
        #endregion

        #endregion

    }
    #endregion

}
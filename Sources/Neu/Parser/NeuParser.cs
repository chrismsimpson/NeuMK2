//
//
//

using System;

using static System.IO.File;

namespace Neu
{
    public partial class NeuParser : Parser<NeuToken>
    {
        public NeuParser(
            NeuTokenizer tokenizer)
            : base(tokenizer) { }
    }

    ///
    /// Static
    ///

    public partial class NeuParser
    {
        public static NeuParser FromFile(
            String fullPath)
        {
            return new NeuParser(
                NeuTokenizer.FromFile(fullPath));
        }
    }

    ///
    
    public static partial class NeuParserHelpers
    {
        
        
    }
}
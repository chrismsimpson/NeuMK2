//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static bool PeekMemberAccess(
            this Tokenizer<NeuToken> tokenizer)
        {
            switch (tokenizer.Peek())
            {
                case NeuIdentifier _:
                    return true;

                ///

                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Period:
                    return true;

                ///

                default:
                    return false;
            }
        }
    }
}
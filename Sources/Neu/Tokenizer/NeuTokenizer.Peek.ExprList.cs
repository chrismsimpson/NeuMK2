//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static bool PeekExprListDelimiter(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Peek() is NeuToken t && IsExprListDelimiter(t))
            {
                return true;
            }

            return false;
        }
    }
}
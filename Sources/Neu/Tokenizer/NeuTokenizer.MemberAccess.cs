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
        // public static NeuToken TokenizeMemberAccess(
        //     this Tokenizer<NeuToken> tokenizer)
        // {
        //     if (tokenizer.Next() is NeuToken t && IsMemberAccess(t))
        //     {
        //         return t;
        //     }

        //     throw new Exception();
        // }

        // public static IEnumerable<NeuToken> TokenizeRawMemberAccessSequence(
        //     this Tokenizer<NeuToken> tokenizer)
        // {
        //     var tokens = new List<NeuToken>();

        //     ///

        //     while (tokenizer.PeekMemberAccess())
        //     {
        //         tokens.Add(tokenizer.TokenizeMemberAccess());
        //     }

        //     ///

        //     return tokens;
        // }
    }
}
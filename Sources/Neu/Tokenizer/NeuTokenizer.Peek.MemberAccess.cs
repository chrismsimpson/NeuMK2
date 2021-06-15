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
        // public static bool PeekMemberAccess(
        //     this Tokenizer<NeuToken> tokenizer,
        //     NeuIdentifier identifier)
        // {
        //     var c = tokenizer.Counter;

        //     ///

        //     var tokens = tokenizer.TokenizeRawMemberAccessTokens(identifier);

        //     ///

        //     tokenizer.Counter = c;

        //     return IsMemberAccess(tokens);
        // }

        // public static IEnumerable<NeuToken> TokenizeRawMemberAccessTokens(
        //     this Tokenizer<NeuToken> tokenizer,
        //     NeuIdentifier identifier)
        // {
        //     var expectPeriodNext = true;

        //     ///

        //     yield return identifier;

        //     ///

        //     while (!tokenizer.IsEof())
        //     {
        //         switch (tokenizer.Next())
        //         {
        //             case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Period && expectPeriodNext:

        //                 expectPeriodNext = false;

        //                 yield return p;

        //                 break;

        //             ///

        //             case NeuIdentifier i when !expectPeriodNext:

        //                 expectPeriodNext = true;

        //                 yield return i;

        //                 break;

        //             ///

        //             default:

        //                 yield break;
        //         }
        //     }
        // }

        // public static bool PeekMemberAccess(
        //     this Tokenizer<NeuToken> tokenizer,
        //     NeuToken previous)
        // {
        //     switch (tokenizer.Peek())
        //     {
        //         case NeuIdentifier _ when previous is NeuPunctuation p && p.PunctuationType == NeuPunctuationType.Period:
        //             return true;

        //         ///

        //         case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Period && previous is NeuIdentifier:
        //             return true;

        //         ///

        //         default:
        //             return false;
        //     }
        // }
    }
}
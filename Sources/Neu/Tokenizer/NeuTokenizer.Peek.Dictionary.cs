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
        public static bool PeekDictionary(
            this Tokenizer<NeuToken> tokenizer)
        {
            var counter = tokenizer.Counter;

            var retVal = false;

            var nestedParen = 0;

            var loop = true;

            ///

            while (loop)
            {
                if (tokenizer.IsEof())
                {
                    break;
                }

                ///

                switch (tokenizer.Next())
                {
                    case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.LeftParen:

                        nestedParen++;

                        break;

                    ///

                    case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.RightParen:

                        nestedParen--;

                        break;

                    ///

                    case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Colon && nestedParen == 0:

                        retVal = true;

                        loop = false;

                        break;
                    
                    ///

                    case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Arrow:

                        retVal = false;

                        loop = false;

                        break;

                    ///

                    case NeuKeyword k when k.KeywordType == NeuKeywordType.In:

                        retVal = false;

                        loop = false;

                        break;

                    ///

                    default:

                        break;
                }
            }

            ///

            tokenizer.Counter = counter;

            ///

            return retVal;
        }
    }
}
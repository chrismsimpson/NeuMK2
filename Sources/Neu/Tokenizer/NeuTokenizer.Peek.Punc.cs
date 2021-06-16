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
        public static bool PeekPunctuation(
            this Tokenizer<NeuToken> tokenizer,
            params NeuPunctuationType[] punctuationTypes)
        {
            if (tokenizer.Peek() is NeuPunctuation p && punctuationTypes.Contains(p.PunctuationType))
            {
                return true;
            }

            return false;
        }

        ///

        public static bool PeekLeftBrace(
            this Tokenizer<NeuToken> tokenizer)
        {       
            return tokenizer.PeekPunctuation(NeuPunctuationType.LeftBrace);
        }   

        public static bool PeekRightBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.RightBrace);
        }

        public static bool PeekLeftParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.LeftParen);
        }

        public static bool PeekRightParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.RightParen);
        }

        public static bool PeekSemicolon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.Semicolon);
        }

        public static bool PeekColon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.Colon);
        }

        public static bool PeekComma(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.Comma);
        }

        public static bool PeekCommaOrRightParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.Comma, NeuPunctuationType.RightParen);
        }

        public static bool PeekArrow(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.Arrow);
        }

        public static bool PeekPeriod(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.Period);
        }

        public static bool PeekSemicolonOrRightBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekPunctuation(NeuPunctuationType.Semicolon, NeuPunctuationType.RightBrace);
        }



        public static bool PeekClosure(
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

                        retVal = false;

                        loop = false;

                        break;

                    ///

                    case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Arrow:

                        retVal = true;

                        loop = false;

                        break;

                    ///

                    case NeuKeyword k when k.KeywordType == NeuKeywordType.In:

                        retVal = true;

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
//
//
//

using System;
using System.Linq;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static bool PeekPunctuation(
            this NeuParser parser,
            params NeuPunctuationType[] punctuationTypes)
        {
            if (parser.Tokenizer.Peek() is NeuPunctuation p && punctuationTypes.Contains(p.PunctuationType))
            {
                return true;
            }

            return false;
        }

        ///

        public static bool PeekLeftBrace(
            this NeuParser parser)
        {       
            return parser.PeekPunctuation(NeuPunctuationType.LeftBrace);
        }   

        public static bool PeekRightBrace(
            this NeuParser parser)
        {
            return parser.PeekPunctuation(NeuPunctuationType.RightBrace);
        }

        public static bool PeekLeftParen(
            this NeuParser parser)
        {
            return parser.PeekPunctuation(NeuPunctuationType.LeftParen);
        }

        public static bool PeekRightParen(
            this NeuParser parser)
        {
            return parser.PeekPunctuation(NeuPunctuationType.RightParen);
        }

        public static bool PeekSemicolon(
            this NeuParser parser)
        {
            return parser.PeekPunctuation(NeuPunctuationType.Semicolon);
        }

        public static bool PeekComma(
            this NeuParser parser)
        {
            return parser.PeekPunctuation(NeuPunctuationType.Comma);
        }

        public static bool PeekCommaOrRightParen(
            this NeuParser parser)
        {
            return parser.PeekPunctuation(NeuPunctuationType.Comma, NeuPunctuationType.RightParen);
        }

        public static bool PeekArrow(
            this NeuParser parser)
        {
            return parser.PeekPunctuation(NeuPunctuationType.Arrow);
        }


    }
}
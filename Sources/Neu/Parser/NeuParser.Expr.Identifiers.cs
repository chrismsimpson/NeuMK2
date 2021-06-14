//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuExpression ParseIdentifier(
            this NeuParser parser,
            NeuIdentifier identifier)
        {
            switch (parser.Tokenizer.Peek())
            {
                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.LeftParen:

                    // function call

                    throw new Exception();

                ///

                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Equal:

                    // assignment

                    throw new Exception();

                ///

                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Period:

                    // member access

                    return parser.ParseMemberAccess(identifier);

                ///
                
                default:

                    throw new Exception();
            }
        }
    }
}
//
//
//

using System;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuAssignmentExpr ParseAssignmentExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuPunctuation punc)
        {
            if (punc.PunctuationType != NeuPunctuationType.Equal)
            {
                throw new Exception();
            }

            ///

            return new NeuAssignmentExpr(
                children: new Node[] { punc },
                start: start,
                end: parser.Position());
        }
    }
}
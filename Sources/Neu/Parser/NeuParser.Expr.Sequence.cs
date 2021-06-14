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
        public static NeuSequenceExpr ParseSequenceExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token,
            bool escapeOnNewline,
            params NeuPunctuationType[] delimiters)
        {
            var children = new List<Node>();

            ///

            var exprList = parser.ParseExprList(start, modifiers, token, escapeOnNewline, delimiters);

            ///

            children.Add(exprList);

            ///

            return new NeuSequenceExpr(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
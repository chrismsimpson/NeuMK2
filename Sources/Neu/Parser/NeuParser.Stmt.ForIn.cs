//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuForInStatement ParseForInStatement(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            var idPattern = parser.ParseIdentifierPattern();

            children.Add(idPattern);

            ///

            var inKeyword = parser.Tokenizer.TokenizeIn();

            children.Add(inKeyword);

            ///

            var idExpr = parser.ParseIdentifierExpr();

            children.Add(idExpr);

            ///

            if (parser.Tokenizer.PeekWhere())
            {
                var whereClause = parser.ParseWhereClause();

                children.Add(whereClause);
            }

            ///

            var codeBlock = parser.ParseCodeBlock();

            if (codeBlock == null)
            {
                throw new Exception();
            }

            children.Add(codeBlock);

            ///

            return new NeuForInStatement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
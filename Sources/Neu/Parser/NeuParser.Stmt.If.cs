//
//
//

using System;
using System.Collections.Generic;

using static System.Array;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuIfStatement ParseIfStatement(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var token = parser.Tokenizer.Next();

            if (token == null)
            {
                throw new Exception();
            }

            ///

            return parser.ParseIfStatement(start, Empty<NeuToken>(), token);
        }

        public static NeuIfStatement ParseIfStatement(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            foreach (var modifier in modifiers)
            {
                children.Add(modifier);
            }

            ///

            children.Add(token);

            ///

            var conditionElementList = parser.ParseConditionElementList();

            children.Add(conditionElementList);

            ///

            var ifCodeBlock = parser.ParseCodeBlock();

            children.Add(ifCodeBlock);

            ///

            if (parser.Tokenizer.PeekElse())
            {
                var elseKeyword = parser.Tokenizer.TokenizeElse();

                children.Add(elseKeyword);

                ///

                if (parser.Tokenizer.PeekIf())
                {
                    var nestedIfStmt = parser.ParseIfStatement();

                    children.Add(nestedIfStmt);
                }
                else
                {
                    var elseCodeBlock = parser.ParseCodeBlock();

                    children.Add(elseCodeBlock);
                }
            }

            ///

            return new NeuIfStatement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
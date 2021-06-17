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
        public static NeuGuardStatement ParseGuardStatement(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            if (!IsGuardKeyword(token))
            {
                throw new Exception();
            }

            children.Add(token);

            ///

            var conditionElementList = parser.ParseConditionElementList();

            children.Add(conditionElementList);

            ///

            var elseKeyword = parser.Tokenizer.TokenizeElse();

            children.Add(elseKeyword);

            ///

            var codeBlock = parser.ParseCodeBlock();

            children.Add(codeBlock);

            ///

            return new NeuGuardStatement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuWhileStatement ParseWhileStatement(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            children.Add(token);

            ///

            var conditionElementList = parser.ParseConditionElementList();

            children.Add(conditionElementList);

            ///

            var codeBlock = parser.ParseCodeBlock();

            children.Add(codeBlock);

            ///

            return new NeuWhileStatement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
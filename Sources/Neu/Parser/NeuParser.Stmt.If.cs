//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuIfStatement ParseIfStatement(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token,
            IEnumerable<NeuToken> modifiers)
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

            // var conditionElementList = 

            throw new Exception();
        }
    }
}
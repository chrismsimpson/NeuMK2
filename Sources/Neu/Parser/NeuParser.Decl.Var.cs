//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuVariableDecl ParseVariableDecl(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            if (modifiers.Count() > 0)
            {
                var modifierList = parser.ParseModifierList(modifiers);

                children.Add(modifierList);
            }

            ///

            if (!IsVarDeclKeyword(token))
            {
                throw new Exception();
            }

            children.Add(token);

            ///

            var patternBindingList = parser.ParsePatternBindingList();

            children.Add(patternBindingList);

            ///

            return new NeuVariableDecl(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
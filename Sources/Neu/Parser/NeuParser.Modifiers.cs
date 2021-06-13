//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static Neu.NeuKeyword;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuModifierList ParseModifierList(
            this NeuParser parser,
            IEnumerable<NeuToken> modifiers)
        {
            var start = modifiers.Start();

            ///

            var children = parser.ParseModifiers(modifiers);

            ///

            var end = modifiers.End();

            ///

            return new NeuModifierList(
                children: children,
                start: start,
                end: end);
        }

        public static IEnumerable<Node> ParseModifiers(
            this NeuParser parser,
            IEnumerable<NeuToken> modifiers)
        {
            var declModifiers = new List<Node>();

            ///

            foreach (var modifier in modifiers)
            {
                switch (modifier)
                {
                    case NeuKeyword keyword when IsDeclModifier(keyword.KeywordType):

                        declModifiers.Add(new NeuDeclModifier(keyword));

                        break;

                    ///

                    default:

                        throw new Exception();
                }
            }

            ///

            return declModifiers;
        }
    }
}
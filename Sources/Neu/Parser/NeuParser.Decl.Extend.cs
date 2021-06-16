//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuExtendDecl ParseExtendDecl(
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

            children.Add(token);

            ///

            var typeId = parser.ParseTypeIdentifier();

            children.Add(typeId);

            ///

            var memberDeclList = parser.ParseMemberDeclList();

            children.Add(memberDeclList);

            ///

            return new NeuExtendDecl(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
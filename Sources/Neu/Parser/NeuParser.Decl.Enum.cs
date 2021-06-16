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
        public static NeuEnumDecl ParseEnumDecl(
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

            var identifier = parser.Tokenizer.TokenizeIdentifier();

            children.Add(identifier);

            ///

            if (parser.Tokenizer.PeekColon())
            {
                var typeAlignClause = parser.ParseTypeAlignClause();

                children.Add(typeAlignClause);
            }

            ///

            var memberDeclBlock = parser.ParseMemberDeclBlock();

            children.Add(memberDeclBlock);

            ///

            return new NeuEnumDecl(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
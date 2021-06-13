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
        public static NeuFuncDecl ParseFunctionDeclaration(
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

            var signature = parser.ParseFunctionSignature();

            children.Add(signature);

            ///

            var codeBlock = parser.ParseCodeBlock();

            children.Add(codeBlock);

            ///

            return new NeuFuncDecl(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuFunctionSignature ParseFunctionSignature(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var paramClause = parser.ParseParameterClause();

            children.Add(paramClause);

            ///

            if (parser.Tokenizer.PeekArrow())
            {
                var returnClause = parser.ParseReturnClause();

                children.Add(returnClause);
            }

            ///

            return new NeuFunctionSignature(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
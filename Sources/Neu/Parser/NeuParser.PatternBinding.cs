//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuPatternBindingList ParsePatternBindingList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var patternBindings = parser.ParsePatternBindings();

            ///

            return new NeuPatternBindingList(
                children: patternBindings,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuPatternBinding> ParsePatternBindings(
            this NeuParser parser)
        {
            var patternBindings = new List<NeuPatternBinding>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekSemicolonOrRightBrace())
                {
                    break;
                }

                ///

                var patternBinding = parser.ParsePatternBinding();

                patternBindings.Add(patternBinding);
            }

            ///

            return patternBindings;
        }

        public static NeuPatternBinding ParsePatternBinding(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var idPattern = parser.ParseIdentifierPattern();

            children.Add(idPattern);

            ///

            if (parser.Tokenizer.PeekColon())
            {
                var typeAnnotation = parser.ParseTypeAnnotation();

                children.Add(typeAnnotation);
            }

            ///

            if (parser.Tokenizer.PeekEqual())
            {
                var initClause = parser.ParseInitClause();

                children.Add(initClause);
            }

            ///

            if (parser.Tokenizer.PeekComma())
            {
                var comma = parser.Tokenizer.TokenizeComma();

                children.Add(comma);
            }

            ///

            return new NeuPatternBinding(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
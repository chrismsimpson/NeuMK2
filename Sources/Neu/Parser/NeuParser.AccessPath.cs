//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuAccessPath ParseAccessPath(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var components = parser.ParseAccessPathComponents();

            ///

            return new NeuAccessPath(
                children: components,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuAccessPathComponent> ParseAccessPathComponents(
            this NeuParser parser)
        {
            var components = new List<NeuAccessPathComponent>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PreviousContainsNewline())
                {
                    break;
                }

                ///

                var component = parser.ParseAccessPathComponent();

                components.Add(component);
            }

            ///

            return components;
        }

        public static NeuAccessPathComponent ParseAccessPathComponent(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var id = parser.Tokenizer.TokenizeIdentifier();

            children.Add(id);

            ///

            if (parser.Tokenizer.PeekPeriod())
            {
                var period = parser.Tokenizer.TokenizePeriod();

                children.Add(period);
            }

            ///

            return new NeuAccessPathComponent(
                children: children,
                start: start,
                end: parser.Position());
        }
         
    }
}
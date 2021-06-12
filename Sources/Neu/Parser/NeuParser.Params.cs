//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuParameterClause ParseParameterClause(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var leftParen = parser.Tokenizer.TokenizeLeftBrace();

            children.Add(leftParen);

            ///

            var paramList = parser.ParseFuncParamList();

            children.Add(paramList);

            ///

            var rightParen = parser.Tokenizer.TokenizeRightParen();

            children.Add(rightParen);

            ///

            return new NeuParameterClause(
                children: children,
                start: start,
                end: parser.Position());
        }
        
        public static NeuFuncParamList ParseFuncParamList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var parameters = parser.ParseFuncParams();

            ///

            return new NeuFuncParamList(
                children: parameters,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuFuncParam> ParseFuncParams(
            this NeuParser parser)
        {
            var parameters = new List<NeuFuncParam>();

            ///

            while (!parser.IsEof())
            {
                if (parser.PeekRightParen())
                {
                    break;
                }

                ///

                var param = parser.ParseFuncParam();

                parameters.Add(param);
            }

            ///

            return parameters;
        }

        public static NeuFuncParam ParseFuncParam(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var name = parser.Tokenizer.TokenizeIdentifier();

            children.Add(name);

            ///

            var colon = parser.Tokenizer.TokenizeColon();

            children.Add(colon);

            ///

            if (parser.PeekComma())
            {
                var comma = parser.Tokenizer.TokenizeComma();

                children.Add(comma);
            }

            ///

            return new NeuFuncParam(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
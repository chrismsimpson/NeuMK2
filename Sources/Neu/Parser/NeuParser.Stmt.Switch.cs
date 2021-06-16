//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuSwitchStatement ParseSwitchStatement(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            children.Add(token);

            ///

            var condExpr = parser.ParseConditionExpression();

            children.Add(condExpr);

            ///

            var leftBrace = parser.Tokenizer.TokenizeLeftBrace();

            children.Add(leftBrace);

            ///

            var list = parser.ParseSwitchCaseList();

            children.Add(list);

            ///

            var rightBrace = parser.Tokenizer.TokenizeRightBrace();

            children.Add(rightBrace);

            ///

            return new NeuSwitchStatement(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuSwitchCaseList ParseSwitchCaseList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var cases = parser.ParseSwitchCases();

            ///

            return new NeuSwitchCaseList(
                children: cases,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuSwitchCase> ParseSwitchCases(
            this NeuParser parser)
        {
            var cases = new List<NeuSwitchCase>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightBrace())
                {
                    break;
                }

                ///

                var switchCase = parser.ParseSwitchCase();

                cases.Add(switchCase);
            }

            ///

            return cases;
        }

        public static NeuSwitchCase ParseSwitchCase(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var caseLabel = parser.ParseSwitchCaseLabel();

            children.Add(caseLabel);

            ///

            var codeBlockItemList = parser.ParseCodeBlockItemList();

            children.Add(codeBlockItemList);

            ///

            return new NeuSwitchCase(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuSwitchCaseLabel ParseSwitchCaseLabel(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var caseKeyword = parser.Tokenizer.TokenizeCase();

            children.Add(caseKeyword);

            ///

            var caseItemList = parser.ParseCaseItemList();

            children.Add(caseItemList);

            ///

            var colon = parser.Tokenizer.TokenizeColon();

            children.Add(colon);
            
            ///

            return new NeuSwitchCaseLabel(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuCaseItemList ParseCaseItemList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var items = parser.ParseCaseItems();

            ///

            return new NeuCaseItemList(
                children: items,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuCaseItem> ParseCaseItems(
            this NeuParser parser)
        {
            var items = new List<NeuCaseItem>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightBrace())
                {
                    throw new Exception();
                }

                ///

                var caseItem = parser.ParseCaseItem();

                ///

                if (parser.Tokenizer.PeekColon())
                {
                    break;
                }
            }

            ///

            return items;
        }

        public static NeuCaseItem ParseCaseItem(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var exprPattern = parser.ParseExpressionPattern();

            children.Add(exprPattern);

            ///

            if (parser.Tokenizer.PeekComma())
            {
                var comma = parser.Tokenizer.TokenizeComma();

                children.Add(comma);
            }

            ///

            return new NeuCaseItem(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Char;
using static System.IO.File;
using static System.String;

using static Neu.NeuTokenizer;

namespace Neu
{
    public partial class NeuTokenizer : Tokenizer<NeuToken>
    {
        public NeuTokenizer(
            Scanner scanner)
            : base(scanner) { }
    }

    ///

    public partial class NeuTokenizer
    {
        public static NeuTokenizer FromFile(
            String file)
        {
            var contents = ReadAllText(file);

            return new NeuTokenizer(
                new Scanner(contents));
        }

        ///

        public static bool IsFloatLiteral(
            String source)
        {
            if (IsNullOrWhiteSpace(source))
            {
                return false;
            }

            ///

            foreach (var c in source)
            {
                if (!IsNumberLiteralPart(c))
                {
                    return false;
                }
            }

            ///

            return true;
        }

        public static bool IsIntegerLiteral(
            String source)
        {
            if (IsNullOrWhiteSpace(source))
            {
                return false;
            }

            ///

            foreach (var c in source)
            {
                if (!IsIntegerLiteralPart(c))
                {
                    return false;
                }
            }
        
            ///

            return true;
        }

        ///

        public static bool IsIdentifierPart(
            Char c)
        {
            return IsLetter(c) || IsNumber(c) || c == '_';
        }

        public static bool IsIdentifierStart(
            Char c)
        {
            return IsLetter(c) || c == '_';
        }

        ///

        public static bool IsIntegerLiteralPart(
            Char c)
        {
            return c == '-' || c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9';
        }

        ///

        public static bool IsNumberLiteralPart(
            Char c)
        {
            return c == '-' || c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '.';
        }
        
        ///

        public static bool IsBinaryOperator(
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                case NeuPunctuationType.LessThan:
                    return true;

                ///

                case NeuPunctuationType.GreaterThan:
                    return true;

                ///

                default:
                    return false;
            }
        }

        ///

        public static NeuBinaryOperatorType? ToBinaryOperatorType(
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                case NeuPunctuationType.LessThan:
                    return NeuBinaryOperatorType.LessThan;

                ///

                case NeuPunctuationType.GreaterThan:
                    return NeuBinaryOperatorType.GreaterThan;

                ///

                default:
                    return null;
            }
        }

        public static bool IsOptionalBindingKeyword(
            NeuKeyword keyword)
        {
            switch (keyword.KeywordType)
            {
                case NeuKeywordType.Let:
                case NeuKeywordType.Var:

                    return true;

                ///

                default:

                    return false;
            }
        }

        public static bool IsBooleanLiteral(
            NeuKeyword keyword)
        {
            switch (keyword.KeywordType)
            {
                case NeuKeywordType.True:
                case NeuKeywordType.False:

                    return true;

                ///

                default:

                    return false;
            }
        }

        public static bool IsUsingDecl(
            NeuKeyword keyword)
        {
            switch (keyword.KeywordType)
            {
                case NeuKeywordType.Func:

                    return true;

                ///

                default:

                    return false;
            }
        }

        public static bool IsStatementModifier(
            NeuKeyword keyword)
        {
            switch (keyword.KeywordType)
            {
                /// Access modifiers

                case NeuKeywordType.Public:
                case NeuKeywordType.Private:
                case NeuKeywordType.Internal:

                    return true;

                /// Concurrency modifiers

                // case NeuKeywordType.Async:
                // case NeuKeywordType.Await:

                //     return true;

                ///
                
                default: 

                    return false;
            }
        }
    }

    ///

    public static partial class NeuTokenizerHelpers
    {
        

        public static NeuToken? Next(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                var token = tokenizer.Tokens.ElementAt(tokenizer.Counter);

                tokenizer.Counter++;

                return token;
            }

            ///

            if (tokenizer.Scanner.IsEof())
            {
                return null;
            }

            ///

            var next = tokenizer.RawNext();

            tokenizer.Tokens.Add(next);

            tokenizer.Counter++;

            return next;
        }

        ///

        private static NeuToken RawNext(
            this Tokenizer<NeuToken> tokenizer)
        {
            var nextChar = tokenizer.Scanner.RawNext();

            ///

            switch (nextChar)
            {
                /// Comments

                case '/' when tokenizer.Scanner.Peek(equals: '/'):
                    return tokenizer.RawTokenizeLineEndComment();

                case '/' when tokenizer.Scanner.Peek(equals: '*'):
                    return tokenizer.RawTokenizeInlineComment();

                /// Pre-Operator Punctuation

                case '-' when tokenizer.Scanner.Peek(equals: '>'):
                    return tokenizer.RawTokenizeArrow();

                /// Postfix Operators


                /// Prefix Operators


                /// Infix Operators


                /// Binary Operators

                case '=' when tokenizer.Scanner.Peek(equals: '='):
                    return tokenizer.RawTokenizeEqualTo();

                case '+' when tokenizer.Scanner.Peek(equals: '='):
                    return tokenizer.RawTokenizeIncrementInto();

                case '+':
                    return tokenizer.RawTokenizePlus();

                case '-' when tokenizer.Scanner.Peek(equals: '='):
                    return tokenizer.RawTokenizeDecrementInto();

                case '-':
                    return tokenizer.RawTokenizeMinus();

                case '<' when tokenizer.Scanner.Peek(equals: '='):
                    return tokenizer.RawTokenizeLessThanOrEqualTo();

                case '>' when tokenizer.Scanner.Peek(equals: '='):
                    return tokenizer.RawTokenizeGreaterThanOrEqualTo();

                /// Punctuation

                case '(':
                    return tokenizer.RawTokenizeLeftParen();

                case ')':
                    return tokenizer.RawTokenizeRightParen();

                case '{':
                    return tokenizer.RawTokenizeLeftBrace();

                case '}':
                    return tokenizer.RawTokenizeRightBrace();

                case '[':
                    return tokenizer.RawTokenizeLeftBracket();

                case ']':
                    return tokenizer.RawTokenizeRightBracket();

                case ':':
                    return tokenizer.RawTokenizeColon();

                case ';':
                    return tokenizer.RawTokenizeSemicolon();

                case '.':
                    return tokenizer.RawTokenizePeriod();

                case ',':
                    return tokenizer.RawTokenizeComma();

                case '<':
                    return tokenizer.RawTokenizeLessThan();

                case '>':
                    return tokenizer.RawTokenizeGreaterThan();

                case '=':
                    return tokenizer.RawTokenizeEqual();


                /// Keywords

                case 'b' when tokenizer.Scanner.PeekThenDelimiter(equals: "reak", delimitedBy: c => IsWhiteSpace(c) || c == ';'):
                    return tokenizer.RawTokenizeBreak();

                case 'c' when tokenizer.Scanner.PeekThenWhitespace(equals: "ase"):
                    return tokenizer.RawTokenizeCase();

                case 'c' when tokenizer.Scanner.PeekThenDelimiter(equals: "ontinue", delimitedBy: c => IsWhiteSpace(c) || c == ';'):
                    return tokenizer.RawTokenizeContinue();

                case 'e' when tokenizer.Scanner.PeekThenDelimiter(equals: "lse", delimitedBy: c => IsWhiteSpace(c) || c == '{'):
                    return tokenizer.RawTokenizeElse();

                case 'e' when tokenizer.Scanner.PeekThenWhitespace(equals: "num"):
                    return tokenizer.RawTokenizeEnum();

                case 'f' when tokenizer.Scanner.PeekThenDelimiter(equals: "alse", delimitedBy: c => IsWhiteSpace(c) || c == ')' || c == ',' || c == ':'):
                    return tokenizer.RawTokenizeFalse();

                case 'f' when tokenizer.Scanner.PeekThenDelimiter(equals: "or", delimitedBy: c => IsWhiteSpace(c) || c == '(' || c == '_'):
                    return tokenizer.RawTokenizeFor();

                case 'f' when tokenizer.Scanner.PeekThenWhitespace(equals: "unc"):
                    return tokenizer.RawTokenizeFunc();

                case 'i' when tokenizer.Scanner.PeekThenDelimiter(equals: "f", delimitedBy: c => IsWhiteSpace(c) || c == '('):
                    return tokenizer.RawTokenizeIf();

                case 'i' when tokenizer.Scanner.PeekThenDelimiter(equals: "n", delimitedBy: c => IsWhiteSpace(c) || c == '(' || c == '.'):
                    return tokenizer.RawTokenizeIn();

                case 'i' when tokenizer.Scanner.PeekThenWhitespace(equals: "nterface"):
                    return tokenizer.RawTokenizeInterface();


                
                case 'p' when tokenizer.Scanner.PeekThenWhitespace(equals: "rivate"):
                    return tokenizer.RawTokenizePrivate();

                case 's' when tokenizer.Scanner.PeekThenWhitespace(equals: "truct"):
                    return tokenizer.RawTokenizeStruct();

                case 's' when tokenizer.Scanner.PeekThenDelimiter(equals: "witch", delimitedBy: c => IsWhiteSpace(c) || c == '('):
                    return tokenizer.RawTokenizeSwitch();

                case 't' when tokenizer.Scanner.PeekThenDelimiter(equals: "rue", delimitedBy: c => IsWhiteSpace(c) || c == ')' || c == ',' || c == ':'):
                    return tokenizer.RawTokenizeTrue();

                case 'u' when tokenizer.Scanner.PeekThenWhitespace(equals: "sing"):
                    return tokenizer.RawTokenizeUsing();

                case 'w' when tokenizer.Scanner.PeekThenDelimiter(equals: "hile", delimitedBy: c => IsWhiteSpace(c) || c == '('):
                    return tokenizer.RawTokenizeWhile();

                case 'w' when tokenizer.Scanner.PeekThenDelimiter(equals: "here", delimitedBy: c => IsWhiteSpace(c) || c == '('):
                    return tokenizer.RawTokenizeWhere();


                /// Identifiers

                case Char c when IsIdentifierStart(c):
                    return tokenizer.RawTokenizeIdentifier();

                /// Literals

                case Char c when IsNumberLiteralPart(c):
                    return tokenizer.RawTokenizeNumberLiteral(c);

                

                ///

                case var _:
                    throw new Exception(); // tokenize string segment?
            }
        }

        ///

        public static IEnumerable<NeuToken> TokenizeUntil(
            this Tokenizer<NeuToken> tokenizer,
            bool escapeOnNewline,
            Func<NeuToken, bool> test)
        {
            var tokens = new List<NeuToken>();

            ///

            while (tokenizer.Next() is NeuToken t)
            {
                if (test(t))
                {
                    tokenizer.Rewind();

                    break;
                }

                ///

                tokens.Add(t);
                
                ///

                if (t.Source.Contains('\n') && escapeOnNewline)
                {
                    break;
                }
            }

            ///

            return tokens;
        }

        ///

        public static IEnumerable<NeuToken> TokenizeUntil(
            this Tokenizer<NeuToken> tokenizer,
            bool escapeOnNewline,
            params NeuPunctuationType[] delimiters)
        {
            return tokenizer.TokenizeUntil(escapeOnNewline, t => t is NeuPunctuation p && delimiters.Contains(p.PunctuationType));
        }

        ///

        public static void Rewind(
            this Tokenizer<NeuToken> tokenizer)
        {
            tokenizer.Counter--;
        }

        ///

        public static IEnumerable<NeuToken> Tokenize(
            this Tokenizer<NeuToken> tokenizer,
            NeuToken token,
            IEnumerable<NeuToken> modifiers,
            params NeuPunctuationType[] delimiters)
        {
            var tokens = new List<NeuToken>();

            ///

            foreach (var modifier in modifiers)
            {
                tokens.Add(modifier);
            }

            ///

            tokens.Add(token);

            ///

            foreach (var t in tokenizer.TokenizeUntil(escapeOnNewline: true, delimiters))
            {
                tokens.Add(t);
            }

            ///

            return tokens;
        }
    }
}
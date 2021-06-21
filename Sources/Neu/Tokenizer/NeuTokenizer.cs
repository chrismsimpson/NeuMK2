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

        public static bool IsModifier(
            NeuToken token)
        {
            switch (token)
            {
                case NeuKeyword k:
                    return IsModifier(k);

                ///

                default:
                    return false;
            }
        }

        public static bool IsModifier(
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

        ///

        public static bool IsExprListDelimiter(
            NeuToken token)
        {
            switch (token)
            {
                case NeuPunctuation p:
                    return IsExprListDelimiter(p);

                ///

                default:
                    return false;
            }
        }
        

        public static bool IsExprListDelimiter(
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                case NeuPunctuationType.Semicolon:
                case NeuPunctuationType.Comma:
                case NeuPunctuationType.RightBrace: // TODO: check this?

                    return true;

                ///

                default:

                    return false;
            }
        }

        ///
        
        public static bool IsTupleExprElementDelimiter(
            NeuToken token)
        {
            switch (token)
            {
                case NeuPunctuation p:
                    return IsTupleExprElementDelimiter(p);

                ///

                default:
                    return false;
            }
        }


        public static bool IsTupleExprElementDelimiter(
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                case NeuPunctuationType.Comma:
                case NeuPunctuationType.RightParen:
                    return true;

                ///
                
                default:
                    return false;
            }
        }

        public static bool IsExprDelimiter(
            NeuToken token)
        {
            switch (token)
            {
                case NeuPunctuation p:
                    return IsExprDelimiter(p);

                ///
                
                default:
                    return false;
            }
        }

        public static bool IsExprDelimiter(
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                case NeuPunctuationType.Comma:
                case NeuPunctuationType.RightParen:
                case NeuPunctuationType.Semicolon:
                case NeuPunctuationType.Colon: // this one is questionable
                    return true;

                ///

                default:
                    return false;
            }
        }

        ///

        public static bool IsTypeIdDelimiter(
            NeuToken token)
        {
            switch (token)
            {
                case NeuPunctuation p:
                    return IsTypeIdDelimiter(p);

                ///

                default:
                    return false;
            }
        }

        public static bool IsTypeIdDelimiter(
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                case NeuPunctuationType.Comma:
                case NeuPunctuationType.LeftBrace:
                    return true;

                ///

                default:
                    return false;
            }
        }

        ///


        public static bool IsUsingTypeKeyword(
            NeuToken token)
        {
            switch (token)
            {
                case NeuKeyword k:
                    return IsUsingTypeKeyword(k);

                ///

                default:
                    return false;
            }
        }

        public static bool IsUsingTypeKeyword(
            NeuKeyword keyword)
        {
            switch (keyword.KeywordType)
            {
                case NeuKeywordType.Func:
                case NeuKeywordType.Alias:
                case NeuKeywordType.Struct:
                case NeuKeywordType.Enum:
                    return true;

                ///

                default:
                    return false;
            }
        }

        ///

        public static bool IsVarDeclKeyword(
            NeuToken token)
        {
            switch (token)
            {
                case NeuKeyword k:
                    return IsVarDeclKeyword(k);

                default:
                    return false;
            }
        }

        public static bool IsVarDeclKeyword(
            NeuKeyword keyword)
        {
            switch (keyword.KeywordType)
            {
                case NeuKeywordType.Var:
                case NeuKeywordType.Let:
                    return true;

                ///

                default:
                    return false;
            }
        }

        ///

        public static bool IsInitKeyword(
            NeuToken token)
        {
            switch (token)
            {
                case NeuKeyword k:
                    return IsInitKeyword(k);
                
                ///

                default:
                    return false;
            }
        }

        public static bool IsInitKeyword(
            NeuKeyword keyword)
        {
            return keyword.KeywordType == NeuKeywordType.Init;
        }

        ///

        public static bool IsGuardKeyword(
            NeuToken token)
        {
            switch (token)
            {
                case NeuKeyword k:
                    return IsGuardKeyword(k);
                
                ///

                default:
                    return false;
            }
        }

        public static bool IsGuardKeyword(
            NeuKeyword keyword)
        {
            return keyword.KeywordType == NeuKeywordType.Guard;
        }

        ///

        public static bool IsLetKeyword(
            NeuToken token)
        {
            switch (token)
            {
                case NeuKeyword k:
                    return IsLetKeyword(k);
                
                ///

                default:
                    return false;
            }
        }

        public static bool IsLetKeyword(
            NeuKeyword keyword)
        {
            return keyword.KeywordType == NeuKeywordType.Let;
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

                case 'e' when tokenizer.Scanner.PeekThenWhitespace(equals: "xtend"):
                    return tokenizer.RawTokenizeExtend();

                case 'f' when tokenizer.Scanner.PeekThenDelimiter(equals: "alse", delimitedBy: c => IsWhiteSpace(c) || c == ')' || c == ',' || c == ':'):
                    return tokenizer.RawTokenizeFalse();

                case 'f' when tokenizer.Scanner.PeekThenDelimiter(equals: "or", delimitedBy: c => IsWhiteSpace(c) || c == '(' || c == '_'):
                    return tokenizer.RawTokenizeFor();

                case 'f' when tokenizer.Scanner.PeekThenWhitespace(equals: "unc"):
                    return tokenizer.RawTokenizeFunc();

                case 'g' when tokenizer.Scanner.PeekThenWhitespace(equals: "uard"):
                    return tokenizer.RawTokenizeGuard();

                case 'i' when tokenizer.Scanner.PeekThenDelimiter(equals: "f", delimitedBy: c => IsWhiteSpace(c) || c == '('):
                    return tokenizer.RawTokenizeIf();

                case 'i' when tokenizer.Scanner.PeekThenDelimiter(equals: "n", delimitedBy: c => IsWhiteSpace(c) || c == '(' || c == '.'):
                    return tokenizer.RawTokenizeIn();

                case 'i' when tokenizer.Scanner.PeekThenDelimiter(equals: "nit", delimitedBy: c => IsWhiteSpace(c) || c == '('):
                    return tokenizer.RawTokenizeInit();

                case 'i' when tokenizer.Scanner.PeekThenWhitespace(equals: "nterface"):
                    return tokenizer.RawTokenizeInterface();

                case 'l' when tokenizer.Scanner.PeekThenWhitespace(equals: "et"):
                    return tokenizer.RawTokenizeLet();


                
                case 'p' when tokenizer.Scanner.PeekThenWhitespace(equals: "rivate"):
                    return tokenizer.RawTokenizePrivate();

                case 'r' when tokenizer.Scanner.PeekThenDelimiter(equals: "eturn", delimitedBy: c => IsWhiteSpace(c) || c == ';' || c == '}'):
                    return tokenizer.RawTokenizeReturn();

                case 's' when tokenizer.Scanner.PeekThenWhitespace(equals: "truct"):
                    return tokenizer.RawTokenizeStruct();

                case 's' when tokenizer.Scanner.PeekThenDelimiter(equals: "witch", delimitedBy: c => IsWhiteSpace(c) || c == '('):
                    return tokenizer.RawTokenizeSwitch();

                case 't' when tokenizer.Scanner.PeekThenDelimiter(equals: "rue", delimitedBy: c => IsWhiteSpace(c) || c == ')' || c == ',' || c == ':'):
                    return tokenizer.RawTokenizeTrue();

                case 'u' when tokenizer.Scanner.PeekThenWhitespace(equals: "sing"):
                    return tokenizer.RawTokenizeUsing();

                case 'v' when tokenizer.Scanner.PeekThenWhitespace(equals: "ar"):
                    return tokenizer.RawTokenizeVar();

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
            bool escapeOnNewline,
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

            foreach (var t in tokenizer.TokenizeUntil(escapeOnNewline: escapeOnNewline, delimiters))
            {
                tokens.Add(t);
            }

            ///

            return tokens;
        }
    }
}
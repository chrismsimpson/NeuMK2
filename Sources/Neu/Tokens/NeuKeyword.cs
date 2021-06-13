//
//
//

using System;

namespace Neu
{
    public enum NeuKeywordType
    {
        Func,
        Struct,
        Interface,
        Enum,
        Return,
        Case,
        Using,

        Private,
        Public,
        Internal,

        If,
        While,
        For,
        In,
        Is,
        Switch,
        Break,
        Continue,
        
        Let,
        Var,
        True,
        False,
        Await,
        Async
    }

    public partial class NeuKeyword : NeuToken
    {
        public NeuKeywordType KeywordType { get; init; }

        ///

        public NeuKeyword(
            String source,
            SourceLocation start,
            SourceLocation end,
            NeuKeywordType keywordType)
            : base(source, start, end)
        {
            this.KeywordType = keywordType;
        }
    }

    public partial class NeuKeyword
    {
        public static bool IsDeclModifier(
            NeuKeywordType keywordType)
        {
            switch (keywordType)
            {
                case NeuKeywordType.Public:
                case NeuKeywordType.Private:
                case NeuKeywordType.Internal:
                    return true;

                default:
                    return false;
            }
        }
    }
}
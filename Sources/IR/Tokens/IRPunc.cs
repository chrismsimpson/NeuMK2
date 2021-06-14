//
//
//

using System;

namespace Neu
{
    public enum IRPuncType
    {
        LeftBrace,
        RightBrace,

        LeftParen,
        RightParen,

        Semicolon,
        Colon,
        Arrow,
        Period
    }

    public partial class IRPunc : IRToken
    {
        public IRPuncType PuncType { get; init; }

        ///

        public IRPunc(
            Char source,
            SourceLocation start,
            SourceLocation end,
            IRPuncType puncType)
            : base(new String(new Char[] { source }), start, end)
        {
            this.PuncType = puncType;
        }

        public IRPunc(
            String source,
            SourceLocation start,
            SourceLocation end,
            IRPuncType puncType)
            : base(source, start, end)
        {
            this.PuncType = puncType;
        }
    }   
}
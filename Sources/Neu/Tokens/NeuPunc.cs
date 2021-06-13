//
//
//

using System;

namespace Neu
{
    public enum NeuPunctuationType
    {
        LeftBrace,
        RightBrace,

        LeftParen,
        RightParen,

        LeftBracket,
        RightBracket,

        Semicolon,
        Colon,
        Comma,
        Arrow,
        Period,

        LessThan,
        GreaterThan
    }

    public partial class NeuPunctuation : NeuToken
    {
        public NeuPunctuationType PunctuationType { get; init; }

        ///

        public NeuPunctuation(
            Char source,
            SourceLocation start,
            SourceLocation end,
            NeuPunctuationType punctuationType)
            : base(new String(new Char[] { source }), start, end)
        {
            this.PunctuationType = punctuationType;
        }

        public NeuPunctuation(
            String source,
            SourceLocation start,
            SourceLocation end,
            NeuPunctuationType punctuationType)
            : base(source, start, end)
        {
            this.PunctuationType = punctuationType;
        }
    }
}
//
//
//

using System;

namespace Neu
{
    public enum IRKeywordType
    {
        Func
    }

    public partial class IRKeyword : IRToken
    {
        public IRKeywordType KeywordType { get; init; }

        ///

        public IRKeyword(
            String source,
            SourceLocation start,
            SourceLocation end,
            IRKeywordType keywordType)
            : base(source, start, end)
        {
            this.KeywordType = keywordType;
        }
    }
}
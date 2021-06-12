//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class TokenHelpers
    {
        public static SourceLocation Start<T>(
            this IEnumerable<T> tokens)
            where T: Token
        {
            return tokens.OrderBy(x => x.Start.RawPosition).First().Start;
        }

        public static SourceLocation End<T>(
            this IEnumerable<T> tokens)
            where T: Token
        {
            return tokens.OrderBy(x => x.End.RawPosition).Last().End;
        }
    }
}
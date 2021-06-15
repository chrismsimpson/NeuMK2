//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class IEnumerableHelpers
    {
        public static IEnumerable<T> Drop<T>(
            this IEnumerable<T> items,
            int dropCount)
        {
            return items.Take(items.Count() - dropCount);
        }
    }
}
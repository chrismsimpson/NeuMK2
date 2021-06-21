//
//
//

using System;

namespace Neu
{
    public partial class Result
    {
        public Result() { }
    }

    public partial class ValueResult<T> : Result
    {
        public T Value { get; init; }

        public ValueResult(
            T value)
            : base()
        {
            this.Value = value;
        }
    }
}
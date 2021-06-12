//
//
//

using System;

namespace Neu
{
    public partial class NeuOperator : NeuToken
    {
        public NeuOperator(
            Char source,
            SourceLocation start,
            SourceLocation end)
            : base(new String(new Char[] { source }), start, end) { }

        public NeuOperator(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }

    ///

    public enum NeuBinaryOperatorType
    {
        Plus,
        Minus,
        EqualTo,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        LessThan,
        GreaterThan
    }

    public partial class NeuBinaryOperator : NeuOperator
    {
        public NeuBinaryOperatorType BinaryOperatorType { get; init; }

        ///

        public NeuBinaryOperator(
            Char source,
            SourceLocation start,
            SourceLocation end,
            NeuBinaryOperatorType binaryOperatorType)
            : base(source, start, end)
        {
            this.BinaryOperatorType = binaryOperatorType;
        }

        public NeuBinaryOperator(
            String source,
            SourceLocation start,
            SourceLocation end,
            NeuBinaryOperatorType binaryOperatorType)
            : base(source, start, end)
        {
            this.BinaryOperatorType = binaryOperatorType;
        }
    }
}
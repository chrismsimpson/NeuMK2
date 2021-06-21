//
//
//

using System;

namespace Neu
{
    public class NeuNumberLiteral : NeuLiteral
    {
        public NeuNumberLiteral(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }

    public class NeuIntegerLiteral : NeuNumberLiteral
    {
        public NeuIntegerLiteral(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }

    public class NeuFloatLiteral : NeuNumberLiteral
    {
        public NeuFloatLiteral(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }

    public static partial class NeuIntegerLiteralHelpers
    {
        public static int ToInt(
            this NeuIntegerLiteral intLiteral)
        {
            int i = 0;

            if (int.TryParse(intLiteral.Source, out i))
            {
                return i;
            }

            throw new Exception();
        }
    }
}
//
//
//

using System;

namespace Neu
{
    public partial class NeuDeclResult : Result
    {
        public NeuDeclaration Declaration { get; init; }

        ///

        public NeuDeclResult(
            NeuDeclaration declaration)
            : base()
        {
            this.Declaration = declaration;
        }
    }

    ///

    public partial class NeuValueResult : ValueResult
    {
        public NeuValueResult()
            : base() { }
    }
}
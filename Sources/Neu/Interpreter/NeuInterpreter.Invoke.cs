//
//
//

using System;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static Result? Invoke(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuFuncCallExpr funcCallExpr,
            NeuVTableEntry vtableEntry)
        {
            var funcDecl = vtableEntry.Node as NeuFuncDecl;

            if (funcDecl == null)
            {
                throw new Exception();
            }

            ///

            var codeBlock = funcDecl.GetFirst<NeuCodeBlock>();

            if (codeBlock == null)
            {
                throw new Exception();
            }

            ///

            var codeBlockItemList = codeBlock.GetFirst<NeuCodeBlockItemList>();

            if (codeBlockItemList == null)
            {
                throw new Exception();
            }

            ///

            foreach (var child in codeBlockItemList.Children)
            {
                var codeBlockItem = child as NeuCodeBlockItem;

                if (codeBlockItem == null)
                {
                    throw new Exception();
                }

                ///

                var n = interpreter.Execute(codeBlockItem);

                // foreach (var codeBlockItem )

                // interpreter.Execute(codeBlockItem);
            }

            

            throw new Exception();
        }
    }
}
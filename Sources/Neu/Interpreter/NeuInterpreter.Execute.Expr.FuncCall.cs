//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;
using static System.Console;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuFuncCallExpr funcCallExpr)
        {
            var (memberName, idName) = funcCallExpr.GetMemberAndIdentifierName();

            if (IsNullOrWhiteSpace(idName))
            {
                throw new Exception();
            }

            var entry = interpreter.FindVTableEntry(memberName, idName);

            if (entry == null)
            {
                throw new Exception();
            }

            var result = interpreter.Execute(funcCallExpr, entry);

            throw new Exception();
        }

        ///

        public static Result? Execute(
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

                WriteLine($"{n}");

                // foreach (var codeBlockItem )

                // interpreter.Execute(codeBlockItem);
            }

            

            throw new Exception();
        }
    }
}
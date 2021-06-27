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
            NeuNode node)
        {
            interpreter.Enter(node);

            dynamic? result = null;

            foreach (var child in node.Children)
            {
                switch (child)
                {
                    case NeuFuncDecl funcDecl:

                        result = interpreter.Execute(funcDecl);

                        break;



                    ///

                    case NeuExtendDecl extendDecl:

                        result = interpreter.Execute(extendDecl);

                        break;

                    ///

                    case NeuStructDecl structDecl:

                        result = interpreter.Execute(structDecl);

                        break;










                    ///

                    case NeuMemberDeclListItem memberDeclListItem:

                        result = interpreter.Execute(memberDeclListItem);

                        break;

                    ///

                    case NeuCodeBlockItemList codeBlockItemList:

                        result = interpreter.Execute(codeBlockItemList);

                        break;

                    ///

                    case NeuCodeBlockItem codeBlockItem:

                        result = interpreter.Execute(codeBlockItem);

                        break;

                    ///




                    case NeuFuncCallExpr funcCallExpr:

                        result = interpreter.Execute(funcCallExpr);

                        break;

                    ///

                    case NeuReturnStatement returnStmt:

                        result = interpreter.Execute(returnStmt);

                        break;

                    ///

                    case NeuSequenceExpr sequenceExpr:

                        result = interpreter.Execute(sequenceExpr);

                        break;

                    ///

                    case NeuExprList exprList:

                        result = interpreter.Execute(exprList);

                        break;

                    ///










                    ///

                    default:

                        throw new Exception();
                }
            }

            interpreter.Exit(node);

            return result;
        }
    }
}
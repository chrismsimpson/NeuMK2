//
//
//

using System;

using static System.String;

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

                        var memberName = interpreter.GetScopeName();

                        var declName = funcDecl.GetDeclName();

                        result = new NeuDeclResult(funcDecl);

                        interpreter.VTable.Add(memberName, declName, funcDecl);

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

                    default:

                        throw new Exception();
                }
            }

            interpreter.Exit(node);

            return result;
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuExtendDecl extendDecl)
        {
            interpreter.Enter(extendDecl);

            ///

            var extendDeclBlock = extendDecl.GetFirst<NeuMemberDeclBlock>();

            if (extendDeclBlock == null)
            {
                throw new Exception();
            }

            ///

            var extendDeclList = extendDeclBlock.GetFirst<NeuMemberDeclList>();

            if (extendDeclList == null)
            {
                throw new Exception();
            }

            ///

            var result = interpreter.Execute(extendDeclList);

            ///

            interpreter.Exit(extendDecl);

            ///

            return result;
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuStructDecl structDecl)
        {
            interpreter.Enter(structDecl);

            ///

            var structDeclBlock = structDecl.GetFirst<NeuMemberDeclBlock>();

            if (structDeclBlock == null)
            {
                throw new Exception();
            }

            ///

            var structDeclList = structDeclBlock.GetFirst<NeuMemberDeclList>();

            if (structDeclList == null)
            {
                throw new Exception();
            }

            ///

            var result = interpreter.Execute(structDeclList);

            ///

            interpreter.Exit(structDecl);

            ///

            return result;
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuFuncCallExpr funcCallExpr)
        {
            var (memberName, idName) = funcCallExpr.GetMemberAndIdentifierName();

            if (IsNullOrWhiteSpace(idName))
            {
                throw new Exception();
            }

            var n = interpreter.Find(memberName, idName);

            throw new Exception();
        }
    }
}
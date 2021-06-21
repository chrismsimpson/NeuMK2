//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

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

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuNumberLiteralExpr lhsExpr,
            NueBinaryOperatorExpr opExpr,
            NeuNumberLiteralExpr rhsExpr)
        {
            var lhsLiteral = lhsExpr.Children.First() as NeuNumberLiteral;

            if (lhsLiteral == null)
            {
                throw new Exception();
            }

            ///

            var binOp = opExpr.Children.First() as NeuBinaryOperator;

            if (binOp == null)
            {
                throw new Exception();
            }

            ///

            var rhsLiteral = rhsExpr.Children.First() as NeuNumberLiteral;

            if (rhsLiteral == null)
            {
                throw new Exception();
            }

            ///

            return interpreter.Execute(lhsLiteral, binOp, rhsLiteral);
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuNumberLiteral lhs,
            NeuBinaryOperator binOp,
            NeuNumberLiteral rhs)
        {
            switch (true)
            {
                case var _ when lhs is NeuIntegerLiteral lhsInt &&
                                rhs is NeuIntegerLiteral rhsInt:

                    return interpreter.Execute(lhsInt, binOp, rhsInt);

                ///
                
                default:

                    throw new Exception();
            }
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuIntegerLiteral lhs,
            NeuBinaryOperator binOp,
            NeuIntegerLiteral rhs)
        {
            switch (binOp.BinaryOperatorType)
            {
                case NeuBinaryOperatorType.Plus:

                    return new ValueResult<int>(lhs.ToInt() + rhs.ToInt());

                ///

                default:

                    throw new Exception();
            }
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuExprList exprList)
        {
            switch (exprList.Children.Count())
            {
                case 3 when exprList.Children.ElementAt(0) is NeuNumberLiteralExpr lhs &&
                            exprList.Children.ElementAt(1) is NueBinaryOperatorExpr op &&
                            exprList.Children.ElementAt(2) is NeuNumberLiteralExpr rhs:

                    return interpreter.Execute(lhs, op, rhs);

                ///
                
                default:

                    throw new Exception();
            }
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuSequenceExpr sequenceExpr)
        {
            throw new Exception();
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuReturnStatement returnStmt)
        {
            interpreter.Enter(returnStmt);

            ///

            Result? result = null;

            ///
            
            var expr = returnStmt.GetFirst<NeuExpression>();

            if (expr != null)
            {
                result = interpreter.Execute(expr);
            }

            ///

            interpreter.Exit(returnStmt);

            ///

            return result;
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuFuncDecl funcDecl)
        {
            var memberName = interpreter.GetScopeName();

            var name = funcDecl.GetDeclName();

            var result = new NeuDeclResult(funcDecl);

            interpreter.AddVTableEntry(memberName, name, funcDecl);

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

            var entry = interpreter.FindVTableEntry(memberName, idName);

            if (entry == null)
            {
                throw new Exception();
            }

            var result = interpreter.Invoke(funcCallExpr, entry);

            throw new Exception();
        }
    }
}
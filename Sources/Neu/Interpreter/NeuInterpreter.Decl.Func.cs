//
//
//

using System;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static Operation? Execute(
            this NeuFuncDecl funcDecl,
            Interpreter<NeuFrame, NeuVTableEntry> interpreter)
        {
            var func = new NeuFunc();

            dynamic? memberAccess = null; // TODO

            var funcName = funcDecl.Name();

            NeuVTableHelpers.Add(interpreter.VTable, memberAccess, funcName, func);

            // interpreter.VTable.Add(memberAccess, funcName, func);

            // interpreter.VTable.Add(funcName, func);

            // interpreter.VTable.Add(func);

            return func;
        }

        public static Operation? Execute(
            this NeuStructDecl structDecl,
            Interpreter<NeuFrame, NeuVTableEntry> interpreter)
        {
            var s = new NeuStruct();

            var structName = structDecl.Name();

            // interpreter.VTable.Add(structName, s);
            NeuVTableHelpers.Add(interpreter.VTable, null, structName, s);

            return s;
        }

        public static Operation? Execute(
            this NeuExtendDecl extendDecl,
            Interpreter<NeuFrame, NeuVTableEntry> interpreter)
        {
            var extension = new NeuExtension();

            // interpreter.VTable.Add(null, extension);
            NeuVTableHelpers.Add(interpreter.VTable, null, null, extension);

            return extension;
        }

        public static Operation? Execute(
            this NeuExpression expression,
            Interpreter<NeuFrame, NeuVTableEntry> interpreter)
        {
            switch (expression)
            {
                case NeuFuncCallExpr funcCallExpr:

                    return funcCallExpr.Execute(interpreter);

                ///

                default:
                
                    throw new Exception();
            }
        }

        public static Operation? Execute(
            this NeuFuncCallExpr funcCallExpr,
            Interpreter<NeuFrame, NeuVTableEntry> interpreter)
        {
            
            throw new Exception();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace IDE_dev
{
    public class VariableGetter : IExpressionVisitor
    {
        private readonly SortedSet<string> _varNames = new SortedSet<string>();
        public void Visit(Literal expression)
        {
            
        }

        public void Visit(Variable expression)
        {
            _varNames.Add(expression.Name);
        }

        public void Visit(BinaryExpression expression)
        {
            expression.FirstOperand.Accept(this);
            expression.SecondOperand.Accept(this);
        }

        public void Visit(ParenExpression expression)
        {
            expression.Operand.Accept(this);
        }

        public SortedSet<string> GetNames(IExpression expression)
        {
            _varNames.Clear();
            expression.Accept(this);
            return _varNames;
        }
    }
    public class ExpressionCompiler : IExpressionVisitor
    {
        private ImmutableSortedSet<string> _varNames;
        private ILGenerator _ctor1IL;

        public void Visit(Literal expression)
        {
            _ctor1IL?.Emit(OpCodes.Ldc_I4, int.Parse(expression.Value));
        }

        public void Visit(Variable expression)
        {
            _ctor1IL?.Emit(OpCodes.Ldarg, _varNames.IndexOf(expression.Name) + 1);
        }

        public void Visit(BinaryExpression expression)
        {
            
            expression.FirstOperand.Accept(this);
            expression.SecondOperand.Accept(this);
            switch (expression.Operator)
            {
                case "-":
                    _ctor1IL?.Emit(OpCodes.Sub);
                    break;
                case "+":
                    _ctor1IL?.Emit(OpCodes.Add);
                    break;
                case "*":
                    _ctor1IL?.Emit(OpCodes.Mul);
                    break;
                case "/":
                    _ctor1IL?.Emit(OpCodes.Div);
                    break;
            }
        }

        public void Visit(ParenExpression expression)
        {
            expression.Operand.Accept(this);
        }

        public override string ToString()
        {
            return string.Join(", ", _varNames);
        }

        public Type Compile(IExpression expression)
        {
            var varGetter = new VariableGetter();
            _varNames = varGetter.GetNames(expression).ToImmutableSortedSet();
            
            expression.Accept(this);
            var assemblyName = new AssemblyName("Evaluator");
            var assemblyBuilder =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    assemblyName,
                    AssemblyBuilderAccess.RunAndSave);

            var mb =
                assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
            var typeBuilder = mb.DefineType(
                "Evaluator",
                TypeAttributes.Public);
            var parameterTypes = _varNames.Select(_ => typeof(int)).ToArray();
            var methodBuilder = typeBuilder.DefineMethod(
                "Evaluate",
                MethodAttributes.Public,
                typeof(int),
                parameterTypes);

            _ctor1IL = methodBuilder.GetILGenerator();
            expression.Accept(this);
            _ctor1IL.Emit(OpCodes.Ret);
            _ctor1IL = null;

            var type = typeBuilder.CreateType();
            assemblyBuilder.Save(assemblyName.Name + ".dll");
            return type;
        }
    }
}
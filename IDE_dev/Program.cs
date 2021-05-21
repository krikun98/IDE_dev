using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IDE_dev
{
    public interface IExpressionVisitor
    {
        void Visit(Literal expression);
        void Visit(Variable expression);
        void Visit(BinaryExpression expression);
        void Visit(ParenExpression expression);
    }

    public interface IExpression
    {
        void Accept(IExpressionVisitor visitor);
    }

    public class Literal : IExpression
    {
        public Literal(string value)
        {
            Value = value;
        }

        public readonly string Value;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Variable : IExpression
    {
        public Variable(string name)
        {
            Name = name;
        }

        public readonly string Name;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class BinaryExpression : IExpression
    {
        public readonly IExpression FirstOperand;
        public readonly IExpression SecondOperand;
        public readonly string Operator;

        public BinaryExpression(IExpression firstOperand, IExpression secondOperand, string @operator)
        {
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operator = @operator;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ParenExpression : IExpression
    {
        public ParenExpression(IExpression operand)
        {
            Operand = operand;
        }

        public readonly IExpression Operand;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class DumpVisitor : IExpressionVisitor
    {
        private readonly StringBuilder myBuilder;

        public DumpVisitor()
        {
            myBuilder = new StringBuilder();
        }

        public void Visit(Literal expression)
        {
            myBuilder.Append("Literal(" + expression.Value + ")");
        }

        public void Visit(Variable expression)
        {
            myBuilder.Append("Variable(" + expression.Name + ")");
        }

        public void Visit(BinaryExpression expression)
        {
            myBuilder.Append("Binary(");
            expression.FirstOperand.Accept(this);
            myBuilder.Append(expression.Operator);
            expression.SecondOperand.Accept(this);
            myBuilder.Append(")");
        }

        public void Visit(ParenExpression expression)
        {
            myBuilder.Append("Paren(");
            expression.Operand.Accept(this);
            myBuilder.Append(")");
        }

        public override string ToString()
        {
            return myBuilder.ToString();
        }

        public void Clear()
        {
            myBuilder.Length = 0;
        }
    }
    public class SimpleParser
    {
        private static readonly Dictionary<char, short> OperatorPrecedence = new Dictionary<char, short>()
        {
            {'(', -1},
            {'+', 0},
            {'-', 0},
            {'/', 1},
            {'*', 1}
        };
        
        public static IExpression Parse(string text)
        {
            var operators = new Stack<char>();
            var expressions = new Stack<IExpression>();

            foreach (var ch in text)
            {
                if (char.IsDigit(ch))
                {
                    expressions.Push(new Literal(ch.ToString()));
                }
                else if (char.IsLetter(ch))
                {
                    expressions.Push(new Variable(ch.ToString()));
                }
                else if (ch == '(')
                {
                    operators.Push(ch);
                }
                else if (ch == ')')
                {
                    while (operators.Count >= 1 && operators.Peek() != '(')
                    {
                        _combineExpressions(operators, expressions);
                    }
                    _verify(operators.Count >= 1 && operators.Peek() == '(');
                    operators.Pop();
                    expressions.Push(new ParenExpression(expressions.Pop()));
                }
                else if (OperatorPrecedence.ContainsKey(ch))
                {
                    var precedence = OperatorPrecedence[ch];
                    while (operators.Count > 0 && OperatorPrecedence[operators.Peek()] >= precedence)
                    {
                        _combineExpressions(operators, expressions);
                    }
                    
                    operators.Push(ch);
                }
                else
                {
                    _verify(false);
                }
            }

            while (operators.Count > 0)
            {
                _combineExpressions(operators, expressions);
            }
            _verify(expressions.Count == 1);
            
            return expressions.Pop();
        }

        private static void _combineExpressions(Stack<char> operators, Stack<IExpression> expressions)
        {
            _verify(expressions.Count >= 2 && operators.Count >= 1);
            var right = expressions.Pop();
            var left = expressions.Pop();
            var binaryOperator = operators.Pop();
            expressions.Push(new BinaryExpression(left, right, binaryOperator.ToString()));
        }

        private static void _verify(bool condition)
        {
            if (!condition)
            {
                throw new ArgumentException("Invalid string provided.");
            }
        }
    }

    public class Tests
    {
        private DumpVisitor _dumpVisitor;

        [SetUp]
        public void Setup()
        {
            _dumpVisitor = new DumpVisitor();
        }

        [Test]
        public void Test1()
        {
            var dumpVisitor = new DumpVisitor();
            SimpleParser.Parse("1+2").Accept(dumpVisitor);
            Assert.AreEqual("Binary(Literal(1)+Literal(2))", dumpVisitor.ToString());

            Assert.Pass();
        }

        [Test]
        public void TestSingleLiteral()
        {
            SimpleParser.Parse("0").Accept(_dumpVisitor);
            Assert.AreEqual("Literal(0)", _dumpVisitor.ToString());
        }

        [Test]
        public void TestSingleVariable()
        {
            SimpleParser.Parse("X").Accept(_dumpVisitor);
            Assert.AreEqual("Variable(X)", _dumpVisitor.ToString());
        }

        [Test]
        public void TestSingleOperator()
        {
            SimpleParser.Parse("3*X").Accept(_dumpVisitor);
            Assert.AreEqual("Binary(Literal(3)*Variable(X))", _dumpVisitor.ToString());
        }

        [Test]
        public void TestPrecedence()
        {
            SimpleParser.Parse("a*b+c/d-e+f*g").Accept(_dumpVisitor);
            Assert.AreEqual(
                "Binary(Binary(Binary(Binary(Variable(a)*Variable(b))+" +
                "Binary(Variable(c)/Variable(d)))-Variable(e))+Binary(Variable(f)*Variable(g)))",
                _dumpVisitor.ToString());
        }

        [Test]
        public void TestBraces()
        {
            SimpleParser.Parse("a/(b-c)").Accept(_dumpVisitor);
            Assert.AreEqual("Binary(Variable(a)/" +
                            "Paren(Binary(Variable(b)-Variable(c))))", _dumpVisitor.ToString());
            _dumpVisitor.Clear();
            SimpleParser.Parse("(a+b)*(b-c)").Accept(_dumpVisitor);
            Assert.AreEqual("Binary(Paren(Binary(Variable(a)+Variable(b)))" +
                            "*Paren(Binary(Variable(b)-Variable(c))))", _dumpVisitor.ToString());
        }

        [Test]
        public void TestInvalid()
        {
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("*"));
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("-1"));
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("(T*)"));
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("1+-1"));
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("ab"));
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("22"));
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("8-)"));
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("(3"));
            Assert.Throws<ArgumentException>(() => SimpleParser.Parse("D)"));
        }
    }
}
using System;
using System.Collections.Generic;

namespace IDE_dev
{
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
}
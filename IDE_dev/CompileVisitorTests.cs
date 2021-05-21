using System;
using NUnit.Framework;

namespace IDE_dev
{
    public class CompileVisitorTests
    {
        private ExpressionCompiler _expressionCompiler;

        [SetUp]
        public void Setup()
        {
            _expressionCompiler = new ExpressionCompiler();
        }

        [Test]
        [TestCase("4", 4)]
        [TestCase("4+1", 5)]
        [TestCase("4-1", 3)]
        [TestCase("2*2", 4)]
        [TestCase("6/3", 2)]
        [TestCase("5*5+3*(3+4)*4", 109)]
        public void NoVariables(string expression, int result)
        {
            var expr = SimpleParser.Parse(expression);
            dynamic instance = Activator.CreateInstance(_expressionCompiler.Compile(expr));
            Assert.AreEqual(result, (int) instance.Evaluate());
        }


        [Test]
        [TestCase("x+3", 5, 8)]
        [TestCase("x*x", 6, 36)]
        [TestCase("x/x", 1024, 1)]
        [TestCase("x-x", 102, 0)]
        [TestCase("x*(1+x)", 6, 42)]
        public void OneVariable(string expression, int param, int result)
        {
            var expr = SimpleParser.Parse(expression);
            dynamic instance = Activator.CreateInstance(_expressionCompiler.Compile(expr));
            Assert.AreEqual(result, (int) instance.Evaluate(param));
        }

        [Test]
        [TestCase("a+b+c", 3, 4, 5, 12)]
        [TestCase("a*a+b*b+c*c", 3, 4, 5, 50)]
        [TestCase("a*(a+b)*(b+c)*c-5", 1, 2, 3, 40)]
        [TestCase("3*a+5*(b+c)", 4, 3, 3, 42)]
        public void ThreeVariables(string expression, int fst, int snd, int trd, int result)
        {
            var expr = SimpleParser.Parse(expression);
            dynamic instance = Activator.CreateInstance(_expressionCompiler.Compile(expr));
            Assert.AreEqual(result, (int) instance.Evaluate(fst, snd, trd));
        }
    }
}
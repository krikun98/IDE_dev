using System;
using NUnit.Framework;

namespace IDE_dev
{
    public class DumpVisitorTests
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
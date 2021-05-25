using JetBrains.ReSharper.Plugins.PascalDev;
using JetBrains.ReSharper.TestFramework;
using NUnit.Framework;

namespace JetBrains.ReSharper.Plugins.PascalDevTests
{
    [TestFixture]
    [TestFileExtension(".pascaldev")]
    public class ParserTest : ParserTestBase<PascalDevLanguage>
    {
        protected override string RelativeTestDataPath => "parser";

        [TestCase("helloworld")]
        [Test]
        public void Test1(string filename)
        {
            DoOneTest(filename);
        }
        
        [TestCase("array")]
        [Test]
        public void Test2(string filename)
        {
            DoOneTest(filename);
        }
        
        [TestCase("set")]
        [Test]
        public void Test3(string filename)
        {
            DoOneTest(filename);
        }
    }
}
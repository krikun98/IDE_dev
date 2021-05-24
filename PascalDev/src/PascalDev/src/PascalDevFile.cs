using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    public class PascalDevFile : FileElementBase
    {
        public override NodeType NodeType => PascalDevFileNodeType.Instance;

        public override PsiLanguageType Language => PascalDevLanguage.Instance;
    }

    public class PascalDevBlock : CompositeElement
    {
        public override NodeType NodeType => PascalDevCompositeNodeType.BLOCK;

        public override PsiLanguageType Language => PascalDevLanguage.Instance;
    }
}
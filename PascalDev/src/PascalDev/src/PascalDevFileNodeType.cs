using System;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    internal class PascalDevFileNodeType : CompositeNodeType
    {
        public PascalDevFileNodeType(string s, int index) : base(s, index)
        {
        }

        public static readonly PascalDevFileNodeType Instance = new PascalDevFileNodeType("PascalDev_FILE", 0);

        public override CompositeElement Create()
        {
            return new PascalDevFile();
        }
    }
    internal class PascalDevCompositeNodeType : CompositeNodeType
    {
        public PascalDevCompositeNodeType(string s, int index) : base(s, index)
        {
        }
        public static readonly PascalDevCompositeNodeType BLOCK = new PascalDevCompositeNodeType("PascalDev_BLOCK", 0);
        public static readonly PascalDevCompositeNodeType OTHER = new PascalDevCompositeNodeType("PascalDev_OTHER", 1);

        public override CompositeElement Create()
        {
            if (this == BLOCK)
                return new PascalDevBlock();
            else 
                throw new InvalidOperationException();
        }
    }

}
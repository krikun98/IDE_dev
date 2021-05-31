using System.Collections.Generic;
using JetBrains.ProjectModel;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    [ProjectFileTypeDefinition(Name)]
    public class PascalDevProjectFileType : KnownProjectFileType
    {
        public new const string Name = "PascalDev";

        public new static PascalDevProjectFileType Instance { get; private set; }

        private PascalDevProjectFileType() : base(Name, "PascalDev", new[] {PascalDev_EXTENSION})
        {
        }

        protected PascalDevProjectFileType(string name) : base(name)
        {
        }

        protected PascalDevProjectFileType(string name, string presentableName) : base(name, presentableName)
        {
        }

        protected PascalDevProjectFileType(string name, string presentableName, IEnumerable<string> extensions) : base(name,
            presentableName, extensions)
        {
        }

        public const string PascalDev_EXTENSION = ".PascalDev";
    }
}
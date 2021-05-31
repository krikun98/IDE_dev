using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    [LanguageDefinition(Name)]
    public class PascalDevLanguage : KnownLanguage
    {
        public new const string Name = "PascalDev";
    
        public new static PascalDevLanguage Instance { get; private set; }

        private PascalDevLanguage() : base(Name, Name)
        {
        }

        protected PascalDevLanguage([NotNull] string name) : base(name)
        {
        }

        protected PascalDevLanguage([NotNull] string name, [NotNull] string presentableName) : base(name, presentableName)
        {
        }
    }
}
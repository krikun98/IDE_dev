using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    [Language(typeof(PascalDevLanguage))]
    class PascalDevDaemonBehaviour : LanguageSpecificDaemonBehavior
    {
        public override ErrorStripeRequest InitialErrorStripe(IPsiSourceFile sourceFile)
        {
            return sourceFile.Properties.ShouldBuildPsi ? 
                ErrorStripeRequest.STRIPE_AND_ERRORS :
                ErrorStripeRequest.NONE;
        }
    }
}
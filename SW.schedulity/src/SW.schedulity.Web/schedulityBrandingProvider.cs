using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SW.schedulity.Web;

[Dependency(ReplaceServices = true)]
public class schedulityBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "schedulity";
    public override string LogoUrl => "/images/S..png";
}

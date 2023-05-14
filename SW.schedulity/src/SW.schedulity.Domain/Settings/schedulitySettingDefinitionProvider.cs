using Volo.Abp.Settings;

namespace SW.schedulity.Settings;

public class schedulitySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(schedulitySettings.MySetting1));
    }
}

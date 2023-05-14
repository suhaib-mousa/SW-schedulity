using SW.schedulity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SW.schedulity.Permissions;

public class schedulityPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(schedulityPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(schedulityPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<schedulityResource>(name);
    }
}

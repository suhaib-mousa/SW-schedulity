using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SW.schedulity.Localization;
using SW.schedulity.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace SW.schedulity.Web.Menus;

public class schedulityMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<schedulityResource>();
        var _currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                schedulityMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        if (!_currentUser.IsInRole("admin"))
        {
        context.Menu.Items.Insert(
            2,
            new ApplicationMenuItem(
                schedulityMenus.Home,
                l["Menu:User"],
                "~/Account/Manage",
                icon: "fas fa-graduation-cap",
                order: 0
            )
        );
        }
            context.Menu.Items.Insert(
                2,
                new ApplicationMenuItem(
                    schedulityMenus.Home,
                    l["Menu:User"],
                    "~/Account/Manage",
                    icon: "fas fa-user",
                    order: 0
                )
            );
        context.Menu.Items.Insert(
            3,
            new ApplicationMenuItem(
                schedulityMenus.Home,
                l["Menu:Logout"],
                "~/Account/Logout",
                icon: "fa fa-sign-out fa-rotate-180",
                order: 1001
            )
        );


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}

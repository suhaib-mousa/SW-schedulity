using System;
using System.Collections.Generic;
using System.Text;
using SW.schedulity.Localization;
using Volo.Abp.Application.Services;

namespace SW.schedulity;

/* Inherit your application services from this class.
 */
public abstract class schedulityAppService : ApplicationService
{
    protected schedulityAppService()
    {
        LocalizationResource = typeof(schedulityResource);
    }
}

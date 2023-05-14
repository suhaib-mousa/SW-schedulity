using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace SW.schedulity.Pages;

public class Index_Tests : schedulityWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

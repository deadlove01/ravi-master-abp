using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Xunit;

namespace ProductManagement.Products;

public class ProductAppServiceTests: ProductManagementApplicationTestBase
{
    private readonly IProductAppService _productAppService;

    public ProductAppServiceTests()
    {
        _productAppService = GetRequiredService<IProductAppService>();
    }
    
    [Fact]
    public async Task Should_Get_List_Of_Products()
    {
        //Act
        var result = await _productAppService.GetListAsync(new PagedAndSortedResultRequestDto());

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        //Acme Monochrome Laser Printer, Compact All-In One
        result.Items.ShouldContain(p => p.Name.Contains("Acme Monochrome Laser Printer"));
    }
}
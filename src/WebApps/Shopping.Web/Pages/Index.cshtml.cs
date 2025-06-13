using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Models.Catalog;
using Shopping.Web.Services;

namespace Shopping.Web.Pages
{
    public class IndexModel(ICatalogService catalogService, ILogger<IndexModel> logger)
        : PageModel
    {

        public IEnumerable<ProductModel>  ProductList { get; set; } = new List<ProductModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {

                logger.LogInformation("Index page visited.");
                //var result = await catalogService.GetProducts(2,3);
                var result = await catalogService.GetProducts();

                ProductList = result.Products;
                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Inner: " + ex.InnerException?.Message);
                throw;
            }
        }
    }
}

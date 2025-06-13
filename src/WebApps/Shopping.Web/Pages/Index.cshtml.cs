using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Models.Basket;
using Shopping.Web.Models.Catalog;
using Shopping.Web.Services;

namespace Shopping.Web.Pages;

public class IndexModel(
    ICatalogService catalogService,
    IBasketService basketService,
    ILogger<IndexModel> logger)
    : PageModel
{

    public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();



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

    public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    {
        try
        {
            logger.LogInformation("Adding product to cart: {ProductId}", productId);
            var product = await catalogService.GetProduct(productId);

            logger.LogInformation("Add to cart button clicked");

            var productResponse = await catalogService.GetProduct(productId);

            var basket = await basketService.LoadUserBasket();

            basket.Items.Add(new ShoppingCartItemModel
            {
                ProductId = productId,
                ProductName = productResponse.Product.Name,
                Price = productResponse.Product.Price,
                Quantity = 1,
                Color = "Black"
            });

            await basketService.StoreBasket(new StoreBasketRequest(basket));

            return RedirectToPage("Cart");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error adding product to cart");
            throw;
        }
    }
}

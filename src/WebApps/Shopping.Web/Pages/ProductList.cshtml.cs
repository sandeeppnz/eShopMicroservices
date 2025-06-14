using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Models.Basket;
using Shopping.Web.Models.Catalog;
using Shopping.Web.Services;

namespace Shopping.Web.Pages;

public class ProductListModel
    (ICatalogService catalogService,
    IBasketService basketService,
    ILogger<ProductListModel> logger)
    : PageModel
{

    public IEnumerable<ProductModel> ProductList { get; private set; } = [];
    public IEnumerable<string> CategoryList { get; private set; } = [];

    [BindProperty(SupportsGet = true)]
    public string SelectedCategory { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string categoryName)
    {
        var products = await catalogService.GetProducts();

        CategoryList = products.Products
            .SelectMany(p => p.Category)
            .Distinct();

        if (!string.IsNullOrEmpty(categoryName))
        {
            ProductList = products.Products
                .Where(p => p.Category.Contains(categoryName, StringComparer.OrdinalIgnoreCase));
            SelectedCategory = categoryName;
        }
        else
        {
            ProductList = products.Products;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    {
        var product = await catalogService.GetProduct(productId);
        if (product == null)
        {
            logger.LogWarning("Product with ID {ProductId} not found.", productId);
            return NotFound();
        }
        var basket = await basketService.LoadUserBasket();
        basket.Items.Add(new ShoppingCartItemModel
        {
            ProductId = product.Product.Id,
            ProductName = product.Product.Name,
            Price = product.Product.Price,
            Quantity = 1,
            Color = "Black" // Assuming a default color for simplicity
        });
        await basketService.StoreBasket(new StoreBasketRequest(basket));
        return RedirectToPage("Cart");
    }


}

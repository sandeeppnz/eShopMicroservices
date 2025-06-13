using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Models.Basket;
using Shopping.Web.Services;

namespace Shopping.Web.Pages;

public class CartModel(IBasketService basketService, ILogger<CartModel> logger) : PageModel
{
    public ShoppingCartModel Cart { get; set; } = new ShoppingCartModel();
    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            logger.LogInformation("Cart page visited.");
            Cart = await basketService.LoadUserBasket();
            return Page();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error loading cart");
            return RedirectToPage("/Error");
        }
    }

    public async Task<IActionResult> OnPostRemoveItemAsync(Guid productId)
    {
        try
        {
            logger.LogInformation("Removing item from cart: {ProductId}", productId);
            Cart = await basketService.LoadUserBasket();
            Cart.Items.RemoveAll(item => item.ProductId == productId);
            await basketService.StoreBasket(new StoreBasketRequest(Cart));
            return RedirectToPage("Cart");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error removing item from cart");
            return RedirectToPage("/Error");
        }
    }
}

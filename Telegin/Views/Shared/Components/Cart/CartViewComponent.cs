using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class CartViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var cart = new CartModel
        {
            Items = new List<CartItemModel>
            {
                new CartItemModel{Name="Трактор",Price=126},
                new CartItemModel{Name="Автомобиль",Price=70}
            }
        };
         return View(cart);
    }
}

public class CartModel
{
    public List<CartItemModel>? Items{get; set;}
}
public class CartItemModel
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}


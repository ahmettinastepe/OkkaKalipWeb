﻿using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.UI.Models
{
    public class CartModel : BaseModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItems { get; set; }

        public decimal TotalPrice()
        {
            return CartItems.Sum(x => x.Price * x.Quantity);
        }
    }

    public class CartItemModel
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
        void AddToCart(string userId, int productId, int quantity);
        Cart GetCartByUserId(string userId);
        void DeleteFromCart(string userId, int productId);
    }
}
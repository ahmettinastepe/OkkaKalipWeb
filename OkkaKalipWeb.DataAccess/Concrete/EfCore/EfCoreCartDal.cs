using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreCartDal : EfCoreRepository<Cart, NakisKalipContext>, ICartDal
    {
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new NakisKalipContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0 And ProductId=@p1";
                context.Database.ExecuteSqlCommand(cmd, cartId, productId);
            }
        }

        public Cart GetByUserId(string userId)
        {
            using (var context = new NakisKalipContext())
            {
                return context.Carts
                    .Include(x => x.CartItems)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefault(x => x.UserId == userId);
            }
        }

        public override void Update(Cart entity)
        {
            using (var context = new NakisKalipContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
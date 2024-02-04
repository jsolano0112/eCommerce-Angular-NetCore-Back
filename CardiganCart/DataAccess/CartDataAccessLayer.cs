using CardiganCart.Interfaces;
using CardiganCart.Models;

namespace CardiganCart.DataAccess
{
    public class CartDataAccessLayer: ICartService
    {
        readonly CardiganDBContext _dbContext;

        public CartDataAccessLayer(CardiganDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void AddCardiganToCart(int userId, int cardiganId)
        {
            throw new NotImplementedException();
        }

        public int ClearCart(int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOneCartItem(int userId, int cardiganId)
        {
            throw new NotImplementedException();
        }

        public string GetCartId(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetCartItemCount(int userId)
        {
            throw new NotImplementedException();
        }

        public void MergeCart(int tempUserId, int permUserId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCartItem(int userId, int cardiganId)
        {
            try
            {
                string cartId = GetCartId(userId);
                CartItems cartItem = _dbContext.CartItems.FirstOrDefault(
                    x => x.ProductId == cardiganId && x.CartId == cartId);

                _dbContext.CartItems.Remove(cartItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}

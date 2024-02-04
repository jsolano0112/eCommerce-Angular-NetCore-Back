namespace CardiganCart.Interfaces
{
    public interface ICartService
    {
        void AddCardiganToCart(int userId, int cardiganId);
        void RemoveCartItem(int userId, int cardiganId);
        void DeleteOneCartItem(int userId, int cardiganId);
        int GetCartItemCount(int userId);
        void MergeCart(int tempUserId, int permUserId);
        int ClearCart(int userId);
        string GetCartId(int userId);
    }

}

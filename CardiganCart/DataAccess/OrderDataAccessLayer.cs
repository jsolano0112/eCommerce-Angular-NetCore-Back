using CardiganCart.Interfaces;
using CardiganCart.Models;

namespace CardiganCart.DataAccess
{
    public class OrderDataAccessLayer: IOrderService
    {
        readonly CardiganDBContext _dbContext;

        public OrderDataAccessLayer(CardiganDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        int CreateRandomNumber(int length)
        {
            Random rnd = new Random();
            return rnd.Next(Convert.ToInt32(Math.Pow(10, length-1)),Convert.ToInt32(Math.Pow(10,length)));
        }
    }
}

using CardiganCart.Models;

namespace CardiganCart.Interfaces
{
    public interface IUserService
    {
        UserMaster AuthenticateUser(UserMaster loginCredentials);
        int RegisterUser(UserMaster userData);
        bool CheckUserAvailabity(string  userName);
    }
}

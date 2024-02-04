using CardiganCart.Interfaces;
using CardiganCart.Models;

namespace CardiganCart.DataAccess
{
    public class UserDataAccessLayer: IUserService
    {
        readonly CardiganDBContext _dbContext;

        public UserDataAccessLayer(CardiganDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public UserMaster AuthenticateUser(UserMaster loginCredentials)
        {
            UserMaster user = new UserMaster();

            var userDetails = _dbContext.UserMaster.FirstOrDefault(
                u => u.Username == loginCredentials.Username &&  u.Password == loginCredentials.Password);
            
            if (userDetails != null) { 
                user = new UserMaster
                {
                    Username = userDetails.Username,
                    Id = userDetails.Id,
                    UserTypeId = userDetails.UserTypeId
                };

                return user;
            }

        }

        public bool CheckUserAvailabity(string userName)
        {
            string user = _dbContext.UserMaster.FirstOrDefault(x => x.Username == userName)?.ToString();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RegisterUser(UserMaster userData)
        {
            try
            {
                userData.UserTypeId = 2;
                _dbContext.UserMaster.Add(userData);
                _dbContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}

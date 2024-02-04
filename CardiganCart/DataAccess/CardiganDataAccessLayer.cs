using CardiganCart.Interfaces;
using CardiganCart.Models;
using Microsoft.EntityFrameworkCore;

namespace CardiganCart.DataAccess
{
    public class CardiganDataAccessLayer : ICardiganService
    {
        readonly CardiganDBContext _dbContext;

        public CardiganDataAccessLayer(CardiganDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public int AddCardigan(Cardigan cardigan)
        {
            try
            {
                _dbContext.Cardigan.Add(cardigan);
                _dbContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public string DeleteCardigan(int id)
        {
            try
            {
                Cardigan cardigan = _dbContext.Cardigan.Find(id);
                _dbContext.Cardigan.Remove(cardigan);
                _dbContext.SaveChanges();

                return (cardigan.Name); 
            }
            catch
            {
                throw;
            }
        }

        public List<Cardigan> GetAllCardigans()
        {
            try
            {
                return _dbContext.Cardigan.AsNoTracking().ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Categories> GetAllCategories()
        {
                List<Categories> listCategories = new List<Categories>();
                listCategories = (from categories in _dbContext.Categories select categories).ToList();
                return listCategories;
        }

        public Cardigan GetCardigan(int id)
        {
            try
            {
                Cardigan cardigan = _dbContext.Cardigan.FirstOrDefault(x => x.Id == id);
                if(cardigan == null)
                {
                    _dbContext.Entry(cardigan).State = EntityState.Detached;
                    return cardigan;
                }

                return null;
            }
            catch
            {
                throw;
            }
        }

        public List<Cardigan> GetSimilarCardigans(int id)
        {
            List<Cardigan> listCardigans = new List<Cardigan>();
            Cardigan cardigan = GetCardigan(id);

            //falta Category
            listCardigans = _dbContext.Cardigan.Where(x => x.Id != cardigan.Id)
                .OrderBy(u => Guid.NewGuid())
                .Take(5)
                .ToList();
            return listCardigans;
        }

        public int UpdateCardigan(Cardigan cardigan)
        {
            try
            {
                Cardigan oldCardiganData = GetCardigan(cardigan.Id);

                if(oldCardiganData.Name != null)
                {
                    if(cardigan.Name == null)
                    {
                        cardigan.Name = oldCardiganData.Name;
                    }
                }

                _dbContext.Entry(cardigan).State = EntityState.Modified;
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

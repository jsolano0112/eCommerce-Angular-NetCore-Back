using CardiganCart.Models;

namespace CardiganCart.Interfaces
{
    public interface ICardiganService
    {
        List<Cardigan> GetAllCardigans();

        int AddCardigan(Cardigan cardigan);

        int UpdateCardigan(Cardigan cardigan);

        Cardigan GetCardigan(int id);

        string DeleteCardigan(int id);

        List<Categories> GetAllCategories();

        List<Cardigan> GetSimilarCardigans(int id);

    }
}

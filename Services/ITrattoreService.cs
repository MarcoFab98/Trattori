using Trattori.Model;
using Trattori.Model.Post;

namespace Trattori.Services
{
    public interface ITrattoreService
    {
        public Trattore AddTrattore(PostTrattoreModel trattore);

        public Trattore? GetDetails(int id);

        public List<Trattore> GetByColor(string colore);

        public void Remove(int id);

        public void Modifica(int id, PostTrattoreModel trattore);

        public List<Trattore> GetAll();

       
    }
}

using Trattori.Model;

namespace Trattori.Services
{
    public interface ITrattoreService
    {
        public Trattore AddTrattore(Trattore trattore);

        public Trattore? GetDetails(int id);

        public List<Trattore> GetByColor(string colore);
    }
}

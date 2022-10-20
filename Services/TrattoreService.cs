using Trattori.Model;

namespace Trattori.Services
{
    public class TrattoreService : ITrattoreService
    {
        private static List<Trattore> trattori = new List<Trattore>();
        public Trattore AddTrattore(Trattore trattore)
        {
            trattori.Add(trattore);
            return trattore;
        }

        public Trattore? GetDetails(int id)
        {
            return trattori.FirstOrDefault(trattore => trattore.Id == id);
        }

        public List<Trattore> GetByColor(string colore)
        {
            return trattori.Where(trattore => trattore.Colore == colore).ToList();
        }
    }
}

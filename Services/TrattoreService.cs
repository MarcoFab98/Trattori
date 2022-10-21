using Trattori.Model;
using Trattori.Model.Post;

namespace Trattori.Services
{
    public class TrattoreService : ITrattoreService
    {
        private static List<Gadget> _gadgets = new List<Gadget>();
        private static List<Trattore> _trattori = new List<Trattore>()
        {
            new Trattore()
            {
                Id = 1,
                Modello = "Lamborghini",
                Cavalli = 150,
                Colore = "Rosso",
            },
            new Trattore()
            {
                Id = 2,
                Modello = "Ferrari",
                Cavalli = 100,
                Colore = "Rosso"
            }
        };
        
        public List<Trattore> GetAll()
        {
            return _trattori;
        }

        public Trattore AddTrattore(PostTrattoreModel postTrattore)
        {
            var trattoreAdd = new Trattore()
            {
                Id = GetId(),
                Modello = postTrattore.Modello,
                Cavalli = postTrattore.Cavalli,
                Colore = postTrattore.Colore,
            };
            
            _trattori.Add(trattoreAdd);
            
            return trattoreAdd;
        }

        public Trattore? GetDetails(int id)
        {
            return _trattori.FirstOrDefault(trattore => trattore.Id == id);
        }

        public List<Trattore> GetByColor(string colore)
        {
            return _trattori.Where(trattore => trattore.Colore == colore).ToList();
        }

        public void Remove(int id)
        {
            var trattoreRimosso = _trattori.Single(trattore => trattore.Id == id);
            _trattori.Remove(trattoreRimosso);
        }

        public void Modifica(int id, PostTrattoreModel trattore)
        {
            //Remove(id);
            //AddTrattore(trattore);
            foreach(var tractor in _trattori)
            {
                if(tractor.Id == id)
                {
                    tractor.Modello = trattore.Modello;
                    tractor.Cavalli = trattore.Cavalli;
                    tractor.Colore = trattore.Colore;

                }
            }
        }

        private int GetId()
        {
            return _trattori.Max(trattore => trattore.Id) + 1;
        }
    }
}

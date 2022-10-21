using Trattori.Model;

namespace Trattori.Services
{
    public class GadgetService : IGadgetService
    {
        private static List<Gadget> _gadgets = new List<Gadget>()
        {
            new Gadget()
            {
                GadgetId = 1,
                NomeGadget = "Marmitta",
                TrattoriId = 1
            },
        };
        private static List<Trattore> _trattori = new List<Trattore>();

        public void AddGadget(Gadget gadget)
        {
           _gadgets.Add(gadget);
        }

        public List<Gadget> GetAll()
        {
            return _gadgets;
        }

        public Gadget InsertGadgetInTrattore(int GadgetId, int TrattoreId)
        {
            var gadgetToInsert = _gadgets.Where(gadget => gadget.GadgetId == GadgetId).FirstOrDefault();
            var trattoreDaGadgettare = _trattori.Where(trattori => trattori.Id == TrattoreId).FirstOrDefault();
           
            gadgetToInsert.TrattoriId = trattoreDaGadgettare.Id;
           
            return gadgetToInsert;
        }
    }
}

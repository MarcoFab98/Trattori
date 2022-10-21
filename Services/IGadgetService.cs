using Trattori.Model;

namespace Trattori.Services
{
    public interface IGadgetService
    {
        public List<Gadget> GetAll();

        public void AddGadget(Gadget gadget);
        public Gadget InsertGadgetInTrattore(int GadgetId, int TrattoreId);
    }
}

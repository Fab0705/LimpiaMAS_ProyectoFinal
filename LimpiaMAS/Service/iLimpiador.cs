using LimpiaMAS.Models;

namespace LimpiaMAS.Service
{
    public interface iLimpiador
    {
        IEnumerable<TbLimpiador> GetAllCleaners();
        void add(TbLimpiador limpiador);
        void remove(string id);
        TbLimpiador edit(string id);
        void EditDatails(TbLimpiador limpiador);
    }
}

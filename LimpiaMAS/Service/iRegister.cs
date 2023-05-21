using LimpiaMAS.Models;

namespace LimpiaMAS.Service
{
    public interface iRegister
    {
        void add(TbCliente obj);
        IEnumerable<TbCliente> GetAllClients();
        IEnumerable<TbLimpiador> GetAllCleaners();
    }
}

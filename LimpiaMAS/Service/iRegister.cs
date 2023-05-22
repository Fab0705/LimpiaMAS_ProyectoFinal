using LimpiaMAS.Models;

namespace LimpiaMAS.Service
{
    public interface iRegister
    {
        void add_usr(TbUser obj);
        void add_cli(TbCliente obj);
        void add_limp(TbLimpiador obj);
        IEnumerable<TbCliente> GetAllClients();
        IEnumerable<TbLimpiador> GetAllCleaners();
    }
}

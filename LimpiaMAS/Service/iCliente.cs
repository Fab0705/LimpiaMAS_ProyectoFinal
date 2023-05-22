using LimpiaMAS.Models;

namespace LimpiaMAS.Service
{
    public interface iCliente
    {
        IEnumerable<TbCliente> GetAllClientes();
        void Add(TbCliente cliente);
        void Remove(string id);
        TbCliente edit(String id);
        void EditDatails(TbCliente cliente);
    }
}

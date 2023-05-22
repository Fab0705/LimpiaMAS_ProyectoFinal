using LimpiaMAS.Models;

namespace LimpiaMAS.Service
{
    public class RegisterRepository : iRegister
    {
        private readonly Limpia_MasC conexion = new Limpia_MasC();

        public void add_cli(TbCliente obj)
        {
            conexion.TbClientes.Add(obj);
            conexion.SaveChanges();
        }
        public void add_limp(TbLimpiador obj)
        {
            conexion.TbLimpiadors.Add(obj);
            conexion.SaveChanges();
        }

        public void add_usr(TbUser obj)
        {
            conexion.TbUsers.Add(obj);
            conexion.SaveChanges();
        }

        public IEnumerable<TbLimpiador> GetAllCleaners()
        {
            return conexion.TbLimpiadors;
        }

        public IEnumerable<TbCliente> GetAllClients()
        {
            return conexion.TbClientes;
        }
    }
}

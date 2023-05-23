using LimpiaMAS.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
            obj.IdUsr = GetNextUsrId().ToString(); // Obtener el siguiente valor de la secuencia
            conexion.TbUsers.Add(obj);
            conexion.SaveChanges();
        }

        public int GetNextUsrId()
        {
            int nextId = 1;

            // hay registros?
            if (conexion.TbUsers.Any())
            {
                // obtener el ultimo id
                string lastId = conexion.TbUsers.Max(u => u.IdUsr);

                // generar el siguiente id + 1
                nextId = int.Parse(lastId) + 1;
            }

            return nextId;
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

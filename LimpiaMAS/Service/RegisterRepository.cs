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
            obj.IdLimp = GetNextLimpId().ToString();
            conexion.TbLimpiadors.Add(obj);
            conexion.SaveChanges();
        }

        public void add_usr(TbUser obj)
        {
            obj.IdUsr = GetNextUsrId().ToString(); // Obtener el siguiente valor de la secuencia
            conexion.TbUsers.Add(obj);
            conexion.SaveChanges();
        }
        public int GetNextLimpId()
        {
            int nextId = 1;

            // hay registros?
            if (conexion.TbLimpiadors.Any())
            {
                // obtener el ultimo id
                string lastId = conexion.TbLimpiadors.Max(u => u.IdLimp);

                // generar el siguiente id + 1
                nextId = int.Parse(lastId) + 1;
            }

            return nextId;
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

        public TbUser getUser(string usr, string pwd)
        {
            var user = conexion.TbUsers.FirstOrDefault(l => l.Usr == usr && l.Pwd == pwd);
            return user;
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

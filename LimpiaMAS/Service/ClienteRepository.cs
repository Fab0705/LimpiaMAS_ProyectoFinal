using LimpiaMAS.Models;

namespace LimpiaMAS.Service
{
    public class ClienteRepository : iCliente
    {
        Limpia_MasC conexion = new Limpia_MasC();
        public void add(TbCliente cliente)
        {
            try { 
                conexion.TbClientes.Add(cliente);
                conexion.SaveChanges();
            }catch (Exception ex) {
                Console.WriteLine("Ocurrio un error al grabar al archivo",ex.Message);
            }
        }

        public TbCliente edit(string id)
        {
            var obj = (from tCli in conexion.TbClientes where tCli.IdCli == id select tCli).Single();
            return obj;
        }

        public void EditDatails(TbCliente cliente)
        {
            var objModificar = (from tCli in conexion.TbClientes where tCli.IdCli == cliente.IdCli select tCli).Single();
            objModificar.NomCli = cliente.NomCli;
            objModificar.ApeCli = cliente.ApeCli;
            objModificar.DirCli = cliente.DirCli;
            objModificar.TelCli = cliente.TelCli;
            objModificar.Usr = cliente.Usr;
            objModificar.Pwd = cliente.Pwd;
            objModificar.Etiqueta = cliente.Etiqueta;

            conexion.SaveChanges();
        }

        public IEnumerable<TbCliente> GetAllClientes()
        {
            return conexion.TbClientes;
        }

        public void remove(string id)
        {
            var obj = (from tbCli in conexion.TbClientes where tbCli.IdCli == id select tbCli).Single();
            conexion.Remove(obj);
            conexion.SaveChanges() ;
        }
    }
}

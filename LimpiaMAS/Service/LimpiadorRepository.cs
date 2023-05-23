using LimpiaMAS.Models;

namespace LimpiaMAS.Service
{
    public class LimpiadorRepository : iLimpiador
    {
        Limpia_MasC conexion = new Limpia_MasC();

        public void add(TbLimpiador limpiador)
        {
            try
            {
                conexion.TbLimpiadors.Add(limpiador);
                conexion.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error al grabar al archivo", ex.Message);
            }
        }

        public TbLimpiador edit(string id)
        {
            var obj = (from tLimp in conexion.TbLimpiadors where tLimp.IdLimp == id select tLimp).Single();
            return obj;
        }

        public void EditDatails(TbLimpiador limpiador)
        {
            var objModificar = (from tLimp in conexion.TbLimpiadors where tLimp.IdLimp == limpiador.IdLimp select tLimp).Single();
            objModificar.NomLimp = limpiador.IdLimp;
            conexion.SaveChanges();
        }

        public IEnumerable<TbLimpiador> GetAllCleaners()
        {
            return conexion.TbLimpiadors;
        }

        public void remove(string id)
        {
            var obj = (from tLimp in conexion.TbLimpiadors where tLimp.IdLimp == id select tLimp).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}

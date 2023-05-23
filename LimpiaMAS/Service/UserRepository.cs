using LimpiaMAS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LimpiaMAS.Service
{
    public class UserRepository : iUsuario
    {
        private Limpia_MasC conexion = new Limpia_MasC();

        public void add(TbUser user)
        {
            try
            {
                conexion.TbUsers.Add(user);
                conexion.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error al graba los datos");
            }
        }

        public TbUser edit(string usr)
        {
            var obj = (from tUser in conexion.TbUsers
                       where tUser.Usr == usr
                       select tUser).Single();
            return obj;
        }

        public void EditDetails(TbUser user)
        {
            var objAModificar = (from tUser in conexion.TbUsers
                                 where tUser.Usr == user.Usr
                                 select tUser).Single();
            objAModificar.Nom = user.Nom;
            objAModificar.Ape = user.Ape;
            objAModificar.Usr = user.Usr;
            objAModificar.Pwd = user.Pwd;
            conexion.SaveChanges();
        }

        public IEnumerable<TbUser> GetAllUsers()
        {
            return conexion.TbUsers;
        }
        public void remove(string usr)
        {
            var obj = (from tUser in conexion.TbUsers
                       where tUser.Usr == usr
                       select tUser).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}

//using AspNetCore;
using LimpiaMAS.Models;
using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LimpiaMAS.Controllers
{
    public class ServicioController : Controller
    {
        private readonly iLimpiador _limpiador;
        private readonly iCliente _cliente;
        private readonly iDetalleServicio _detalleServicio;

        private bool _esPrimeraVez;
        public ServicioController(iLimpiador limpiador, iCliente cliente, iDetalleServicio detalleServicio)
        {
            _limpiador = limpiador;
            _detalleServicio = detalleServicio;
            _cliente = cliente;
        }
        public IActionResult Index()
        {
            return View(_limpiador.GetAllCleaners());
        }

        public IActionResult Carrito(
            //variables que recibimos del listado de limpiadores
            string idLimp, string Nom, string Ape, DateTime TInicial, DateTime TFinal, string catServicio, double Tarifa, DateTime Fecha)
        {
            int idServ;
            //Lista para los intervalos de tiempo
            List<string> opcionesTiempo = new List<string>();

            while (TInicial <= TFinal)
            {
                opcionesTiempo.Add(TInicial.ToString("HH:mm"));
                TInicial = TInicial.AddMinutes(30);
            }
            Console.Write(opcionesTiempo.Count());
            //verificar si la sesion de usuario existe
            var objSession = HttpContext.Session.GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar
                TbUser usuario = JsonConvert.DeserializeObject<TbUser>(objSession);
                TbCliente cliente = _cliente.getCliente(usuario.Usr, usuario.Pwd);

                if (_cliente.SearchCli(usuario.Usr, usuario.Pwd) == false)
                {
                    return RedirectToAction("FormCliente", "Cliente");
                }
                else
                {
                        //VIEWBAGS PARA LA VISTA DEL CARRITO PARA GRABAR
                        //ViewBag para el ID
                        ViewBag.IdLimp = idLimp;

                        //agregamos a un ViewBag para pasar el nombre y apellido del limpiador
                        ViewBag.NombreApellidoLimpiador = Nom + " " + Ape;

                        //ViewBag para el NomApe del cliente, obtenemos de la sesion
                        ViewBag.NombreApellidoCliente = usuario.Nom + " " + usuario.Ape;

                        //ViewBag para la dirCli, obtenemos de la sesion
                        ViewBag.DireccionCliente = cliente.DirCli;

                        //ViewBag para la categoria del servicio
                        ViewBag.CategoriaServicio = catServicio;

                        //ViewBag para la fecha del servicio
                        ViewBag.FechaServicio = Fecha.Date;

                        //tarifa
                        ViewBag.Tarifa = Tarifa;
                        Console.WriteLine("la tarifa es: " + Tarifa);
                        //usamos nuestra lista y eliminamos el ultimo element
                        opcionesTiempo.RemoveAt(opcionesTiempo.Count - 1);
                        //ViewBag para el tiempo
                        ViewBag.OpcionesTiempo = opcionesTiempo;
                        return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Limpia");
            }
        }

        public IActionResult Filtrado(DateTime fecha, DateTime fecha_inicio, DateTime fecha_fin)
        {
            //la fecha tiene un valor valido?
            if (fecha != DateTime.MinValue)
            {
                ViewBag.Fecha = fecha;                
                return View(_limpiador.GetLimpiadoresFecha(fecha));
            }
            else
            {
                return FiltradoFechas(fecha_inicio, fecha_fin);
            }
        }

        public IActionResult FiltradoFechas(DateTime fecha_inicio, DateTime fecha_fin)
        {
            Console.WriteLine("filtradofechas");
            ViewBag.FechaInicio = fecha_inicio;
            ViewBag.FechaFin = fecha_fin;
            return View("FiltradoFechas", _limpiador.GetLimpiadoresFechaInicioFin(fecha_inicio, fecha_fin));
        }
        /*public IActionResult Carrito(
            //variables que recibimos del listado de limpiadores
            string idLimp, string Nom, string Ape, DateTime TInicial, DateTime TFinal, string catServicio, double Tarifa, DateTime Fecha,
            //variables que recibimos del carrito
            string nomApeLimp, string nomApeCli, string catServ, double tarife, string dirCli, DateTime fecServ,
            string idCli, string area, DateTime horaServicio)
        {
            int idServ;
            //Lista para los intervalos de tiempo
            List<string> opcionesTiempo = new List<string>();

            while (TInicial <= TFinal)
            {
                opcionesTiempo.Add(TInicial.ToString("HH:mm"));
                TInicial = TInicial.AddMinutes(30);
            }
            Console.Write(opcionesTiempo.Count());
            //verificar si la sesion de usuario existe
            var objSession = HttpContext.Session.GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar
                TbUser usuario = JsonConvert.DeserializeObject<TbUser>(objSession);
                TbCliente cliente = _cliente.getCliente(usuario.Usr, usuario.Pwd);

                if (_cliente.SearchCli(usuario.Usr, usuario.Pwd) == false)
                {
                    return RedirectToAction("FormCliente", "Cliente");
                }
                else
                {
                    //BOOLEANO
                    if (!HttpContext.Session.TryGetValue("EsPrimeraVez", out byte[] esPrimeraVezValue))
                    {
                        // No se ha establecido en la sesión, por lo tanto, es la primera vez
                        _esPrimeraVez = true;
                        HttpContext.Session.Set("EsPrimeraVez", Encoding.UTF8.GetBytes(_esPrimeraVez.ToString()));
                        //VIEWBAGS PARA LA VISTA DEL CARRITO LA 1RA VEZ
                        //ViewBag para el ID
                        ViewBag.IdLimp = idLimp;

                        //agregamos a un ViewBag para pasar el nombre y apellido del limpiador
                        ViewBag.NombreApellidoLimpiador = Nom + " " + Ape;

                        //ViewBag para el NomApe del cliente, obtenemos de la sesion
                        ViewBag.NombreApellidoCliente = usuario.Nom + " " + usuario.Ape;

                        //ViewBag para la dirCli, obtenemos de la sesion
                        ViewBag.DireccionCliente = cliente.DirCli;

                        //ViewBag para la categoria del servicio
                        ViewBag.CategoriaServicio = catServicio;

                        //ViewBag para la fecha del servicio
                        ViewBag.FechaServicio = Fecha.Date;

                        //tarifa
                        ViewBag.Tarifa = Tarifa;
                        Console.WriteLine("la tarifa es: " + Tarifa);
                        //usamos nuestra lista y eliminamos el ultimo element
                        opcionesTiempo.RemoveAt(opcionesTiempo.Count - 1);
                        //ViewBag para el tiempo
                        ViewBag.OpcionesTiempo = opcionesTiempo;
                    }
                    else
                    {
                        Console.WriteLine("obtenemos el valor del bool de la sesion");
                        // Se ha establecido en la sesión, obtenemos su valor
                        bool.TryParse(Encoding.UTF8.GetString(esPrimeraVezValue), out _esPrimeraVez);
                        Console.WriteLine("valor: " + _esPrimeraVez);
                    }
                    if (!_esPrimeraVez)
                    {
                        Console.WriteLine("no es primera vez");
                        //eliminamos el ultimo intervalo ya que es el que no usaremos pq la 
                        //disponibilidad termina ahi, y el servicio dura 30min por defecto
                        opcionesTiempo.RemoveAt(opcionesTiempo.Count - 1);
                        //creamos nuestro objeto detalleServicio
                        TbDetalleservicio detalleservicio = new TbDetalleservicio();
                        //UNA VEZ MANDADO EL FORM EN EL CARRITO AGREGAMOS LOS DATOS Y LO
                        //AGREGAMOS A LA LISTA
                        detalleservicio.NomapeLim = nomApeLimp;
                        Console.WriteLine("nomApeLimp: " + detalleservicio.NomapeLim);
                        detalleservicio.NomapeCli = nomApeCli;
                        Console.WriteLine("nomApeCli: " + detalleservicio.NomapeCli);
                        detalleservicio.CatServ = catServ;
                        Console.WriteLine("catServ: " + detalleservicio.CatServ);
                        //reemplazar la coma por punto decimal
                        string areaFormatted = area.Replace(",", ".");
                        //multiplicar el area por la tarifa
                        detalleservicio.ImpServ = (decimal)(Convert.ToDouble(areaFormatted) * tarife);
                        Console.WriteLine("el impServ es: " + detalleservicio.ImpServ);
                        detalleservicio.DirCli = dirCli;
                        Console.WriteLine("dirCli: " + detalleservicio.DirCli);
                        detalleservicio.FecServ = fecServ;
                        Console.WriteLine("fecServ: " + detalleservicio.FecServ);
                        detalleservicio.HoraServ = TimeSpan.FromTicks(horaServicio.TimeOfDay.Ticks); ;
                        Console.WriteLine("horaServicio: " + detalleservicio.HoraServ);
                        //la duracion del servicio es estandar, 30 minutos
                        TimeSpan duracion = new TimeSpan(0, 30, 0);
                        detalleservicio.DurServ = duracion;
                        Console.WriteLine("DurServ" + detalleservicio.DurServ);
                        //añadimos a la bd
                        _detalleServicio.add(detalleservicio);
                        Console.WriteLine(area);
                        Console.WriteLine(horaServicio.ToString("HH:mm:ss"));
                    }
                    //como ya no es la 1ra vez cambiamos la variable de sesion
                    _esPrimeraVez = false;
                    HttpContext.Session.Set("EsPrimeraVez", Encoding.UTF8.GetBytes(_esPrimeraVez.ToString()));
                    return View(_detalleServicio.GetAllDetalles(idCli));
                }
            }
            else
            {
                return RedirectToAction("Logeo, Login");
            }
        }*/

        [Route("Servicio/Eliminar/{Id}")]
        public IActionResult eliminar(string id)
        {
            //_detallesCarrito.RemoveAll(d => d.IdDetserv == id);
            return RedirectToAction("Carrito");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Limpia");
        }
    }
}

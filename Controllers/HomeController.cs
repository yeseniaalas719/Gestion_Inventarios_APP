using System.Linq;
using System.Web.Mvc;
using Gestion_Inventarios_APP.Models;

namespace Gestion_Inventarios_APP.Controllers
{
    public class HomeController : Controller
    {
        private DbContexto db = new DbContexto();

        public ActionResult Index()
        {
            var listaProductos = db.Productos.ToList();
            return View(listaProductos);
        }

        [HttpPost]
        public ActionResult Guardar(string nombre, int cantidad)
        {
            var nuevoProducto = new Producto
            {
                Nombre = nombre,
                Cantidad = cantidad
            };

            db.Productos.Add(nuevoProducto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
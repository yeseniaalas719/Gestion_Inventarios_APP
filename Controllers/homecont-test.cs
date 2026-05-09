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
        public ActionResult Guardar(string nombre, int? cantidad)
        {
            // VALIDACIÓ NOMBRE
            if (string.IsNullOrWhiteSpace(nombre))
            {
                ModelState.AddModelError("nombre", "El nombre es obligatorio.");
            }

            // VALIDACIÓ CANTIDAD Y NÚMERO POSITIVO
            if (!cantidad.HasValue)
            {
                ModelState.AddModelError("cantidad", "La cantidad es obligatoria.");
            }
            else if (cantidad <= 0)
            {
                ModelState.AddModelError("cantidad", "Debe ingresar un número positivo.");
            }

            if (!ModelState.IsValid)
            {
                var listaProductos = db.Productos.ToList();
                return View("Index", listaProductos);
            }

            var nuevoProducto = new Producto
            {
                Nombre = nombre,
                Cantidad = cantidad.Value
            };

            db.Productos.Add(nuevoProducto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

using Gestion_Inventarios_APP.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Gestion_Inventarios_APP.Controllers
{
    public class HomeController : Controller
    {
        private DbContexto db = new DbContexto();

        public ActionResult Index(int? idEditar)
        {
            ViewBag.IdEditar = idEditar;

            var listaProductos = db.Productos.ToList();
            var nombres = listaProductos.Select(p => p.Nombre).ToList();
            var cantidades = listaProductos.Select(p => p.Cantidad).ToList();
            ViewBag.EtiquetasJSON = Newtonsoft.Json.JsonConvert.SerializeObject(nombres);
            ViewBag.ValoresJSON = Newtonsoft.Json.JsonConvert.SerializeObject(cantidades);
            return View(listaProductos);
        }

        [HttpPost]
        public ActionResult Guardar(string nombre, int? cantidad)
        {
            // VALIDACIÓN NOMBRE
            if (string.IsNullOrWhiteSpace(nombre))
            {
                ModelState.AddModelError("nombre", "El nombre es obligatorio.");
            }

            // VALIDACIÓN CANTIDAD Y NÚMERO POSITIVO
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
                Cantidad = cantidad.Value,
                FechaRegistro = DateTime.Now
            };

            db.Productos.Add(nuevoProducto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
            var producto = db.Productos.Find(id);
            if (producto != null)
            {
                db.Productos.Remove(producto);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult Actualizar(Producto productoEditado)
        {
            if (ModelState.IsValid && productoEditado.Cantidad > 0)
            {
                var original = db.Productos.AsNoTracking().FirstOrDefault(p => p.Id == productoEditado.Id);

                if (original != null)

                {
                    productoEditado.FechaRegistro = original.FechaRegistro;
                    db.Entry(productoEditado).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View("Editar", productoEditado);

        }
    }
}

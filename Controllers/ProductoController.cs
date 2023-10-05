using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Utils;
using Ejemplo1.Models;

namespace Ejemplo1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public IActionResult Index()
        {
           
            return View(Utils.Utils.ListaProductos);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Etiqueta propia de ASP .NET
        public IActionResult Create(Producto producto) //Aquí recibo el objeto de tipo producto
        {
            if (producto != null)
            {
                int i = Utils.Utils.ListaProductos.Count() + 1;
                producto.IdProducto = i;
                Utils.Utils.ListaProductos.Add(producto); // Agrego el producto a la lista

            }
            
            return RedirectToAction("Index");
        }


        // GET: ProductoController/Edit/5
        public IActionResult Edit(int IdProducto)
        {

            // Busco el producto mediante una función anónima
            Producto producto = Utils.Utils.ListaProductos.Find(ObjetoActual => ObjetoActual.IdProducto == IdProducto);
            if (producto != null)
            {

                // Retorno el producto a la vista
                return View(producto);

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            // Busco el producto mediante una función anónima
            Producto producto2 = Utils.Utils.ListaProductos.Find(ObjetoActual => ObjetoActual.IdProducto == producto.IdProducto);

            if (producto2 != null)
            {

                producto2.Nombre = producto.Nombre;
                producto2.Descripcion = producto.Descripcion;
                producto2.Cantidad = producto.Cantidad;    

                return RedirectToAction("Index");

            }
            // Retorno el producto a la vista
            return View();
        }



        // GET: ProductoController/Delete/5
        public IActionResult Delete(int IdProducto)
        {
            // Busco el producto mediante una función anónima
            Producto producto2 = Utils.Utils.ListaProductos.Find(ObjetoActual => ObjetoActual.IdProducto == IdProducto);

            if (producto2 != null)
            {

                Utils.Utils.ListaProductos.Remove(producto2);
                return RedirectToAction("Index");

            }
            return View();
        }

     
       
    }
}

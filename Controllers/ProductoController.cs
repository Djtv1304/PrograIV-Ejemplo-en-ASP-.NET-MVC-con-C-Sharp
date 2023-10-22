using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Utils;
using Ejemplo1.Models;
using Ejemplo1.API;

namespace Ejemplo1.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IAPIService _apiService;

        public ProductoController( IAPIService IAPIService)
        {
            // Inyecto la dependencia de mi interfaz para poder hacer uso de mis métodos GET, POST, PUT, DELETE
            _apiService = IAPIService;

        }
        

        // GET: ProductoController
        public async Task<IActionResult> Index()
        {

            try 
            {

                List<Producto> productos = await _apiService.GetProducto();

                

                return View(productos);
            }
            catch (Exception error)
            {

                return View();

            }
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Etiqueta propia de ASP .NET
        public async Task<IActionResult> Create(Producto producto) //Aquí recibo el objeto de tipo producto
        {
            //if (producto != null)
            //{
            //    int i = Utils.Utils.ListaProductos.Count() + 1;
            //    producto.IdProducto = i;
            //    Utils.Utils.ListaProductos.Add(producto); // Agrego el producto a la lista

            //}

            try
            {
                if (producto != null)
                {

                    // Invoco a la API y le envío el nuevo producto
                    await _apiService.CreateProducto(producto); 
                    // Redirijo a la vista principal
                    return RedirectToAction("Index"); 

                }

            } catch (Exception error)
            {

                return View();

            }

            return View();
        }


        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdProducto)
        {

            try
            {

                // Busco el producto mediante una función anónima
                //Producto producto = Utils.Utils.ListaProductos.Find(ObjetoActual => ObjetoActual.IdProducto == IdProducto);

                // Invoco a la API y traigo mi producto en base al ID
                Producto productoEncontrado = await _apiService.GetProductoByID(IdProducto);

                if (productoEncontrado != null)
                {

                    // Retorno el producto a la vista
                    return View(productoEncontrado);

                }
            }

            catch (Exception error)
            {

                return View();

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto nuevoProducto)
        {

            try
            {

                if (nuevoProducto != null)
                {

                    // Envío a la API el nuevo producto y el ID del mismo
                    await _apiService.UpdateProducto(nuevoProducto, nuevoProducto.IdProducto);

                    return RedirectToAction("Index");

                }
                // Retorno el producto a la vista
                return View();

            }

            catch (Exception error) 
            {
                
                return View();
            
            }
        }


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdProducto)
        {
            // Busco el producto mediante una función anónima
            //Producto producto2 = Utils.Utils.ListaProductos.Find(ObjetoActual => ObjetoActual.IdProducto == IdProducto);
            try
            {

                if (IdProducto != 0)
                {

                    await _apiService.DeleteProducto(IdProducto);
                    return RedirectToAction("Index");

                }

            }
            catch (Exception error)
            {

                return View();

            }

            return RedirectToAction("Index");

        }
    }
}

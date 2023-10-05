namespace Ejemplo1.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }

        //public Producto(int IdProducto, string Nombre, string Descripcion, int cantidad)
        //{
        //    this.IdProducto = IdProducto;
        //    this.Nombre = Nombre;
        //    this.Descripcion = Descripcion;
        //    this.Cantidad = cantidad;
        //}

        // Constructor de tipado

        // Constructor para trabajar con Blazor
        //public Producto()
        //{
        //    this.IdProducto = Contador++;
        //}
    }
}

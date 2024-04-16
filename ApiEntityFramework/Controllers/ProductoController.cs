using ApiEntityFramework.Data;
using ApiEntityFramework.DTO;
using ApiEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiEntityFramework.Controllers
{
    [Route("api/controller/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly eCommerceNetContext _context;
        public ProductoController(eCommerceNetContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public void CrearProducto(ProductoDTO producto, int cantidad)
        {
            Producto prod = new Producto();
            prod.Nombre = producto.Nombre;
            prod.Fecha = producto.Fecha;
            prod.Precio = producto.Precio;
            prod.Imagen = producto.Imagen;

            _context.Productos.Add(prod);
            _context.SaveChanges();

            CantidadProducto cp = new CantidadProducto();
            cp.IdProducto = prod.Id;
            cp.Cantidad = cantidad;
            
            _context.CantidadProductos.Add(cp);
            _context.SaveChanges();
        }

        [HttpPost("eliminar/{id}")]
        public void EliminarProducto(int id)
        {
            var prod = _context.Productos.Find(id);
            
            if(prod != null)
            {
                var cps = _context.CantidadProductos.Where(x => x.IdProducto == id);
                foreach (var cp in cps) // deberia haber uno solo pero buscamos todos en caso de errores o cambios
                {
                    _context.CantidadProductos.Remove(cp);
                }
                    
                var carritos = _context.Carritos.Where(x => x.IdProducto == id);
                foreach(var c in carritos)
                {
                    _context.Carritos.Remove(c);
                }

                var ordenDetalles = _context.OrdenDetalles.Where(x => x.IdProducto == id);
                foreach (var od in ordenDetalles)
                {
                    _context.OrdenDetalles.Remove(od);
                }

                _context.Productos.Remove(prod);
                _context.SaveChanges();
            }
        }

        [HttpPost("modificar")]
        public void ModificarProducto(ProductoDTO producto)
        {
            var prod = _context.Productos.Find(producto.Id);

            if (prod != null)
            {
                prod.Nombre = producto.Nombre;
                prod.Imagen = producto.Imagen;
                prod.Fecha = producto.Fecha;
                prod.Precio = producto.Precio;

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Producto> ListaProductos()
        {
            var listaProductos = _context.Productos.ToList();
            return listaProductos;
        }

        [HttpGet("id/{id}")]
        public List<Producto> ListaProductosPorId(int id)
        {
            var listaProductos = _context.Productos.Where(x => x.Id == id).ToList();
            return listaProductos;
        }

        [HttpGet("nombre/{nombre}")]
        public List<Producto> ListaProductosPorNombre(string nombre)
        {
            var listaProductos = _context.Productos.Where(x => x.Nombre == nombre).ToList();
            return listaProductos;
        }

    }
}

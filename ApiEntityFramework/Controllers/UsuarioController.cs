using ApiEntityFramework.Data;
using ApiEntityFramework.DTO;
using ApiEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiEntityFramework.Controllers
{
    [Route("api/controller/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly eCommerceNetContext _context;
        public UsuarioController(eCommerceNetContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void CrearUsuario(UsuarioDTO usuario)
        {
            Usuario user = new Usuario();
            user.Email = usuario.Email;
            user.Password = usuario.Password;
            user.Fecha = usuario.Fecha;

            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        [HttpPost("eliminar/{id}")]
        public void EliminarUsuario(int id)
        {
            var user = _context.Usuarios.Find(id);

            if (user != null)
            {
                var carritos = _context.Carritos.Where(x => x.IdUsuario == id);

                foreach(var c in carritos)
                {
                    _context.Carritos.Remove(c);
                }


                var ordenPagos = _context.OrdenPagos.Where(x => x.IdUsuario == id);

                foreach (var op in ordenPagos)
                {
                    var ordenDetalles = _context.OrdenDetalles.Where(x => x.IdOrdenPago == op.Id);

                    foreach (var od in ordenDetalles)
                    {
                        _context.OrdenDetalles.Remove(od);
                    }

                    _context.OrdenPagos.Remove(op);
                }


                var direcciones = _context.Direccions.Where(x => x.IdUsuario == id);

                foreach (var d in direcciones)
                {
                    _context.Direccions.Remove(d);
                }
            
                _context.Usuarios.Remove(user);
                _context.SaveChanges();
            }
        }

        [HttpPost("modificar")]
        public void ModificarUsuario(UsuarioDTO usuario)
        {
            var user = _context.Usuarios.Find(usuario.Id);

            if (user != null)
            {
                user.Email = usuario.Email;
                user.Password = usuario.Password;
                user.Fecha = usuario.Fecha;

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Usuario> ListaUsuarios()
        {
            var listaUsuarios = _context.Usuarios.ToList();
            return listaUsuarios;
        }

        [HttpGet("id/{id}")]
        public List<Usuario> ListaUsuariosPorId(int id)
        {
            var listaUsuarios = _context.Usuarios.Where(x => x.Id == id).ToList();
            return listaUsuarios;
        }

        [HttpGet("email/{email}")]
        public List<Usuario> ListaUsuariosPorEmail(string email)
        {
            var listaUsuarios = _context.Usuarios.Where(x => x.Email == email).ToList();
            return listaUsuarios;
        }
    }
}

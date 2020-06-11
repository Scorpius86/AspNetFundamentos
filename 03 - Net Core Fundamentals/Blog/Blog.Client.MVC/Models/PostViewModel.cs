using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.MVC.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int UsuarioIdPropietario { get; set; }
        public int UsuarioIdCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioIdActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public UsuarioViewModel UsuarioActualizacion { get; set; }
        public UsuarioViewModel UsuarioCreacion { get; set; }
        public UsuarioViewModel UsuarioPropietario { get; set; }
    }
}

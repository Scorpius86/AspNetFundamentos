using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Application.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int UsuarioIdPropietario { get; set; }
        public int UsuarioIdCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioIdActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public UsuarioDto UsuarioActualizacion { get; set; }
        public UsuarioDto UsuarioCreacion { get; set; }
        public UsuarioDto UsuarioPropietario { get; set; }
    }
}

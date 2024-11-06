using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Dominio.ValueObjects
{
    public class UsuarioVO
    {
        public int idUsuario { get; set; }

        public string nmUsuario { get; set; }

        public string senha { get; set; }

        public string nmCargo { get; set; }
    }
}

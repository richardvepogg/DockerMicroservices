using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }

        public string nmusuario { get; set; }

        public string senha { get; set; }

        public string nmcargo { get; set; }
    }
}

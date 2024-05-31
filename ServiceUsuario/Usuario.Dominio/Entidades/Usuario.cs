using System.ComponentModel.DataAnnotations;


namespace Usuario.Dominio.Entidades
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

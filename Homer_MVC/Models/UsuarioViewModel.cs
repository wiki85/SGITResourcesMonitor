using System.Collections.Generic;

namespace Homer_MVC.Models
{
    public class usuario
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Empresa { get; set; }
        public string Privilegios { get; set; }
    }
}
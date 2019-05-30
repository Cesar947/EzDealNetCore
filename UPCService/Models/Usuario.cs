using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace UPCService.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string UrlContacto { get; set; }
        public string Telefono { get; set; }
        public Distrito Distrito {get; set;}
        public int Rol { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace UPCService.Models
{
    public class Reseña
    {
        public int codigoResena { get; set; }
        public Publicacion codigoPublicacion { get; set; }
        public Usuario codigoCliente { get; set; }
        public string contenido { get; set; }
        public float valoracion { get; set; } 
    }
}
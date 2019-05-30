using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace UPCService.Models
{
    public class Solicitud
    {
        public int Id { get; set; }
        public Publicacion Publicacion { get; set; }
        public Usuario Cliente { get; set; }
        public string Mensaje { get; set; }
    }
}
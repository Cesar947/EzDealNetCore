using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace UPCService.Models
{
    public class Publicacion
    {
        public int Id{ get; set; }

        public Usuario publicista { get; set; }

        public string titulo { get; set; }

        public string descripcion { get; set; }

        public int costoServicio { get; set; }

        public Servicio servicio { get; set; }

        public int estaHabilitado { get; set; }
    }
}
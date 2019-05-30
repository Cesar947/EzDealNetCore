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

        public Usuario Publicista { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public int CostoServicio { get; set; }

        public Servicio Servicio { get; set; }

        public int EstaHabilitado { get; set; }
    }
}
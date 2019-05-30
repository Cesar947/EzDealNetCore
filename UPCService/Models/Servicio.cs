using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace UPCService.Models
{
    public class Servicio
    {
         public int codigoServicio { get; set; }
         
        public string nombre { get; set; }

        public string descripcion { get; set; }
        
        
        
    }
}
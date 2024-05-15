using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUni.Entidades
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; } // PK

        [DisplayName("Nombre de la carrera")]
        
        public string Nombre { get; set; }

        // Foreign Key
        public int UniversidadId { get; set; }

        [DisplayName("Universidad")]
        public Universidad? Universidad { get; set; }
    }
}

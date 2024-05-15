using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppUni.Entidades
{
    public class Universidad
    {
        [Key]
        public int Id { get; set; } // PK

        [DisplayName("Nombre de la universidad")]       
        public string Nombre { get; set; }

        [DisplayName("Ubicación")]
        public string Ubicacion { get; set; }

        // Relación uno a muchos con la clase Carrera
        public List<Carrera>? Carreras { get; set; }

    }
}

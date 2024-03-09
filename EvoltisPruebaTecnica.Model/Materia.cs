using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model
{
    public class Materia : GenericModel
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Duracion { get; set; }

        public  virtual List<AlumnoMateria>? AlumnoMateria { get; set; }
        public virtual List<ProfesorMateria>? ProfesorMaterias { get; set; }
    }
}

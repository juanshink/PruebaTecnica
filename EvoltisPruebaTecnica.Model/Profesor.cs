using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model
{
    public class Profesor: GenericModel
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Especialidad { get; set; }
        public virtual List<ProfesorMateria>? ProfesorMaterias { get; set; }
    }
}

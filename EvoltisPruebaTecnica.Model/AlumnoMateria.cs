using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model
{
    public class AlumnoMateria : GenericModel
    {

        public int AlumnoId { get; set; }
        public virtual Alumno? Alumno { get; set; }

        public int MateriaId { get; set; }
        public virtual Materia? Materia { get; set; }
    }
}
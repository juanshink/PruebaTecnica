using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model.DTOs
{
    public class AlumnoMateriaDTO : GenericModelDTO
    {

        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }


        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
    }
}

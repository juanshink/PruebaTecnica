using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model.DTOs
{
    public class ProfesorMateriaDTO : GenericModelDTO
    {
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
    }
}

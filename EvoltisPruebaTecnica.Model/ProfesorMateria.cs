using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model
{
    public class ProfesorMateria : GenericModel
    {
        public int ProfesorId { get; set; }
        public virtual Profesor? Profesor { get; set; }

        public int MateriaId { get; set; }
        public virtual Materia? Materia { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model.DTOs
{
    public class MateriaDTO : GenericModelDTO
    { 
        public string nombre { get; set; }
        public string duracion { get; set; }
    }
}

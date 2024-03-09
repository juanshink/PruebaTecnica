using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model.DTOs
{
    public class AlumnoDTO : GenericModelDTO
    {
        public string? NombreCompleto { get; set; }
        public int Dni { get; set; }
        public DateOnly FechaNac { get; set; }
    }
}

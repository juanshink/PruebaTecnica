using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Model
{
    public abstract class GenericModel
    {
        
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool Deleted { get; set; }
    }
}

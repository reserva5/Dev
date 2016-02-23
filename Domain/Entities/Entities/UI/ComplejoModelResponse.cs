using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UI
{
    public class ComplejoModelResponse : ModelHttpBase
    {
        //[Display(Name = "Inicio")]
        //public DateTime StartDate { get; set; }
        //[Display(Name = "Fin")]
        //public DateTime EndDate { get; set; }
        public IQueryable<Complejo> Complejos { get; set; }
    }
}
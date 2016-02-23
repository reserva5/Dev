using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UI
{
    public class ReservaModelResponse : ModelHttpBase
    {
        //[Display(Name = "Inicio")]
        //public DateTime StartDate { get; set; }
        //[Display(Name = "Fin")]
        //public DateTime EndDate { get; set; }
        public IQueryable<Reserva> Reservas { get; set; }
    }
}


/*

{
    HttpStatusDesc : 'OK'
    HttpStatus Code : 200

    StartDate : '2015-02-15',
    EndDate : '2015-03-15',
    Reservas : [
        {
            Id : ..
            UserId : ..
            ..
        }
    ]
}




*/
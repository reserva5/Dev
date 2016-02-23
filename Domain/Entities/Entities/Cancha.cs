using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cancha : IObjectWithState
    {
        public long CanchaId { get; set; }
        public long ComplejoId { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }
        [Display(Name = "Jugadores")]
        public int Jugadores { get; set; }

        public State State { get; set; }
    }
}

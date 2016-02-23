using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reserva : IObjectWithState
    {
        public Guid ReservaId { get; set; }
        public long ComplejoId { get; set; }
        public int CanchaId { get; set; }
        public Guid SolicitudId { get; set; }
        public int? MotivoEstadoId { get; set; }
        public char Estado { get; set; }
        [Display(Name = "Fecha / Hora")]
        public DateTime? FechaHora { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        public State State { get; set; }
    }
}

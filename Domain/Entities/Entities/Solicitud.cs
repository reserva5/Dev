using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Solicitud : IObjectWithState
    {
        public Guid SolicitudId { get; set; }
        public long ComplejoId { get; set; }
        public int CanchaId { get; set; }
        public long UsuarioId { get; set; }
        public long? UsuarioAdminId { get; set; }
        public int? MotivoEstadoId { get; set; }
        public char Estado { get; set; }
        [Display(Name = "Fecha / Hora")]
        public DateTime FechaHora { get; set; }

        public State State { get; set; }
    }
}

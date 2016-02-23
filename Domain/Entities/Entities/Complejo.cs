using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Complejo : IObjectWithState
    {
        public long ComplejoId { get; set; }
        public long? Latitud { get; set; }
        public long? Longitud { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
        [Display(Name = "Dirección")]
        public string Dir_Linea_1  { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Email Valido")]
        public bool Email_Valido { get; set; }
        [Display(Name = "Telefono 1")]
        public string Tel_1 { get; set; }
        [Display(Name = "Telefono 2")]
        public string Tel_2 { get; set; }
        [Display(Name = "Logo")]
        public byte[] Logo { get; set; }

        public State State { get; set; }
    }
}

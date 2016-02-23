using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReservasApp.Models
{
    public class ComplejoModel
    {
        
    }

    public class ComplejoModels
    {
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
        public IQueryable<Complejo> Complejos { get; set; }
    }
}
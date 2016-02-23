using Entities.UI;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReservasApp.Models;

namespace ReservasApp.Controllers
{
    [RoutePrefix("api/Complejos")]
    public class ComplejosController : ApiController
    {
        private readonly IComplejoService complejoService;

        public ComplejosController(IComplejoService complejoService)
        {
            this.complejoService = complejoService;
        }


        //llamada REST ejemplo: www.vpVacations/Complejo/ByDate/2015-02-15/2015-03-15

        [Route("ByDate/{startDate}/{endDate}")]
        public IQueryable<ComplejoModelResponse> GetAllComplejos(DateTime startDate, DateTime endDate)
        {
            return complejoService.GetAllComplejos(); // (startDate, endDate);
        }

    }
}

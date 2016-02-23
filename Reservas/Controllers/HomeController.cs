using Entities;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reservas.Models;

namespace Reservas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComplejoService service;

        public HomeController(IComplejoService service)
        {
            this.service = service;
        }

        // GET: Home
        public ActionResult Index()
        {
            ComplejoModels model = new ComplejoModels();
            //model.Complejos = service.GetAllComplejos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //TODO buscar en el servicio el complejo
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Complejo entity)
        {
            //TODO guardar en el servicio
            return View();
        }
    }
}
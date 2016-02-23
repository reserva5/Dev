using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;
using Entities.UI;
using System.Data.Entity;

namespace ServiceLayer
{
    public class CanchaService : ICanchaService
    {
        private readonly ICanchaRepository canchaRepository;

        public CanchaService(ICanchaRepository canchaRepository)
        {
            this.canchaRepository = canchaRepository;
        }

        public IQueryable<Cancha> GetAllCanchas()
        {
            return canchaRepository.All;
        }

        //public IQueryable<ReservaModelResponse> GetAllReservasByDate(DateTime startDate, DateTime endDate)
        //{
        //    try
        //    {
        //        var reservas = from reserva in canchaRepository.All
        //                        where DbFunctions.DiffDays(startDate, reserva.StartDate) >= 0
        //                        && DbFunctions.DiffDays(endDate, reserva.EndDate) <= 0
        //                        select reserva;

        //        List<ReservaModelResponse> list = new List<ReservaModelResponse>();
        //        list.Add(new ReservaModelResponse()
        //        {
        //            HttpStatusCode = 200,
        //            HttpStatusDesc = "Ok",
        //            StartDate = startDate,
        //            EndDate = endDate,
        //            Reservas = reservas
        //        });
        //        return list.AsQueryable();
        //    }
        //    catch (Exception ex)
        //    {
        //        List<ReservaModelResponse> list = new List<ReservaModelResponse>();
        //        list.Add(new ReservaModelResponse()
        //        {
        //            HttpStatusCode = 400,
        //            HttpStatusDesc = "Bad Request",
        //            StartDate = startDate,
        //            EndDate = endDate,
        //            Reservas = new List<Reserva>().AsQueryable()
        //        });
        //        return list.AsQueryable();


        //    }
        //}

    }
}

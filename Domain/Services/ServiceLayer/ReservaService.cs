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
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository reservaRepository;

        public ReservaService(IReservaRepository reservaRepositoy)
        {
            this.reservaRepository = reservaRepositoy;
        }

        public IQueryable<Reserva> GetAllReservas()
        {
            return reservaRepository.All;
        }

        public IQueryable<ReservaModelResponse> GetAllReservasByDate(DateTime fechaHora)
        {
            try
            {
                var reservas = from reserva in reservaRepository.All
                                where reserva.FechaHora == fechaHora
                                select reserva;

                List<ReservaModelResponse> list = new List<ReservaModelResponse>();
                list.Add(new ReservaModelResponse()
                {
                    HttpStatusCode = 200,
                    HttpStatusDesc = "Ok",
                    Reservas = reservas
                });
                return list.AsQueryable();
            }
            catch (Exception ex)
            {
                List<ReservaModelResponse> list = new List<ReservaModelResponse>();
                list.Add(new ReservaModelResponse()
                {
                    HttpStatusCode = 400,
                    HttpStatusDesc = "Bad Request",
                    Reservas = new List<Reserva>().AsQueryable(),
                    Exception = ex
                });
                return list.AsQueryable();


            }
        }

    }
}

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
    public class ComplejoService : IComplejoService
    {
        private readonly IComplejoRepository complejoRepository;

        public ComplejoService(IComplejoRepository complejoRepository)
        {
            this.complejoRepository = complejoRepository;
        }

        public IQueryable<ComplejoModelResponse> GetAllComplejos()
        {
            try
            {
                var complejos = from complejo in complejoRepository.All
                                select complejo;

                List<ComplejoModelResponse> list = new List<ComplejoModelResponse>();
                list.Add(new ComplejoModelResponse()
                {
                    HttpStatusCode = 200,
                    HttpStatusDesc = "Ok",
                    Complejos = complejos
                });
                return list.AsQueryable();
            }
            catch (Exception ex)
            {
                List<ComplejoModelResponse> list = new List<ComplejoModelResponse>();
                list.Add(new ComplejoModelResponse()
                {
                    HttpStatusCode = 400,
                    HttpStatusDesc = "Bad Request",
                    Complejos = new List<Complejo>().AsQueryable(),
                    Exception = ex
                });

                return list.AsQueryable();
            }
        }
    }
}

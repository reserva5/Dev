using Entities;
using Entities.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IComplejoService
    {

        IQueryable<ComplejoModelResponse> GetAllComplejos();
        //IQueryable<ComplejoModelResponse> GetAllComplejosByDate(DateTime startDate, DateTime endDate);
    }
}

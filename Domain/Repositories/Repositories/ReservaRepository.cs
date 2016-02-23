using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataLayer.DbContext;
using BaseDataLayer;
using System.Data.Entity;

namespace Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IReservasContext _context;

        public ReservaRepository(IUnitOfWork<IReservasContext> uow)
        {
            _context = uow.Context;
        }


        public IQueryable<Reserva> All
        {
            get
            {
               return _context.Reservas;
            }
        }

        public IQueryable<Reserva> AllIncluding(params Expression<Func<Reserva, object>>[] includedProperties)
        {
            IQueryable<Reserva> query = _context.Reservas;
            foreach(var includeProperty in includedProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            Reserva reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SetDeleted(reserva);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Reserva Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Reserva entity)
        {
            if(entity.ReservaId == null)
            {
                _context.Reservas.Add(entity);
                _context.SetAdded(entity);
            }
            else
            {
                _context.SetModified(entity);
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

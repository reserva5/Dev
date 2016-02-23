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
    public class ComplejoRepository : IComplejoRepository
    {
        private readonly IReservasContext _context;

        public ComplejoRepository(IUnitOfWork<IReservasContext> uow)
        {
            _context = uow.Context;
        }


        public IQueryable<Complejo> All
        {
            get
            {
               return _context.Complejos;
            }
        }

        public IQueryable<Complejo> AllIncluding(params Expression<Func<Complejo, object>>[] includedProperties)
        {
            IQueryable<Complejo> query = _context.Complejos;
            foreach(var includeProperty in includedProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            Complejo complejo = _context.Complejos.Find(id);
            if (complejo != null)
            {
                _context.Complejos.Remove(complejo);
                _context.SetDeleted(complejo);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Complejo Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Complejo entity)
        {
            if(entity.ComplejoId == 0)
            {
                _context.Complejos.Add(entity);
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

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
    public class CanchaRepository : ICanchaRepository
    {
        private readonly IReservasContext _context;

        public CanchaRepository(IUnitOfWork<IReservasContext> uow)
        {
            _context = uow.Context;
        }


        public IQueryable<Cancha> All
        {
            get
            {
               return _context.Canchas;
            }
        }

        public IQueryable<Cancha> AllIncluding(params Expression<Func<Cancha, object>>[] includedProperties)
        {
            IQueryable<Cancha> query = _context.Canchas;
            foreach(var includeProperty in includedProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            Cancha cancha = _context.Canchas.Find(id);
            if (cancha != null)
            {
                _context.Canchas.Remove(cancha);
                _context.SetDeleted(cancha);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Cancha Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Cancha entity)
        {
            if(entity.CanchaId == 0)
            {
                _context.Canchas.Add(entity);
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

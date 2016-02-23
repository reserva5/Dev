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
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly IReservasContext _context;

        public SolicitudRepository(IUnitOfWork<IReservasContext> uow)
        {
            _context = uow.Context;
        }


        public IQueryable<Solicitud> All
        {
            get
            {
               return _context.Solicitudes;
            }
        }

        public IQueryable<Solicitud> AllIncluding(params Expression<Func<Solicitud, object>>[] includedProperties)
        {
            IQueryable<Solicitud> query = _context.Solicitudes;
            foreach(var includeProperty in includedProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            Solicitud solicitud = _context.Solicitudes.Find(id);
            if (solicitud != null)
            {
                _context.Solicitudes.Remove(solicitud);
                _context.SetDeleted(solicitud);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Solicitud Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Solicitud entity)
        {
            if(entity.SolicitudId == null)
            {
                _context.Solicitudes.Add(entity);
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

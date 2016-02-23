using BaseDataLayer;
using DataLayer.Mappings;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DbContext
{
    public interface IReservasContext : IContext
    {
        IDbSet<Reserva> Reservas { get; }
        IDbSet<Complejo> Complejos { get; }
        IDbSet<Cancha> Canchas { get; }
        IDbSet<Solicitud> Solicitudes { get; }
    }

    

    public class ReservasContext : ReservasBaseContext<ReservasContext>, IReservasContext
    {

        public IDbSet<Reserva> Reservas { get; set; }
        public IDbSet<Complejo> Complejos { get; set; }
        public IDbSet<Cancha> Canchas { get; set; }
        public IDbSet<Solicitud> Solicitudes { get; set; }

        public void SetAdded(object entity)
        {
            throw new NotImplementedException();
        }

        public void SetDeleted(object entity)
        {
            throw new NotImplementedException();
        }

        public void SetModified(object entity)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Reserva>(new ReservaMap());
            modelBuilder.Configurations.Add<Complejo>(new ComplejoMap());
            modelBuilder.Configurations.Add<Cancha>(new CanchaMap());
            modelBuilder.Configurations.Add<Solicitud>(new SolicitudMap());
        }
    }
}

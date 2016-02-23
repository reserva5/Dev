using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mappings
{
    public class ReservaMap : EntityTypeConfiguration<Reserva>
    {
        public ReservaMap()
        {
            HasKey(t => t.ReservaId);

            Property(t => t.ReservaId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.ComplejoId)
                .IsRequired();

            Property(t => t.CanchaId)
                .IsRequired();

            Property(t => t.FechaHora)
                .IsRequired();

            Property(t => t.Estado)
                .IsRequired();

            ToTable("reservas");
            Property(t => t.ReservaId).HasColumnName("RESERVA_ID");
            Property(t => t.ComplejoId).HasColumnName("COMPLEJO_ID");
            Property(t => t.CanchaId).HasColumnName("CANCHA_ID");
            Property(t => t.FechaHora).HasColumnName("FECHA_HORA");
            Property(t => t.SolicitudId).HasColumnName("SOLICITUD_ID");
            Property(t => t.Estado).HasColumnName("ESTADO");
            Property(t => t.MotivoEstadoId).HasColumnName("MOTIVO_ESTADO");
            Property(t => t.Nombre).HasColumnName("NOMBRE");
            Property(t => t.Apellido).HasColumnName("APELLIDO");
            Property(t => t.Telefono).HasColumnName("TELEFONO");

            Ignore(t => t.State);
        }
    }
}

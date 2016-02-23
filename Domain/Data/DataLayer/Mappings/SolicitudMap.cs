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
    public class SolicitudMap : EntityTypeConfiguration<Solicitud>
    {
        public SolicitudMap()
        {
            HasKey(t => t.SolicitudId);

            Property(t => t.SolicitudId)
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

            Property(t => t.UsuarioId)
                .IsRequired();

            ToTable("solicitudes");
            Property(t => t.SolicitudId).HasColumnName("SOLICITUD_ID");
            Property(t => t.ComplejoId).HasColumnName("COMPLEJO_ID");
            Property(t => t.CanchaId).HasColumnName("CANCHA_ID");
            Property(t => t.FechaHora).HasColumnName("FECHA_HORA");
            Property(t => t.Estado).HasColumnName("ESTADO");
            Property(t => t.MotivoEstadoId).HasColumnName("MOTIVO_ESTADO");
            Property(t => t.UsuarioId).HasColumnName("USUARIO_ID");
            Property(t => t.UsuarioAdminId).HasColumnName("USUARIO_ADMIN_ID");

            Ignore(t => t.State);
        }
    }
}

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
    public class CanchaMap : EntityTypeConfiguration<Cancha>
    {
        public CanchaMap()
        {
            HasKey(t => t.CanchaId);

            Property(t => t.CanchaId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.ComplejoId)
                .IsRequired();

            Property(t => t.Numero)
                .IsRequired();

            Property(t => t.Jugadores)
                .IsRequired();

            
            ToTable("canchas");
            Property(t => t.CanchaId).HasColumnName("CANCHA_ID");
            Property(t => t.ComplejoId).HasColumnName("COMPLEJO_ID");
            Property(t => t.Numero).HasColumnName("NUMERO");
            Property(t => t.Jugadores).HasColumnName("JUGADORES");

            Ignore(t => t.State);
        }
    }
}

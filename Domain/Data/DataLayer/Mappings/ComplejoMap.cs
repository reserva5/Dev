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
    public class ComplejoMap : EntityTypeConfiguration<Complejo>
    {
        public ComplejoMap()
        {
            HasKey(t => t.ComplejoId);

            Property(t => t.ComplejoId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Ciudad)
                .HasMaxLength(50);

            Property(t => t.Dir_Linea_1)
                .HasMaxLength(100);

            Property(t => t.Tel_1)
                .HasMaxLength(15);

            ToTable("complejos");
            Property(t => t.ComplejoId).HasColumnName("COMPLEJO_ID");
            Property(t => t.Nombre).HasColumnName("NOMBRE");
            Property(t => t.Ciudad).HasColumnName("CIUDAD");
            Property(t => t.Dir_Linea_1).HasColumnName("DIR_LINEA_1");
            Property(t => t.Latitud).HasColumnName("LATITUD");
            Property(t => t.Longitud).HasColumnName("LONGITUD");
            Property(t => t.Email).HasColumnName("EMAIL");
            Property(t => t.Email_Valido).HasColumnName("EMAIL_VALIDO");
            Property(t => t.Tel_1).HasColumnName("TEL_1");
            Property(t => t.Tel_2).HasColumnName("TEL_2");
            Property(t => t.Logo).HasColumnName("LOGO");

            Ignore(t => t.State);
        }
    }
}

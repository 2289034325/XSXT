


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TCangkuMap : EntityTypeConfiguration<TCangku>
    {
        public TCangkuMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            this.Property(t => t.mingcheng)
                .IsRequired()
                .HasMaxLength(10);


            this.Property(t => t.dizhi)
                .IsRequired()
                .HasMaxLength(50);


            this.Property(t => t.lianxiren)
                .IsRequired()
                .HasMaxLength(5);


            this.Property(t => t.dianhua)
                .IsRequired()
                .HasMaxLength(11);


            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);


            this.Property(t => t.jiqima)
                .IsRequired()
                .HasMaxLength(16);


            // Table & Column Mappings

            this.ToTable("TCangku");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.ppsid).HasColumnName("ppsid");

            this.Property(t => t.mingcheng).HasColumnName("mingcheng");

            this.Property(t => t.dizhi).HasColumnName("dizhi");

            this.Property(t => t.lianxiren).HasColumnName("lianxiren");

            this.Property(t => t.dianhua).HasColumnName("dianhua");

            this.Property(t => t.beizhu).HasColumnName("beizhu");

            this.Property(t => t.jiqima).HasColumnName("jiqima");

            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");

            this.Property(t => t.charushijian).HasColumnName("charushijian");

            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");


            // Relationships

            this.HasRequired(t => t.TPinpaishang)

                .WithMany(t => t.TCangkus)

                .HasForeignKey(d => d.ppsid);

            this.HasRequired(t => t.TUser)

                .WithMany(t => t.TCangkus)

                .HasForeignKey(d => d.caozuorenid);



        }
    }
}

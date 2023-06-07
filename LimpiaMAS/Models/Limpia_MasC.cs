using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LimpiaMAS.Models;

public partial class Limpia_MasC : DbContext
{
    public Limpia_MasC()
    {
    }

    public Limpia_MasC(DbContextOptions<Limpia_MasC> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAdmin> TbAdmins { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDisponibilidad> TbDisponibilidads { get; set; }

    public virtual DbSet<TbLimpiador> TbLimpiadors { get; set; }

    public virtual DbSet<TbServicio> TbServicios { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=RYZEN-PC\\SQLEXPRESS;Initial Catalog=LIMPIA_MAS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdmin>(entity =>
        {
            entity.HasKey(e => e.UsrAdm).HasName("PK__TB_ADMIN__CEA0CDA5422D3C7B");

            entity.ToTable("TB_ADMIN");

            entity.Property(e => e.UsrAdm)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USR_ADM");
            entity.Property(e => e.PwdAdm)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PWD_ADM");
        });

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.IdCli).HasName("PK__TB_CLIEN__2BF8836DDC483014");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.IdCli)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_CLI");
            entity.Property(e => e.ApeCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APE_CLI");
            entity.Property(e => e.DirCli)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("DIR_CLI");
            entity.Property(e => e.NomCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_CLI");
            entity.Property(e => e.Pwd)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PWD");
            entity.Property(e => e.TelCli)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TEL_CLI");
            entity.Property(e => e.Usr)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USR");
        });

        modelBuilder.Entity<TbDisponibilidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TB_DISPO__3214EC27C17D7DC3");

            entity.ToTable("TB_DISPONIBILIDAD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FecDis)
                .HasColumnType("date")
                .HasColumnName("FEC_DIS");
            entity.Property(e => e.IdLimp)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_LIMP");
            entity.Property(e => e.TDone).HasColumnName("T_DONE");
            entity.Property(e => e.TStart).HasColumnName("T_START");

            entity.HasOne(d => d.IdLimpNavigation).WithMany(p => p.TbDisponibilidads)
                .HasForeignKey(d => d.IdLimp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DISPON__ID_LI__5CD6CB2B");
        });

        modelBuilder.Entity<TbLimpiador>(entity =>
        {
            entity.HasKey(e => e.IdLimp).HasName("PK__TB_LIMPI__9BCD0B39094FD90C");

            entity.ToTable("TB_LIMPIADOR");

            entity.Property(e => e.IdLimp)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_LIMP");
            entity.Property(e => e.ApeLimp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APE_LIMP");
            entity.Property(e => e.DirLimp)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("DIR_LIMP");
            entity.Property(e => e.DisLimp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DIS_LIMP");
            entity.Property(e => e.DistrLimp)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DISTR_LIMP");
            entity.Property(e => e.FotLimp).HasColumnName("FOT_LIMP");
            entity.Property(e => e.GenLimp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GEN_LIMP");
            entity.Property(e => e.NomLimp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_LIMP");
            entity.Property(e => e.Pwd)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PWD");
            entity.Property(e => e.ServLimp).HasColumnName("SERV_LIMP");
            entity.Property(e => e.TarLimp)
                .HasColumnType("money")
                .HasColumnName("TAR_LIMP");
            entity.Property(e => e.TelLimp)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TEL_LIMP");
            entity.Property(e => e.Usr)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USR");
        });

        modelBuilder.Entity<TbServicio>(entity =>
        {
            entity.HasKey(e => e.IdServ).HasName("PK__TB_SERVI__F5FF1C93309E230E");

            entity.ToTable("TB_SERVICIO");

            entity.Property(e => e.IdServ)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_SERV");
            entity.Property(e => e.CatServ)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CAT_SERV");
            entity.Property(e => e.DurServ).HasColumnName("DUR_SERV");
            entity.Property(e => e.FecServ)
                .HasColumnType("date")
                .HasColumnName("FEC_SERV");
            entity.Property(e => e.IdCli)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_CLI");
            entity.Property(e => e.IdLimp)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_LIMP");
            entity.Property(e => e.PreServ)
                .HasColumnType("money")
                .HasColumnName("PRE_SERV");

            entity.HasOne(d => d.IdCliNavigation).WithMany(p => p.TbServicios)
                .HasForeignKey(d => d.IdCli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_SERVIC__ID_CL__4F7CD00D");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.IdUsr).HasName("PK__TB_USER__2A8C692A8BD4D9C7");

            entity.ToTable("TB_USER");

            entity.Property(e => e.IdUsr)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_USR");
            entity.Property(e => e.Ape)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APE");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM");
            entity.Property(e => e.Pwd)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PWD");
            entity.Property(e => e.Usr)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USR");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

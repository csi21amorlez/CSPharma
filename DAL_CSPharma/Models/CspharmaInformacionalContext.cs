using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL_CSPharma.Models;

public partial class CspharmaInformacionalContext : DbContext
{
    public CspharmaInformacionalContext()
    {
    }

    public CspharmaInformacionalContext(DbContextOptions<CspharmaInformacionalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DlkCatAccEmpleado> DlkCatAccEmpleados { get; set; }

    public virtual DbSet<TdcCatEstadosDevolucionPedido> TdcCatEstadosDevolucionPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosEnvioPedido> TdcCatEstadosEnvioPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedidos { get; set; }

    public virtual DbSet<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=cspharma_informacional;User Id=postgres;Password=root123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DlkCatAccEmpleado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dlk_cat_acc_empleado", "dlk_informacional", tb => tb.HasComment("Tabla de la base de datos \"dlk_informacional\" la cual contendra la informacion de los usuarios registrados en nuestra aplicacion web "));

            entity.Property(e => e.ClaveEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("clave_empleado ");
            entity.Property(e => e.CodEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("cod_empleado ");
            entity.Property(e => e.MdDate).HasColumnName("md_date ");
            entity.Property(e => e.MdUidd)
                .HasColumnType("character varying")
                .HasColumnName("md_uidd ");
            entity.Property(e => e.NivelAccesoEmpleado).HasColumnName("nivel_acceso_empleado ");
        });

        modelBuilder.Entity<TdcCatEstadosDevolucionPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_cat_estados_devolucion_pedido_pkey");

            entity.ToTable("tdc_cat_estados_devolucion_pedido", "dwh_torrecontrol");

            entity.HasIndex(e => e.CodEstadoDevolucion, "unique_cod_estado_devolucion").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodEstadoDevolucion)
                .HasMaxLength(300)
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.DesEstadoDevolucion)
                .HasMaxLength(300)
                .HasColumnName("des_estado_devolucion");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasMaxLength(300)
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosEnvioPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tdc_cat_estados_envio_pedido");

            entity.ToTable("tdc_cat_estados_envio_pedido", "dwh_torrecontrol");

            entity.HasIndex(e => e.CodEstadoEnvio, "unique_cod_estado_envio").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodEstadoEnvio)
                .HasMaxLength(300)
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.DesEstadoEnvio)
                .HasMaxLength(300)
                .HasColumnName("des_estado_envio");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasMaxLength(300)
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosPagoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_cat_estados_pago_pedido_pkey");

            entity.ToTable("tdc_cat_estados_pago_pedido", "dwh_torrecontrol");

            entity.HasIndex(e => e.CodEstadoPago, "unique_cod_estado_pago").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodEstadoPago)
                .HasMaxLength(300)
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.DesEstadoPago)
                .HasColumnType("character varying")
                .HasColumnName("des_estado_pago");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasMaxLength(300)
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcTchEstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tdc_tch_estado_pedidos");

            entity.ToTable("tdc_tch_estado_pedidos", "dwh_torrecontrol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodBarrio)
                .HasMaxLength(300)
                .HasColumnName("cod_barrio");
            entity.Property(e => e.CodEstadoDevolucion)
                .HasMaxLength(300)
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.CodEstadoEnvio)
                .HasMaxLength(300)
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.CodEstadoPago)
                .HasMaxLength(300)
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.CodLinea)
                .HasMaxLength(300)
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodMunicipio)
                .HasMaxLength(300)
                .HasColumnName("cod_municipio");
            entity.Property(e => e.CodPedido)
                .HasMaxLength(300)
                .HasColumnName("cod_pedido");
            entity.Property(e => e.CodProvincia)
                .HasMaxLength(300)
                .HasColumnName("cod_provincia");
            entity.Property(e => e.MdDate).HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasMaxLength(300)
                .HasColumnName("md_uuid");

            entity.HasOne(d => d.CodEstadoDevolucionNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasPrincipalKey(p => p.CodEstadoDevolucion)
                .HasForeignKey(d => d.CodEstadoDevolucion)
                .HasConstraintName("fk_estadoDevolucion_estadoPedidos");

            entity.HasOne(d => d.CodEstadoEnvioNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasPrincipalKey(p => p.CodEstadoEnvio)
                .HasForeignKey(d => d.CodEstadoEnvio)
                .HasConstraintName("fk_estadoEnvio_estadoPedidos");

            entity.HasOne(d => d.CodEstadoPagoNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasPrincipalKey(p => p.CodEstadoPago)
                .HasForeignKey(d => d.CodEstadoPago)
                .HasConstraintName("fk_estadoPago_estadoPedidos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

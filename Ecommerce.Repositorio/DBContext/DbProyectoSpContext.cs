using System;
using System.Collections.Generic;
using Ecommerce.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repostorio.DBContext;

public partial class DbProyectoSpContext : DbContext
{
    public DbProyectoSpContext()
    {
    }

    public DbProyectoSpContext(DbContextOptions<DbProyectoSpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Corte> Cortes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<EntregaSatelite> EntregaSatelites { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<InsumoEntrega> InsumoEntregas { get; set; }

    public virtual DbSet<InsumoProvedor> InsumoProvedors { get; set; }

    public virtual DbSet<Local> Locals { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<ProduccionCorte> ProduccionCortes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoLocal> ProductoLocals { get; set; }

    public virtual DbSet<Provedor> Provedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoVenta> TipoVenta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__categori__8A3D240C03509181");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.DescripcionCategoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcionCategoria");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PK__ciudad__AEA2A71BDCB746AC");

            entity.ToTable("ciudad");

            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCiudad");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__ciudad__idDepart__398D8EEE");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__cliente__885457EEDC444D02");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidoCliente");
            entity.Property(e => e.ClaveCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("claveCliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correoCliente");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccionCliente");
            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documentoCliente");
            entity.Property(e => e.FechaCliente)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCliente");
            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCliente");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK__cliente__idCiuda__45F365D3");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__compra__48B99DB748DD2027");

            entity.ToTable("compra");

            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.EstadoCompra)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estadoCompra");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCompra");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NumeroCompra)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numeroCompra");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__compra__idUsuari__6754599E");
        });

        modelBuilder.Entity<Corte>(entity =>
        {
            entity.HasKey(e => e.IdCorte).HasName("PK__corte__50CA900705812F90");

            entity.ToTable("corte");

            entity.Property(e => e.IdCorte).HasColumnName("idCorte");
            entity.Property(e => e.NombrePrendaCorte)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombrePrendaCorte");
            entity.Property(e => e.NumeroPiezasCorte).HasColumnName("numeroPiezasCorte");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__C225F98D721B243A");

            entity.ToTable("departamento");

            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreDepartamento");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__detalleC__62C252C13407F9AE");

            entity.ToTable("detalleCompra");

            entity.Property(e => e.IdDetalleCompra).HasColumnName("idDetalleCompra");
            entity.Property(e => e.CantidadCompra).HasColumnName("cantidadCompra");
            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");
            entity.Property(e => e.PrecioCompra)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioCompra");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__detalleCo__idCom__6D0D32F4");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdInsumo)
                .HasConstraintName("FK__detalleCo__idIns__6E01572D");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__detalleV__BFE2843FA766E256");

            entity.ToTable("detalleVenta");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");
            entity.Property(e => e.CantidadProductoVenta).HasColumnName("cantidadProductoVenta");
            entity.Property(e => e.IdProductoLocal).HasColumnName("idProductoLocal");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioVenta");

            entity.HasOne(d => d.IdProductoLocalNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProductoLocal)
                .HasConstraintName("FK__detalleVe__idPro__60A75C0F");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__detalleVe__idVen__5FB337D6");
        });

        modelBuilder.Entity<EntregaSatelite>(entity =>
        {
            entity.HasKey(e => e.IdEntregaSatelite).HasName("PK__entregaS__1872821FDD18CB5B");

            entity.ToTable("entregaSatelite");

            entity.Property(e => e.IdEntregaSatelite).HasColumnName("idEntregaSatelite");
            entity.Property(e => e.CantidadEntregaSatelite).HasColumnName("cantidadEntregaSatelite");
            entity.Property(e => e.FechaEntregaSatelite)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaEntregaSatelite");
            entity.Property(e => e.IdProduccion).HasColumnName("idProduccion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdProduccionNavigation).WithMany(p => p.EntregaSatelites)
                .HasForeignKey(d => d.IdProduccion)
                .HasConstraintName("FK__entregaSa__idPro__7C4F7684");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.EntregaSatelites)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__entregaSa__idUsu__7B5B524B");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("PK__insumo__215CA054CFDDBA21");

            entity.ToTable("insumo");

            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");
            entity.Property(e => e.CantidadInsumo).HasColumnName("cantidadInsumo");
            entity.Property(e => e.DescripcionInsumo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcionInsumo");
            entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");
            entity.Property(e => e.NombreInsumo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreInsumo");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.Insumos)
                .HasForeignKey(d => d.IdMaterial)
                .HasConstraintName("FK__insumo__idMateri__6A30C649");
        });

        modelBuilder.Entity<InsumoEntrega>(entity =>
        {
            entity.HasKey(e => e.IdInsumoEntrega).HasName("PK__insumoEn__5A1542D280DD7051");

            entity.ToTable("insumoEntrega");

            entity.Property(e => e.IdInsumoEntrega).HasColumnName("idInsumoEntrega");
            entity.Property(e => e.CantidadInsumoEntrega).HasColumnName("cantidadInsumoEntrega");
            entity.Property(e => e.EntregaSatelite).HasColumnName("entregaSatelite");
            entity.Property(e => e.FechaInsumoEntrega)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaInsumoEntrega");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.EntregaSateliteNavigation).WithMany(p => p.InsumoEntregas)
                .HasForeignKey(d => d.EntregaSatelite)
                .HasConstraintName("FK__insumoEnt__entre__01142BA1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.InsumoEntregas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__insumoEnt__idUsu__00200768");
        });

        modelBuilder.Entity<InsumoProvedor>(entity =>
        {
            entity.HasKey(e => e.IdInsumoProvedor).HasName("PK__insumoPr__6052F51BB9BEC1DA");

            entity.ToTable("insumoProvedor");

            entity.Property(e => e.IdInsumoProvedor).HasColumnName("idInsumoProvedor");
            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.InsumoProvedors)
                .HasForeignKey(d => d.IdInsumo)
                .HasConstraintName("FK__insumoPro__idIns__70DDC3D8");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.InsumoProvedors)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__insumoPro__idUsu__71D1E811");
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.IdLocal).HasName("PK__local__019B69F0FB35A7FB");

            entity.ToTable("local");

            entity.Property(e => e.IdLocal).HasColumnName("idLocal");
            entity.Property(e => e.DireccionLocal)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccionLocal");
            entity.Property(e => e.NombreLocal)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombreLocal");
            entity.Property(e => e.TelefonoLocal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefonoLocal");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("PK__material__6AC7E3EB883BDA98");

            entity.ToTable("material");

            entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");
            entity.Property(e => e.DescripcionMaterial)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("descripcionMaterial");
            entity.Property(e => e.NombreMaterial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreMaterial");
        });

        modelBuilder.Entity<ProduccionCorte>(entity =>
        {
            entity.HasKey(e => e.IdProduccionCorte).HasName("PK__producci__D52AA53CEF062F54");

            entity.ToTable("produccionCorte");

            entity.Property(e => e.IdProduccionCorte).HasColumnName("idProduccionCorte");
            entity.Property(e => e.CantidadCorte).HasColumnName("cantidadCorte");
            entity.Property(e => e.FechaCorte)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCorte");
            entity.Property(e => e.IdCorte).HasColumnName("idCorte");

            entity.HasOne(d => d.IdCorteNavigation).WithMany(p => p.ProduccionCortes)
                .HasForeignKey(d => d.IdCorte)
                .HasConstraintName("FK__produccio__idCor__778AC167");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__07F4A1320A44B83F");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigoProducto");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("descripcionProducto");
            entity.Property(e => e.EstadoProducto)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estadoProducto");
            entity.Property(e => e.FechaProducto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaProducto");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");
            entity.Property(e => e.ImagenProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagenProducto");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombreProducto");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__producto__idCate__5629CD9C");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMaterial)
                .HasConstraintName("FK__producto__idMate__5535A963");
        });

        modelBuilder.Entity<ProductoLocal>(entity =>
        {
            entity.HasKey(e => e.IdProductoLocal).HasName("PK__producto__98E424DE0005F52C");

            entity.ToTable("productoLocal");

            entity.Property(e => e.IdProductoLocal).HasColumnName("idProductoLocal");
            entity.Property(e => e.CantidadProductoLocal).HasColumnName("cantidadProductoLocal");
            entity.Property(e => e.FechaProductoLocal)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaProductoLocal");
            entity.Property(e => e.IdLocal).HasColumnName("idLocal");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.PrecioProductoLocal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("precioProductoLocal");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.ProductoLocals)
                .HasForeignKey(d => d.IdLocal)
                .HasConstraintName("FK__productoL__idLoc__5BE2A6F2");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoLocals)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__productoL__idPro__5AEE82B9");
        });

        modelBuilder.Entity<Provedor>(entity =>
        {
            entity.HasKey(e => e.IdProvedor).HasName("PK__provedor__E1EA3E859D01FBE8");

            entity.ToTable("provedor");

            entity.Property(e => e.IdProvedor).HasColumnName("idProvedor");
            entity.Property(e => e.DocumentoProvedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documentoProvedor");
            entity.Property(e => e.NombreProvedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreProvedor");
            entity.Property(e => e.TellProvedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tellProvedor");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__rol__3C872F768B055DE5");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<TipoVenta>(entity =>
        {
            entity.HasKey(e => e.IdTipoVenta).HasName("PK__tipoVent__955AAFEAFFF27644");

            entity.ToTable("tipoVenta");

            entity.Property(e => e.IdTipoVenta).HasColumnName("idTipoVenta");
            entity.Property(e => e.NombreTipoVenta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreTipoVenta");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__645723A656FE5750");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidoUsuario");
            entity.Property(e => e.ClaveUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("claveUsuario");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correoUsuario");
            entity.Property(e => e.DireccionUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccionUsuario");
            entity.Property(e => e.DocumentoUsuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documentoUsuario");
            entity.Property(e => e.EstadoUsuario)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estadoUsuario");
            entity.Property(e => e.FechaUsuario)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaUsuario");
            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.TellUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tellUsuario");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK__usuario__idCiuda__4222D4EF");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__usuario__idRol__4316F928");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__venta__077D5614A616F166");

            entity.ToTable("venta");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.EstadoVenta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estadoVenta");
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaVenta");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdTipoVenta).HasColumnName("idTipoVenta");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NumeroVenta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numeroVenta");
            entity.Property(e => e.ObservacionesVenta)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("observacionesVenta");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__venta__idCliente__4CA06362");

            entity.HasOne(d => d.IdTipoVentaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdTipoVenta)
                .HasConstraintName("FK__venta__idTipoVen__4AB81AF0");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__venta__idUsuario__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto1.DAL.Models
{
    public partial class TallerContext : DbContext
    {
        public TallerContext()
        {
        }

        public TallerContext(DbContextOptions<TallerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Concesionarios> Concesionarios { get; set; }
        public virtual DbSet<MecanicosCategorias> MecanicosCategorias { get; set; }
        public virtual DbSet<Propuestas> Propuestas { get; set; }
        public virtual DbSet<Reparaciones> Reparaciones { get; set; }
        public virtual DbSet<Repuestos> Repuestos { get; set; }
        public virtual DbSet<RepuestosReparacion> RepuestosReparacion { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=8889;user=root;password=root;database=taller");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.ToTable("categorias");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Concesionarios>(entity =>
            {
                entity.ToTable("concesionarios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<MecanicosCategorias>(entity =>
            {
                entity.ToTable("mecanicos_categorias");

                entity.HasIndex(e => e.CategoriaId)
                    .HasName("categoria_id");

                entity.HasIndex(e => e.MecanicoId)
                    .HasName("mecanico_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriaId)
                    .HasColumnName("categoria_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MecanicoId)
                    .HasColumnName("mecanico_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.MecanicosCategorias)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mecanicos_categorias_categorias");

                entity.HasOne(d => d.Mecanico)
                    .WithMany(p => p.MecanicosCategorias)
                    .HasForeignKey(d => d.MecanicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mecanicos_categorias_usuarios");
            });

            modelBuilder.Entity<Propuestas>(entity =>
            {
                entity.ToTable("propuestas");

                entity.HasIndex(e => e.ClienteId)
                    .HasName("cliente_id");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("usuario_id");

                entity.HasIndex(e => e.VehiculoId)
                    .HasName("vehiculo_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("cliente_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observaciones).HasColumnName("observaciones");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Validez)
                    .HasColumnName("validez")
                    .HasColumnType("date");

                entity.Property(e => e.VehiculoId)
                    .HasColumnName("vehiculo_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Propuestas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propuestas_ibfk_1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Propuestas)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propuestas_ibfk_2");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.Propuestas)
                    .HasForeignKey(d => d.VehiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_propuestas_vehiculos");
            });

            modelBuilder.Entity<Reparaciones>(entity =>
            {
                entity.ToTable("reparaciones");

                entity.HasIndex(e => e.ClienteId)
                    .HasName("cliente_id");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("usuario_id");

                entity.HasIndex(e => e.VehiculoId)
                    .HasName("vehiculo_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("cliente_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("enum('Finalizada','En proceso','Por atender')")
                    .HasDefaultValueSql("'Por atender'");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Observaciones).HasColumnName("observaciones");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VehiculoId)
                    .HasColumnName("vehiculo_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Reparaciones)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reparaciones_ibfk_1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Reparaciones)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reparacion_usuarios");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.Reparaciones)
                    .HasForeignKey(d => d.VehiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reparacion_vehiculos");
            });

            modelBuilder.Entity<Repuestos>(entity =>
            {
                entity.ToTable("repuestos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RepuestosReparacion>(entity =>
            {
                entity.ToTable("repuestos_reparacion");

                entity.HasIndex(e => e.ReparacionId)
                    .HasName("concesionario_id");

                entity.HasIndex(e => e.RepuestoId)
                    .HasName("repuesto_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReparacionId)
                    .HasColumnName("reparacion_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RepuestoId)
                    .HasColumnName("repuesto_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Reparacion)
                    .WithMany(p => p.RepuestosReparacion)
                    .HasForeignKey(d => d.ReparacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("repuestos_reparacion_ibfk_1");

                entity.HasOne(d => d.Repuesto)
                    .WithMany(p => p.RepuestosReparacion)
                    .HasForeignKey(d => d.RepuestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_repuestos_reparacion_repuestos");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.ConcesionarioId)
                    .HasName("concesionario_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellidos).HasColumnName("apellidos");

                entity.Property(e => e.ConcesionarioId)
                    .HasColumnName("concesionario_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("enum('jefe','mecanico_jefe','mecanico','ventas')")
                    .HasDefaultValueSql("'ventas'");

                entity.HasOne(d => d.Concesionario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.ConcesionarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_ibfk_2");
            });

            modelBuilder.Entity<Vehiculos>(entity =>
            {
                entity.ToTable("vehiculos");

                entity.HasIndex(e => e.CategoriaId)
                    .HasName("categoria_id");

                entity.HasIndex(e => e.ConcesionarioId)
                    .HasName("concesionario_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriaId)
                    .HasColumnName("categoria_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Combustible)
                    .IsRequired()
                    .HasColumnName("combustible")
                    .HasColumnType("enum('Diésel','Gasolina','Híbrido','Eléctrico')")
                    .HasDefaultValueSql("'Gasolina'");

                entity.Property(e => e.ConcesionarioId)
                    .HasColumnName("concesionario_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.Km)
                    .HasColumnName("km")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(50);

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasColumnName("matricula")
                    .HasMaxLength(50);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("modelo")
                    .HasMaxLength(50);

                entity.Property(e => e.Vendido).HasColumnName("vendido");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehiculos_ibfk_2");

                entity.HasOne(d => d.Concesionario)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.ConcesionarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehiculos_ibfk_1");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.ToTable("ventas");

                entity.HasIndex(e => e.ClienteId)
                    .HasName("cliente_id");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("usuario_id");

                entity.HasIndex(e => e.VehiculoId)
                    .HasName("vehiculo_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("cliente_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.FechaLimite)
                    .HasColumnName("fecha_limite")
                    .HasColumnType("date");

                entity.Property(e => e.Importe)
                    .HasColumnName("importe")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VehiculoId)
                    .HasColumnName("vehiculo_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_clientes");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_usuarios");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.VehiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_vehiculos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

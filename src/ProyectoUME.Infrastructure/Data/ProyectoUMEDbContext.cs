using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoUME.Core.Domain;

namespace ProyectoUME.Core
{
    public partial class ProyectoUMEDbContext : DbContext
    {
        public ProyectoUMEDbContext()
        {
        }

        public ProyectoUMEDbContext(DbContextOptions<ProyectoUMEDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Excusa> Excusa { get; set; }
        public virtual DbSet<Jornada> Jornada { get; set; }
        public virtual DbSet<ListaEmpleados> ListaEmpleados { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TurnoLaboral> TurnoLaboral { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("database=proyecto ume;server=localhost;port=3306;user id=root;password=");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Nit)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasColumnName("Nombre_Empresa")
                    .HasMaxLength(20);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Excusa>(entity =>
            {
                entity.HasKey(e => e.IdExcusa)
                    .HasName("PRIMARY");

                entity.ToTable("excusa");

                entity.HasIndex(e => e.RolIdRol)
                    .HasName("fk_Excusa_Rol1_idx");

                entity.Property(e => e.IdExcusa)
                    .HasColumnName("idExcusa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnexoEvidencia)
                    .IsRequired()
                    .HasColumnName("Anexo_Evidencia")
                    .HasMaxLength(2);

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Apellodo2)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre1)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre2)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RolIdRol)
                    .HasColumnName("Rol_idRol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.RolIdRolNavigation)
                    .WithMany(p => p.Excusa)
                    .HasForeignKey(d => d.RolIdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Excusa_Rol1");
            });

            modelBuilder.Entity<Jornada>(entity =>
            {
                entity.HasKey(e => e.IdJornada)
                    .HasName("PRIMARY");

                entity.ToTable("jornada");

                entity.Property(e => e.IdJornada)
                    .HasColumnName("idJornada")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Jornada1)
                    .HasColumnName("Jornada")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<ListaEmpleados>(entity =>
            {
                entity.HasKey(e => e.IdListaEmpleados)
                    .HasName("PRIMARY");

                entity.ToTable("lista_empleados");

                entity.HasIndex(e => e.ProyectoIdProyecto)
                    .HasName("fk_Lista_empleados_Proyecto1_idx");

                entity.Property(e => e.IdListaEmpleados)
                    .HasColumnName("idLista_empleados")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProyectoIdProyecto)
                    .HasColumnName("Proyecto_idProyecto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ProyectoIdProyectoNavigation)
                    .WithMany(p => p.ListaEmpleados)
                    .HasForeignKey(d => d.ProyectoIdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Lista_empleados_Proyecto1");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PRIMARY");

                entity.ToTable("permiso");

                entity.HasIndex(e => e.RolIdRol)
                    .HasName("fk_Permiso_Rol1_idx");

                entity.Property(e => e.IdPermiso)
                    .HasColumnName("idPermiso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RolIdRol)
                    .HasColumnName("Rol_idRol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.RolIdRolNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.RolIdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Permiso_Rol1");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PRIMARY");

                entity.ToTable("proyecto");

                entity.HasIndex(e => e.RolIdRol)
                    .HasName("fk_Proyecto_Rol1_idx");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("idProyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DireccionPoyecto)
                    .IsRequired()
                    .HasColumnName("Direccion_Poyecto")
                    .HasMaxLength(30);

                entity.Property(e => e.NumeroEmpleados)
                    .HasColumnName("Numero_Empleados")
                    .HasColumnType("int(3)");

                entity.Property(e => e.PersonaResponsable)
                    .IsRequired()
                    .HasColumnName("Persona_Responsable")
                    .HasMaxLength(45);

                entity.Property(e => e.RolIdRol)
                    .HasColumnName("Rol_idRol")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.RolIdRolNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.RolIdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Proyecto_Rol1");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasColumnName("Nombre_rol")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TurnoLaboral>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PRIMARY");

                entity.ToTable("turno_laboral");

                entity.HasIndex(e => e.JornadaIdJornada)
                    .HasName("fk_Turno_Laboral_Jornada1_idx");

                entity.HasIndex(e => e.RolIdRol)
                    .HasName("fk_Turno_Laboral_Rol1_idx");

                entity.Property(e => e.IdConsulta)
                    .HasColumnName("idConsulta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HoraIngreso).HasColumnName("Hora_Ingreso");

                entity.Property(e => e.HoraSalida).HasColumnName("Hora_Salida");

                entity.Property(e => e.JornadaIdJornada)
                    .HasColumnName("Jornada_idJornada")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RolIdRol)
                    .HasColumnName("Rol_idRol")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.JornadaIdJornadaNavigation)
                    .WithMany(p => p.TurnoLaboral)
                    .HasForeignKey(d => d.JornadaIdJornada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turno_Laboral_Jornada1");

                entity.HasOne(d => d.RolIdRolNavigation)
                    .WithMany(p => p.TurnoLaboral)
                    .HasForeignKey(d => d.RolIdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turno_Laboral_Rol1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.EmpresaNit)
                    .HasName("fk_Usuario_Empresa_idx");

                entity.HasIndex(e => e.RolIdRol)
                    .HasName("fk_Usuario_Rol1_idx");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Edad).HasColumnType("int(2)");

                entity.Property(e => e.EmpresaNit)
                    .HasColumnName("Empresa_NIT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("Primer_Apellido")
                    .HasMaxLength(25);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasColumnName("Primer_Nombre")
                    .HasMaxLength(10);

                entity.Property(e => e.RolIdRol)
                    .HasColumnName("Rol_idRol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasColumnName("Segundo_Apellido")
                    .HasMaxLength(25);

                entity.Property(e => e.SegundoNombre)
                    .IsRequired()
                    .HasColumnName("Segundo_Nombre")
                    .HasMaxLength(10);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.EmpresaNitNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.EmpresaNit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Empresa");

                entity.HasOne(d => d.RolIdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolIdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Rol1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

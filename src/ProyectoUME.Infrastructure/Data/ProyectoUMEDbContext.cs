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

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Excusas> Excusas { get; set; }
        public virtual DbSet<ListaEmpleados> ListaEmpleados { get; set; }
        public virtual DbSet<Obrero> Obrero { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Supervisor> Supervisor { get; set; }
        public virtual DbSet<TurnoLaboral> TurnoLaboral { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /* if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("database=proyecto;server=localhost;port=3306;user id=root;password=");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PRIMARY");

                entity.ToTable("administrador");

                entity.HasIndex(e => e.NumeroCedula)
                    .HasName("fk_usuario_administrador");

                entity.Property(e => e.IdAdministrador)
                    .HasColumnName("ID_Administrador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido1A)
                    .HasColumnName("Apellido1_A")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre1A)
                    .HasColumnName("Nombre1_A")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NumeroCedula)
                    .HasColumnName("Numero_cedula")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.NumeroCedulaNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.NumeroCedula)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_usuario_administrador");
            });

            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.HasKey(e => e.IdTramiteD)
                    .HasName("PRIMARY");

                entity.ToTable("documentos");

                entity.Property(e => e.IdTramiteD)
                    .HasColumnName("ID_tramite_D")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CertificadoArl)
                    .HasColumnName("Certificado_ARL")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CertificadoEps)
                    .HasColumnName("Certificado_Eps")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CertificadoPensiones)
                    .HasColumnName("Certificado_Pensiones")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CursoAltura)
                    .HasColumnName("Curso_Altura")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HojaVida)
                    .HasColumnName("Hoja_Vida")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Nit)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreEmpresa)
                    .HasColumnName("Nombre_Empresa")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono).HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Excusas>(entity =>
            {
                entity.HasKey(e => e.NumeroReferencia)
                    .HasName("PRIMARY");

                entity.ToTable("excusas");

                entity.HasIndex(e => e.IdAdministrador)
                    .HasName("fk_excusas_administrador");

                entity.HasIndex(e => e.IdObrero)
                    .HasName("fk_excusas_obrero");

                entity.Property(e => e.NumeroReferencia)
                    .HasColumnName("Numero_Referencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnexoEvidencia)
                    .HasColumnName("Anexo_Evidencia")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Apellido1Usuario)
                    .HasColumnName("Apellido1_Usuario")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Apellido2Usuario)
                    .HasColumnName("Apellido2_Usuario")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CodigoProyecto)
                    .HasColumnName("Codigo_Proyecto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdAdministrador)
                    .HasColumnName("ID_Administrador")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdObrero)
                    .HasColumnName("ID_Obrero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre1Usuario)
                    .HasColumnName("Nombre1_Usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre2Usuario)
                    .HasColumnName("Nombre2_Usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono).HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithMany(p => p.Excusas)
                    .HasForeignKey(d => d.IdAdministrador)
                    .HasConstraintName("fk_excusas_administrador");

                entity.HasOne(d => d.IdObreroNavigation)
                    .WithMany(p => p.Excusas)
                    .HasForeignKey(d => d.IdObrero)
                    .HasConstraintName("fk_excusas_obrero");
            });

            modelBuilder.Entity<ListaEmpleados>(entity =>
            {
                entity.HasKey(e => e.NConsulta)
                    .HasName("PRIMARY");

                entity.ToTable("lista_empleados");

                entity.HasIndex(e => e.CodigoProyecto)
                    .HasName("fk_listaP_proyecto");

                entity.Property(e => e.NConsulta)
                    .HasColumnName("N_consulta")
                    .HasColumnType("int(3)");

                entity.Property(e => e.CodigoProyecto)
                    .HasColumnName("Codigo_Proyecto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoProyectoNavigation)
                    .WithMany(p => p.ListaEmpleados)
                    .HasForeignKey(d => d.CodigoProyecto)
                    .HasConstraintName("fk_listaP_proyecto");
            });

            modelBuilder.Entity<Obrero>(entity =>
            {
                entity.HasKey(e => e.IdObrero)
                    .HasName("PRIMARY");

                entity.ToTable("obrero");

                entity.HasIndex(e => e.NumeroCedula)
                    .HasName("fk_usuario_obrero");

                entity.Property(e => e.IdObrero)
                    .HasColumnName("ID_Obrero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido1O)
                    .IsRequired()
                    .HasColumnName("Apellido1_O")
                    .HasMaxLength(15);

                entity.Property(e => e.Nombre1O)
                    .IsRequired()
                    .HasColumnName("Nombre1_O")
                    .HasMaxLength(10);

                entity.Property(e => e.NumeroCedula)
                    .HasColumnName("Numero_cedula")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.NumeroCedulaNavigation)
                    .WithMany(p => p.Obrero)
                    .HasForeignKey(d => d.NumeroCedula)
                    .HasConstraintName("fk_usuario_obrero");
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.NumeroReferenciaPermiso)
                    .HasName("PRIMARY");

                entity.ToTable("permisos");

                entity.HasIndex(e => e.IdObrero)
                    .HasName("fk_epermiso_obrero");

                entity.HasIndex(e => e.IdSupervisor)
                    .HasName("fk_permiso_supervisor");

                entity.Property(e => e.NumeroReferenciaPermiso)
                    .HasColumnName("Numero_Referencia_Permiso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido1Usuario)
                    .HasColumnName("Apellido1_Usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Apellido2Usuario)
                    .HasColumnName("Apellido2_Usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CodigoProyecto)
                    .HasColumnName("Codigo_Proyecto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdObrero)
                    .HasColumnName("ID_Obrero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSupervisor)
                    .HasColumnName("ID_supervisor")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre1Usuario)
                    .HasColumnName("Nombre1_Usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre2Usuario)
                    .HasColumnName("Nombre2_Usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono).HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdObreroNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.IdObrero)
                    .HasConstraintName("fk_epermiso_obrero");

                entity.HasOne(d => d.IdSupervisorNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.IdSupervisor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_permiso_supervisor");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.CodigoProyecto)
                    .HasName("PRIMARY");

                entity.ToTable("proyecto");

                entity.Property(e => e.CodigoProyecto)
                    .HasColumnName("Codigo_Proyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DireccionProyecto)
                    .HasColumnName("Direccion_Proyecto")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NumeroEmpleados)
                    .HasColumnName("Numero_Empleados")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PersonaResponsable)
                    .HasColumnName("Persona_Responsable")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.HasKey(e => e.IdSupervisor)
                    .HasName("PRIMARY");

                entity.ToTable("supervisor");

                entity.HasIndex(e => e.NumeroCedula)
                    .HasName("fk_usuario_supervisor");

                entity.Property(e => e.IdSupervisor)
                    .HasColumnName("ID_supervisor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido1S)
                    .HasColumnName("Apellido1_S")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre1S)
                    .HasColumnName("Nombre1_S")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumeroCedula)
                    .HasColumnName("Numero_cedula")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.NumeroCedulaNavigation)
                    .WithMany(p => p.Supervisor)
                    .HasForeignKey(d => d.NumeroCedula)
                    .HasConstraintName("fk_usuario_supervisor");
            });

            modelBuilder.Entity<TurnoLaboral>(entity =>
            {
                entity.HasKey(e => e.NumeroConsulta)
                    .HasName("PRIMARY");

                entity.ToTable("turno_laboral");

                entity.Property(e => e.NumeroConsulta)
                    .HasColumnName("Numero_consulta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoProyecto)
                    .HasColumnName("Codigo_Proyecto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdObrero)
                    .HasColumnName("ID_Obrero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Jornada)
                    .HasMaxLength(7)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.NumeroCedula)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.NumeroCedula)
                    .HasColumnName("Numero_Cedula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Edad)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdRol)
                    .HasColumnName("Id_rol")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrimerApellidoUsuario)
                    .HasColumnName("Primer_Apellido_Usuario")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrimerNombreUsuario)
                    .HasColumnName("Primer_Nombre_Usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SegundoApellidoUsuario)
                    .HasColumnName("Segundo_Apellido_Usuario")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SegundoNombreUsuario)
                    .HasColumnName("Segundo_Nombre_Usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono).HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

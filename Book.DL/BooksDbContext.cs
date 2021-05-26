namespace Book.DL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BooksDbContext : DbContext
    {
        public BooksDbContext()
            : base("name=BooksDbContext")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentRegister> StudentRegisters { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<DM_BOOKS> DM_BOOKS { get; set; }
        public virtual DbSet<DM_USER> DM_USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>()
                .Property(e => e.Fee)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DM_BOOKS>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}

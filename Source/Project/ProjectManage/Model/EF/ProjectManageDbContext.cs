namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectManageDbContext : DbContext
    {
        public ProjectManageDbContext()
            : base("name=ProjectManageDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Phase> Phases { get; set; }
        public virtual DbSet<PositionUser> PositionUsers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskType> TaskTypes { get; set; }
        public virtual DbSet<TypeOfWork> TypeOfWorks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phase>()
                .HasMany(e => e.Sprints)
                .WithRequired(e => e.Phase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.PositionUsers)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sprint>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Sprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.account)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PositionUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

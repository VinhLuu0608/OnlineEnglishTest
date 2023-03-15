using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineEnglishTest.Models;

namespace OnlineEnglishTest.Data
{
    public class EnglishTestDbContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public EnglishTestDbContext(DbContextOptions<EnglishTestDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().ToTable("Categories").HasKey(x => x.ID);
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Answer>().ToTable("Answers");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(x => x.ID).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).IsRequired().HasMaxLength(500);
                entity.Property(x => x.Description).HasMaxLength(1000);
                entity.Property(x => x.Icon).IsRequired().HasMaxLength(500);
                entity.Property(x => x.Status).IsRequired();
                entity.Property(x => x.CreatedBy).IsRequired().HasMaxLength(500);
                entity.Property(x => x.CreatedDate).IsRequired().HasColumnType("datetime");
                entity.Property(x => x.ModifieldBy).IsRequired().HasMaxLength(500);
                entity.Property(x => x.ModifieldDate).IsRequired().HasColumnType("datetime");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(x => x.ID).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).IsRequired().HasMaxLength(500);
                entity.Property(x => x.Description).HasMaxLength(1000);
                entity.Property(x => x.Status).IsRequired();
                entity.Property(x => x.Image).IsRequired().HasMaxLength(500);
                entity.Property(x => x.Level).IsRequired();
                entity.Property(x => x.Type).IsRequired();
                entity.Property(x => x.CreatedBy).IsRequired().HasMaxLength(500);
                entity.Property(x => x.CreatedDate).IsRequired().HasColumnType("datetime");
                entity.Property(x => x.ModifieldBy).IsRequired().HasMaxLength(500);
                entity.Property(x => x.ModifieldDate).IsRequired().HasColumnType("datetime");
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(x => x.ID).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).IsRequired().HasMaxLength(500);
                entity.Property(x => x.Description).HasMaxLength(1000);
                entity.Property(x => x.Hint).IsRequired().HasMaxLength(500);
                entity.Property(x => x.IsCorrect).IsRequired().HasMaxLength(500);
                entity.Property(x => x.Image).IsRequired().HasMaxLength(500);
                entity.Property(x => x.CreatedBy).IsRequired().HasMaxLength(500);
                entity.Property(x => x.CreatedDate).IsRequired().HasColumnType("datetime");
                entity.Property(x => x.ModifieldBy).IsRequired().HasMaxLength(500);
                entity.Property(x => x.ModifieldDate).IsRequired().HasColumnType("datetime");
            });


            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(p => p.Category)
                .WithMany( x => x.questions)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Questions_Categories_CateID");
               
            }
                );


            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasOne(p => p.Question)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Answers");

            });


        }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LVVG;Database=OnlineEnglishTest;Trusted_Connection=true;TrustServerCertificate=true;");
        }



    }
}

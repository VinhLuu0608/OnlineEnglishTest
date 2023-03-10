using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineEnglishTest.Models;

namespace OnlineEnglishTest.Data
{
    public class EnglishTestDbContext :DbContext
    {
        public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public EnglishTestDbContext(DbContextOptions<EnglishTestDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BaseEntity>().ToTable("BaseEntities");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Answer>().ToTable("Answers");

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

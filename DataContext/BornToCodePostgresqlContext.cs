using EntityModels.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace DataContext;

public partial class BornToCodePostgresqlContext : DbContext
{
    public BornToCodePostgresqlContext() { }

    public BornToCodePostgresqlContext(DbContextOptions<BornToCodePostgresqlContext> options)
        : base(options) { }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Solution> Solutions { get; set; }

    public virtual DbSet<SolutionComment> SolutionComments { get; set; }

    public virtual DbSet<SolutionLike> SolutionLikes { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<ExerciseComment> ExerciseComments { get; set; }

    public virtual DbSet<ExerciseLike> ExerciseLikes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("borntocode_prod_db_csharp"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profiles_pkey");

            entity.ToTable("profiles");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Profile)
                .HasForeignKey<Profile>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profiles_id_fkey");
        });

        modelBuilder.Entity<Solution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("solutions_pkey");

            entity.ToTable("solutions");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Css).HasColumnName("css");
            entity.Property(e => e.FromSolution).HasColumnName("from_solution");
            entity.Property(e => e.Html).HasColumnName("html");
            entity.Property(e => e.IsCurrent).HasColumnName("is_current");
            entity.Property(e => e.Js).HasColumnName("js");
            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.VersionDescription)
                .HasMaxLength(255)
                .HasColumnName("version_description");

            entity.HasOne(d => d.Author).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solutions_author_id_fkey");

            entity.HasOne(d => d.Exercise).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solutions_exercise_id_fkey");
        });

        modelBuilder.Entity<SolutionComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("solution_comments_pkey");

            entity.ToTable("solution_comments");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CommentText)
                .HasMaxLength(4095)
                .HasColumnName("comment_text");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.SolutionId).HasColumnName("solution_id");

            entity.HasOne(d => d.Author).WithMany(p => p.SolutionComments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solution_comments_author_id_fkey");

            entity.HasOne(d => d.Solution).WithMany(p => p.SolutionComments)
                .HasForeignKey(d => d.SolutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solution_comments_solution_id_fkey");
        });

        modelBuilder.Entity<SolutionLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("solution_likes_pkey");

            entity.ToTable("solution_likes");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.SolutionId).HasColumnName("solution_id");

            entity.HasOne(d => d.Author).WithMany(p => p.SolutionLikes)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solution_likes_author_id_fkey");

            entity.HasOne(d => d.Solution).WithMany(p => p.SolutionLikes)
                .HasForeignKey(d => d.SolutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solution_likes_solution_id_fkey");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exercises_pkey");

            entity.ToTable("exercises");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CodeExample).HasColumnName("code_example");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FullDescription).HasColumnName("full_description");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(255)
                .HasColumnName("short_description");
            entity.Property(e => e.Title)
                .HasMaxLength(63)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exercises_author_id_fkey");
        });

        modelBuilder.Entity<ExerciseComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exercise_comments_pkey");

            entity.ToTable("exercise_comments");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CommentText)
                .HasMaxLength(4095)
                .HasColumnName("comment_text");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");

            entity.HasOne(d => d.Author).WithMany(p => p.ExerciseComments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exercise_comments_author_id_fkey");

            entity.HasOne(d => d.Exercise).WithMany(p => p.ExerciseComments)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exercise_comments_exercise_id_fkey");
        });

        modelBuilder.Entity<ExerciseLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exercise_likes_pkey");

            entity.ToTable("exercise_likes");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");

            entity.HasOne(d => d.Author).WithMany(p => p.ExerciseLikes)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exercise_likes_author_id_fkey");

            entity.HasOne(d => d.Exercise).WithMany(p => p.ExerciseLikes)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exercise_likes_exercise_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(1000)
                .HasColumnName("avatar");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.LastLoginAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("last_login_at");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(255)
                .HasColumnName("password_salt");
            entity.Property(e => e.Username)
                .HasMaxLength(31)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
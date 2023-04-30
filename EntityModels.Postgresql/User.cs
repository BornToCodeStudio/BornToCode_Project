using System;
using System.Collections.Generic;

namespace EntityModels.Postgresql;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public string? Avatar { get; set; }

    public virtual Profile? Profile { get; set; }

    public virtual ICollection<SolutionComment> SolutionComments { get; set; } = new List<SolutionComment>();

    public virtual ICollection<SolutionLike> SolutionLikes { get; set; } = new List<SolutionLike>();

    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();

    public virtual ICollection<ExerciseComment> ExerciseComments { get; set; } = new List<ExerciseComment>();

    public virtual ICollection<ExerciseLike> ExerciseLikes { get; set; } = new List<ExerciseLike>();

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}

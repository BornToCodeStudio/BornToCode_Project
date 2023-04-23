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

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

    public virtual ICollection<TaskLike> TaskLikes { get; set; } = new List<TaskLike>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}

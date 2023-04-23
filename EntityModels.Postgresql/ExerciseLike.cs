using System;
using System.Collections.Generic;

namespace EntityModels.Postgresql;

public partial class ExerciseLike
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int ExerciseId { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Exercise Exercise { get; set; } = null!;
}
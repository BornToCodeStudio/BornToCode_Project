using System;
using System.Collections.Generic;

namespace EntityModels.Postgresql;

public partial class Exercise
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public string ShortDescription { get; set; } = null!;

    public string? FullDescription { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CodeExample { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();

    public virtual ICollection<ExerciseComment> ExerciseComments { get; set; } = new List<ExerciseComment>();

    public virtual ICollection<ExerciseLike> ExerciseLikes { get; set; } = new List<ExerciseLike>();
}

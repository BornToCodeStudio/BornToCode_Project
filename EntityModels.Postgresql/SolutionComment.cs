using System;
using System.Collections.Generic;

namespace EntityModels.Postgresql;

public partial class SolutionComment
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int SolutionId { get; set; }

    public string? CommentText { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Solution Solution { get; set; } = null!;
}

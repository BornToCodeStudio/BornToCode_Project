using System;
using System.Collections.Generic;

namespace EntityModels.Postgresql;

public partial class Solution
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int AuthorId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsCurrent { get; set; }

    public string? VersionDescription { get; set; }

    public int? FromSolution { get; set; }

    public string? Html { get; set; }

    public string? Css { get; set; }

    public string? Js { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<SolutionComment> SolutionComments { get; set; } = new List<SolutionComment>();

    public virtual ICollection<SolutionLike> SolutionLikes { get; set; } = new List<SolutionLike>();

    public virtual Task Task { get; set; } = null!;
}

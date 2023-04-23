using System;
using System.Collections.Generic;

namespace EntityModels.Postgresql;

public partial class SolutionLike
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int SolutionId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Solution Solution { get; set; } = null!;
}

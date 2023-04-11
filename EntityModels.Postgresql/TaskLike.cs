using System;
using System.Collections.Generic;

namespace EntityModels.Postgresql;

public partial class TaskLike
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int TaskId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
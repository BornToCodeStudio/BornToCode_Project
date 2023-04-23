using System;
using System.Collections.Generic;

namespace EntityModels.Postgresql;

public partial class Profile
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}

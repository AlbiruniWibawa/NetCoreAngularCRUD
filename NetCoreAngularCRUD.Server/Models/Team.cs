using System;
using System.Collections.Generic;

namespace NetCoreAngularCRUD.Server.Models;

public partial class Team
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Earnings { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}

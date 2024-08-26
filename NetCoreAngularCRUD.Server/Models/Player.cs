using System;
using System.Collections.Generic;

namespace NetCoreAngularCRUD.Server.Models;

public partial class Player
{
    public int Id { get; set; }

    public string? Nickname { get; set; }

    public string? Fullname { get; set; }

    public int? Earnings { get; set; }

    public sbyte? IsActive { get; set; }

    public string? Nationality { get; set; }

    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }
}

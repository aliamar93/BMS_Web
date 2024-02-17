using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AmEntryLog
{
    public int Id { get; set; }

    public int? SUId { get; set; }

    public DateTime? TimeIn { get; set; }

    public DateTime? TimeOut { get; set; }

    public bool? Status { get; set; }

    public string? Comments { get; set; }
}

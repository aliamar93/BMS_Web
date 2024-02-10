using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AmEntryLog
{
    public int Id { get; set; }

    public byte[]? Stamp { get; set; }

    public string? StampString { get; set; }

    public DateTime? TimeIn { get; set; }

    public DateTime? TimeOut { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Status { get; set; }

    public string? Comments { get; set; }
}

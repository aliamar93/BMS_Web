using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AmListPermission
{
    public int Id { get; set; }

    public int? PermissionId { get; set; }

    public bool? CanRead { get; set; }

    public bool? CanInsert { get; set; }

    public bool? CanUpdate { get; set; }

    public bool? CanDelete { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Status { get; set; }

    public string? Comments { get; set; }
}

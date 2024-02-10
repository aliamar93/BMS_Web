using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AmPermission
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? PagePermission { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Status { get; set; }

    public string? Comments { get; set; }
}

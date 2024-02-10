using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AmStudent
{
    public int Id { get; set; }

    public string? StdPersonalNo { get; set; }

    public string? StdFirstName { get; set; }

    public string? StdEmail { get; set; }

    public string? StdLastName { get; set; }

    public string? StdPhoneNo { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Status { get; set; }

    public string? Comments { get; set; }
}

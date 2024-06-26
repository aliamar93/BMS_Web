﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AmUser
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNo { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Status { get; set; }

    public string? Comments { get; set; }
}

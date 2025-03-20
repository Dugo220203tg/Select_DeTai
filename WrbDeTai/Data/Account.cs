using System;
using System.Collections.Generic;

namespace WrbDeTai.Data;

public partial class Account
{
    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? TeacherId { get; set; }

    public string? StudentId { get; set; }

    public int? TypeAccount { get; set; }

    public int? Status { get; set; }

    public DateOnly? DateIssued { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? CreatedUser { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public string? ModifiedUser { get; set; }
}

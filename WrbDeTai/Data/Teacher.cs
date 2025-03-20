using System;
using System.Collections.Generic;

namespace WrbDeTai.Data;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EmailAddress { get; set; }

    public DateOnly? Dob { get; set; }

    public int? Sex { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Department { get; set; }

    public string? ImageUrl { get; set; }
}

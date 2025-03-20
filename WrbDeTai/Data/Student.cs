using System;
using System.Collections.Generic;

namespace WrbDeTai.Data;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string? Name { get; set; }

    public string? ClassName { get; set; }

    public DateOnly? Dob { get; set; }

    public int? Sex { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
}

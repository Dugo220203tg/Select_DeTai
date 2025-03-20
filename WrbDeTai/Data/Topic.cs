using System;
using System.Collections.Generic;

namespace WrbDeTai.Data;

public partial class Topic
{
    public int Id { get; set; }

    public string? TopicName { get; set; }

    public string? Description { get; set; }

    public string? StudentId { get; set; }

    public int? TeacherId { get; set; }

    public int? Status { get; set; }

    public int? Year { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}

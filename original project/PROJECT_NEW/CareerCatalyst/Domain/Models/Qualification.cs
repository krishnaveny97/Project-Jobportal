using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Models;

public partial class Qualification
{
    public Guid Id { get; set; }=Guid.NewGuid();

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid? JobseekerProfileId { get; set; }

    public Guid? JobPostId { get; set; }

    public virtual JobPost? JobPost { get; set; }
    [JsonIgnore]

    public virtual JobSeekerProfile? JobseekerProfile { get; set; }
}

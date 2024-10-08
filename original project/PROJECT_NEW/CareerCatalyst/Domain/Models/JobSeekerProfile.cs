using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Models;

public partial class JobSeekerProfile
{
    public Guid Id { get; set; }=Guid.NewGuid();

    public Guid? ResumeId { get; set; }

    public Guid JobSeekerId { get; set; }

    public string? ProfileName { get; set; }

    public string? ProfileSummary { get; set; }

    public virtual JobSeeker JobSeeker { get; set; } = null!;
    [JsonIgnore]

    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();

    public virtual Resume? Resume { get; set; }

    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}

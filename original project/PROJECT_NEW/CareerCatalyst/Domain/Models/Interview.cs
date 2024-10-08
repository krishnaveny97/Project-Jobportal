using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Interview
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [ForeignKey(nameof(Job))]
    public Guid? JobId { get; set; }
    [ForeignKey(nameof(IntervieweeNavigation))]

    public Guid? Interviewee { get; set; }
    [ForeignKey(nameof(Application))]

    public Guid? ApplicationId { get; set; }

    public DateTime? Date { get; set; }

    public int Status { get; set; }
    [ForeignKey(nameof(SheduledByNavigation))]

    public Guid? SheduledBy { get; set; }
    [ForeignKey(nameof(Company))]
    public Guid CompanyId { get; set; }

    public virtual JobApplication? Application { get; set; }

    public virtual JobProviderCompany Company { get; set; } = null!;

    public virtual JobSeeker? IntervieweeNavigation { get; set; }

    public virtual JobPost? Job { get; set; }

    public virtual CompanyUser? SheduledByNavigation { get; set; }
}

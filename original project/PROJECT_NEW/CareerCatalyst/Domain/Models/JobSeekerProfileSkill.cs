using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobSeekerProfileSkill
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        [ForeignKey(nameof(JobseekerProfile))]
        public Guid? JobSeekerProfileId { get; set; }
        [ForeignKey(nameof(Skill))]
        public Guid? SkillId { get; set; }

        public  JobSeekerProfile? JobseekerProfile { get; set; }
        public  Skill? Skill { get; set; }
    }
}

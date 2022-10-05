using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK1.Models;

namespace TASK1.Data
{
    public class ResumeDBContext:DbContext
    {
        public ResumeDBContext(DbContextOptions<ResumeDBContext> options): base(options)
        {

        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
    }
}

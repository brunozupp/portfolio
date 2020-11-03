using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class DetailsDTO
    {
        public Detail Detail { get; set; }

        public List<AcademicTraining> AcademicTrainings { get; set; }

        public List<Experience> Experiences { get; set; }

        public List<Project> Projects { get; set; }

        public List<Skill> Skills { get; set; }
    }
}

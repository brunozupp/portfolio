using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class AcademicTraining
    {
        [Key]
        public int? ID { get; set; }

        [Required(ErrorMessage = "Formação é obrigatório")]
        [Display(Name = "Formação")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Instituição é obrigatória")]
        [Display(Name = "Instituição")]
        public string Institution { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Início")]
        public DateTime? Begin { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Fim")]
        public DateTime? End { get; set; }
    }
}

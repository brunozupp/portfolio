using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Experience
    {
        [Key]
        public int? ID { get; set; }

        [Required(ErrorMessage = "Empresa/Instituição é obrigatória")]
        [Display(Name = "Empresa/Instituição")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Início")]
        public DateTime? Begin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fim")]
        public DateTime? End { get; set; }
    }
}

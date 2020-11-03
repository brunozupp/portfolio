using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Project
    {
        [Key]
        public int? ID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}

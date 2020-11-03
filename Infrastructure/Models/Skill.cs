using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Skill
    {
        [Key]
        public int? ID { get; set; }

        [Required(ErrorMessage = "Habilidade é obrigatória")]
        [Display(Name = "Habilidade")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obrigatório um número entre 1.0 e 5.0")]
        [Range(1.0, 5.0, ErrorMessage = "O número deve ser entre 1.0 e 5.0")]
        [Display(Name = "Pontuação")]
        public float Aptitude { get; set; }
    }
}

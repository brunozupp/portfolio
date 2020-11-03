using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Detail
    {
        [Key]
        public int? ID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime? BirthDate { get; set; }

        public string Linkedin { get; set; }

        public string Instagram { get; set; }

        public string Facebook { get; set; }

        [Display(Name = "Nacionalidade")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "É preciso de uma descrição sobre você")]
        [Display(Name = "Sobre")]
        public string About { get; set; }

        [Required(ErrorMessage = "Objetivos são obrigatórios")]
        [Display(Name = "Objetivos")]
        public string Goals { get; set; }
    }
}

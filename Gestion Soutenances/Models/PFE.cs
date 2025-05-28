using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestion_Soutenances.Models
{
	public class PFE
	{
        public int PFEID { get; set; }
        [Required(ErrorMessage = "titre Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Titre")]
        public string titre { get; set; }
        [Required(ErrorMessage = "description Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Description")]
        public string  desc { get; set; }
        [Required(ErrorMessage = "Date de debut Obligatoire")]
        [Display(Name = "Date de debut")]
        [DataType(DataType.Date)]
        public DateTime DateD { get; set; }
        [Required(ErrorMessage = "Date de fin Obligatoire")]
        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime DateF { get; set; }
        [Display(Name = "Encadrant")]

        public int EncadrantId { get; set; }
        public virtual Enseignant? Enseignant { get; set; }
     

        [Display(Name = "Societe")]

        public int SocieteId { get; set; }
        public virtual Societe? Societe{ get; set; }

    }
}


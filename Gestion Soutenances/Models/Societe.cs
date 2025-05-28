using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestion_Soutenances.Models
{
	public class Societe
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Libelle Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Libelle")]
        public string Lib { get; set; }
        [Required(ErrorMessage = "Adresse Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }
        [Required(ErrorMessage = "Telephone Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Telephone")]
        public string Tel { get; set; }



        public virtual ICollection<PFE>? PFEs { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gestion_Soutenances.Models
{
	public class Enseignant
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Nom Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Prénom Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        public string FullName { get { return Nom + " " + Prenom; } }


        public virtual ICollection<PFE>? PFEs { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Gestion_Soutenances.Models
{
	public class PFE_Etudiant
	{
        public int ID { get; set; }

        [Display(Name = "Etudiant")]
        [ForeignKey("EtudiantId")]
        public int EtudiantId { get; set; }
        public virtual Etudiant? Etudiant { get; set; }

        [Display(Name = "PFE")]
        [ForeignKey("PFEID")]
        public int PFEID { get; set; }
        public virtual PFE? PFE { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestion_Soutenances.Models;

namespace Gestion_Soutenances.Data
{
	public class SoutenanceContext: DbContext
    {
        public SoutenanceContext(DbContextOptions<SoutenanceContext> options)
               : base(options)
        {
        }
        public DbSet<Gestion_Soutenances.Models.Enseignant> Enseignant { get; set; } = default!;

        public DbSet<Gestion_Soutenances.Models.Etudiant> Etudiant { get; set; } = default!;

        public DbSet<Gestion_Soutenances.Models.PFE> PFE { get; set; } = default!;

        public DbSet<Gestion_Soutenances.Models.PFE_Etudiant> PFE_Etudiant { get; set; } = default!;

        public DbSet<Gestion_Soutenances.Models.Societe> Societe { get; set; } = default!;
    }
}


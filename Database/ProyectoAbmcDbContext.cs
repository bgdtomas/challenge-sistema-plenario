using Microsoft.EntityFrameworkCore;
using proyectoABMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoABMC.Database
{
    public class ProyectoAbmcDbContext : DbContext
    {
        public ProyectoAbmcDbContext(DbContextOptions<ProyectoAbmcDbContext> options) : base(options)
        {
        }

        #region DbSets

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }

        #endregion
    }
}

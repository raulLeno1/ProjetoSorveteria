using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSorveteria.Models;

    public class ProjetoSorveteriaContext : DbContext
    {
        public ProjetoSorveteriaContext (DbContextOptions<ProjetoSorveteriaContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoSorveteria.Models.Pedido> Pedido { get; set; }

        public DbSet<ProjetoSorveteria.Models.Sorvete> Sorvete { get; set; }
    }

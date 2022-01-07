using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gerenciamento.Models;

namespace Gerenciamento.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Gerenciamento.Models.Naturalidade> Naturalidade { get; set; }
        public DbSet<Gerenciamento.Models.Peixe> Peixe { get; set; }
    }
}

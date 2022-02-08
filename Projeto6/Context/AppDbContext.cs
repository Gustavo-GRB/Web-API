using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto6.Models;
using System.IO;

namespace Projeto6.Context
{
    public class AppDbContext : DbContext //DbContext irá capsular todas as entidades
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
            
        }


        public DbSet<TbUf> TB_UF { get; set; }
        public DbSet<TbMunicipio> TB_MUNICIPIO { get; set; } 
        public DbSet<TbBairro> TB_BAIRRO { get; set; }
        public DbSet<TbPessoa> TB_PESSOA { get; set; }
        public DbSet<TbEndereco> TB_ENDERECO { get; set; }
        
            

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));


        }

    }
}

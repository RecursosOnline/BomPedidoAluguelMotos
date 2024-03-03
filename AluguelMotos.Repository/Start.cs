using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluguelMotos.Infraestructure.Interfaces.Services;

namespace AluguelMotos.Repository;

internal class Start
{
    public class AppDbContext : DbContext
    {
       
        public DbSet<Entregador> Entregadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuração da conexão com o banco de dados PostgreSQL
            optionsBuilder.UseNpgsql("your_connection_string_here");
        }
    }
}
public record Entregador(Guid EntregadorId, string Nome, string CNH, string CNPJ, ModeloCNH ModeloCNH, DateOnly DataNascimento);
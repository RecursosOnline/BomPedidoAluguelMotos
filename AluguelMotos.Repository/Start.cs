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
        public DbSet<Moto> Motos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuração da conexão com o banco de dados PostgreSQL
            optionsBuilder.UseNpgsql("postgresql");
        }
    }
}
public record Entregador(Guid EntregadorId, string Nome, string CNH, string CNPJ, ModeloCNH ModeloCNH, DateOnly DataNascimento);
/// <summary>
/// 
/// </summary>
/// <param name="MotoId"></param>
/// <param name="Placa"></param>
/// <param name="Renavan"></param>
/// <param name="IsBlocked"></param>
public record Moto(Guid MotoId, string Placa, string Renavan, bool IsBlocked = false);
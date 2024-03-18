using AluguelMotos.Infraestructure.Interfaces.Repositories;
using AluguelMotos.Infraestructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelMotos.Repository;
public class AluguelMotosContext : DbContext
{
    public DbSet<Moto> Motos { get; set; }
    public DbSet<Entregador> Entregadores { get; set; }
    public string DbPath { get; }
    public AluguelMotosContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "AluguelMotos2.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
=> options.UseSqlite($"Data Source={DbPath}");
}

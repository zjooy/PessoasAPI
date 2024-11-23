using cadastroPessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace cadastroPessoas.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PessoaModel> Pessoas { get; set; }
    }
}

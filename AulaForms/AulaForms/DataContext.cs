using AulaForms.Modelos;
using System.Data.Entity;

namespace AulaForms
{
    public class EscolaDbContext : DbContext
    {
        public EscolaDbContext(): base("EscolaDb")
        { }
        public DbSet<Aluno> Alunos { get; set; }
    }
}

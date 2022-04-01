using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        public DbSet<Evento> Eventos {get; set;}
        public DbSet<Lote> Lotes {get; set;}
        public DbSet<Palestrante> Palestrantes {get; set;}
        public DbSet<PalestranteEvento> PalestrantesEventos {get; set;}
        public DbSet<RedeSocial> RedeSocials {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
            
            modelBuilder.Entity<Evento>() //pra um evento
                .HasMany(e => e.RedesSociais) //com redes sociais
                .WithOne(rs => rs.Evento) //as quais se relacionam ao evento
                .OnDelete(DeleteBehavior.Cascade); //quando deletado, leva tudo consigo

            modelBuilder.Entity<Palestrante>() //pra um palestrante
                .HasMany(p => p.RedesSociais) //com redes sociais
                .WithOne(rs => rs.Palestrante) //as quais se relacionam ao palestrante
                .OnDelete(DeleteBehavior.Cascade); //quando deletado, leva tudo consigo
        }
    }
}
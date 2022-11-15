namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Initial Catalog=superHeroDb; Data Source=localhost,1450; Persist Security Info=True; User ID=SA; Password=Senha@123456; TrustServerCertificate=true;");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}

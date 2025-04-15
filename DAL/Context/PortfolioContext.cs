using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Entities;

public class PortfolioContext : IdentityDbContext<ApplicationUser>
{
    private readonly IConfiguration _configuration;

    public PortfolioContext(DbContextOptions<PortfolioContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connStr = _configuration.GetConnectionString("DbConnection");
            optionsBuilder.UseMySql(connStr, new MySqlServerVersion(new Version(10, 5, 8)));
        }
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
}

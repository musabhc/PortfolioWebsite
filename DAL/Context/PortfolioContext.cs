using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Entities;
using System.Net;
using System.Text.Json;

namespace MyPortfolioWebsite.DAL.Context
{
    public class PortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region getAppSettingsConn
            string jsonText = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json"));
            using (JsonDocument doc = JsonDocument.Parse(jsonText))
            {
                JsonElement root = doc.RootElement;
                string connStr = root.GetProperty("AppSettings")
                                     .GetProperty("ConnectionStrings")
                                     .GetProperty("DbConnection")
                                     .GetString();

                // MariaDB bağlantısı için UseMySql kullanın
                optionsBuilder.UseMySql(connStr, new MySqlServerVersion(new Version(10, 5, 8))); // MariaDB sürümüne göre uyarlayın
            }
            #endregion
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}

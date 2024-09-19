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

        public DbSet<About> Abouts { get; set; } // C
        public DbSet<Contact> Contacts { get; set; } // C
        public DbSet<Experience> Experiences { get; set; } // C
        public DbSet<Feature> Features { get; set; } // C
        public DbSet<Message> Messages { get; set; } 
        public DbSet<Portfolio> Portfolios { get; set; } // C
        public DbSet<Skill> Skills { get; set; } // C
        public DbSet<SocialMedia> SocialMedias { get; set; } // C
        public DbSet<Statistics> Statistics { get; set; } // C
        public DbSet<Testimonial> Testimonials { get; set; } // C
    }
}

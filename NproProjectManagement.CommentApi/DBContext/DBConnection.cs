using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NproProjectManagement.Model;


namespace NproProjectManagement.CommentApi.DBContext
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options) : base(options)
        {
        }
        public DbSet<Comment> Comment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-70T4SUE\\SQLEXPRESS;Database=ProjectMgmntDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");
            }
        }
    }
}

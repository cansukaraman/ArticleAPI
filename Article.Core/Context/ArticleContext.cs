using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Article.Core.Model;

namespace Article.Core.Context
{
    public class ArticleContext : DbContext
    {
        public DbSet<ArticleModel> Articles { get; set; }
        public ArticleContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher
{
    public class SearcherDbContext : DbContext
    {
        private string _connString;
        private AppConf _appConf;

        public SearcherDbContext()
        {

        }

        public SearcherDbContext(DbContextOptions options, AppConf appConf) : base(options)
        {
            _appConf = appConf;
        }

        public SearcherDbContext(string connString)
        {
            _connString = connString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (string.IsNullOrEmpty(_connString))
                _connString = _appConf.MainDbConnString;
            options.UseNpgsql(_connString, o => o.SetPostgresVersion(new Version(13, 1)));
            base.OnConfiguring(options);
        }

        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<WordForm> WordForms { get; set; }
        public virtual DbSet<TextRecord> TextRecords { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}

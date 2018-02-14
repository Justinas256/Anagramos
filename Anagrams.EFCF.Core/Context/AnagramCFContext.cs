using Anagrams.EFCF.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.EFCF.Core.Context
{
    public class AnagramCFContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Word>().HasKey(i => i.ID);
            modelBuilder.Entity<UserLog>().HasKey(i => i.ID);
            modelBuilder.Entity<CachedWord>().HasKey(i => i.CachedWordID);

            modelBuilder.Entity<UserLog>()
                .HasRequired<CachedWord>(s => s.CachedWord)
                .WithMany(g => g.UserLogs)
                .HasForeignKey<int>(s => s.CachedWordID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CachedWord>()
                .HasMany<Word>(s => s.Words)
                .WithMany(c => c.CachedWords)
                .Map(cs =>
                    {
                        cs.MapLeftKey("CachedWordID");
                        cs.MapRightKey("AnagramID");
                        cs.ToTable("CachedAnagrams");
                    });
        }

        public virtual DbSet<CachedWord> CachedWords { get; set; }
        public virtual DbSet<UserLog> UserLogs { get; set; }
        public virtual DbSet<Word> Words { get; set; }
    }
}

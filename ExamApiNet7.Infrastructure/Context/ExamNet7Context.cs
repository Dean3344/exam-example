using ExamApiNet7.Infrastructure.Mappings.User;
using Microsoft.EntityFrameworkCore;

namespace ExamApiNet7.Infrastructure.Context
{
    public sealed class ExamNet7Context : DbContext
    {

        public ExamNet7Context(DbContextOptions<ExamNet7Context> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            ChangeTracker.AutoDetectChangesEnabled = true;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ContactInfoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

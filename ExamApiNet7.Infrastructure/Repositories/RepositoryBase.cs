using ExamApiNet7.Infrastructure.Context;

namespace ExamApiNet7.Infrastructure.Repositories
{
    public interface IRepositoryBase
    {
        Task SaveChangesAsync();
    }

    public abstract class RepositoryBase : IRepositoryBase
    {
        protected readonly ExamNet7Context Context;

        protected RepositoryBase(ExamNet7Context context)
        {
            Context = context;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}

using ExamApiNet7.Domain.Models.UserAggregate;
using ExamApiNet7.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ExamApiNet7.Infrastructure.Repositories
{
    public interface IUserRepository : IRepositoryBase
    {
        DbSet<User> Users { get; }
    }

    public sealed class UserRepository : RepositoryBase, IUserRepository
    {


        public UserRepository(ExamNet7Context context) : base(context)
        {

        }

        public DbSet<User> Users => Context.Set<User>();

    }
}

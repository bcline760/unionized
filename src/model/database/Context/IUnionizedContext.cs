using Microsoft.EntityFrameworkCore;

namespace Unionized.Model.Database.Context
{
    public interface IUnionizedContext
    {
        DbContext Context { get; }
        DbSet<NetworkLogModel> NetworkLogs { get; }
        DbSet<UserTokenModel> UserTokens { get; }
    }
}
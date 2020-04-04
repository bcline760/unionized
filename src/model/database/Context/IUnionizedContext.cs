using Microsoft.EntityFrameworkCore;

namespace Unionized.Model.Database.Context
{
    public interface IUnionizedContext
    {
        DbContext DatabaseContext { get; }
        DbSet<NetworkLogModel> NetworkLogs { get; }
        DbSet<UserTokenModel> UserTokens { get; }
    }
}
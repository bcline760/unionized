using Microsoft.EntityFrameworkCore;

namespace Unionized.Interface
{
    public interface IUnionizeContext
    {
        DbSet<NetworkRole> NetworkRoles { get; set; }
        DbSet<User> Users { get; set; }
    }
}
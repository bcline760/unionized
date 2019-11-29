using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model.Database.Context;

namespace Unionized.Model.Database.Repository
{
    internal sealed class RoleRepository : IRoleRepository
    {
        protected IUnionizedContext Context { get; }

        protected DbSet<AppRoleModel> Set { get; }

        protected IMapper Mapper { get; }
        public RoleRepository(IUnionizedContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            Set = Context.Context.Set<AppRoleModel>();
        }

        public async Task<AppRole> CreateRole(string securityGroup, RoleType role)
        {
            var dbRole = new AppRoleModel
            {
                AdGroup = securityGroup,
                Role = role.ToString()
            };

            Set.Add(dbRole);
            int recordsModified = await Context.Context.SaveChangesAsync();

            return Mapper.Map<AppRole>(dbRole);
        }

        public async Task<List<AppRole>> GetAllRoles()
        {
            var dbRoles = await Set.ToListAsync();

            return dbRoles.Select(Mapper.Map<AppRole>).ToList();
        }

        public async Task<AppRole> GetBySecurityGroup(string securityGroup)
        {
            var dbRole = await Set.FirstOrDefaultAsync(s => s.AdGroup == securityGroup);

            return Mapper.Map<AppRole>(dbRole);
        }
    }
}

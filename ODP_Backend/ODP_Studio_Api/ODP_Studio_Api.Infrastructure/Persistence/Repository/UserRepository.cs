using Microsoft.EntityFrameworkCore;
using ODP_Studio_Api.Application.DTOs;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ModelDTOs;
using ODP_Studio_Api.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ODP_Studio_Api.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<UserProfileWithOrgsDto?> GetUserWithRolesAndOrgAsync(string username)
        {
            var userProfile = await _context.UserProfiles
                .Include(up => up.UserAccount)
                .Include(up => up.Role)
                .Where(up => up.UserAccount.Username == username && up.IsActive)
                .FirstOrDefaultAsync();

            if (userProfile == null)
                return null;

            var dto = new UserProfileWithOrgsDto
            {
                UserProfile = userProfile
            };

            if (userProfile.UserType == "Orphan")
            {
                dto.OrphanOrgs = await _context.OrphanOrgs
                    .Where(oo => oo.OrphanId == userProfile.EntityId && oo.IsActive)
                    .Include(oo => oo.Org)
                    .Include(oo => oo.Orphan)
                    .ToListAsync();
            }
            else if (userProfile.UserType == "Manager")
            {
                dto.ManagerOrgs = await _context.ManagerOrgs
                    .Where(mo => mo.ManagerId == userProfile.EntityId && mo.IsActive)
                    .Include(mo => mo.Org)
                    .ToListAsync();
            }

            return dto;
        }

    }
}

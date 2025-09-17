using Microsoft.EntityFrameworkCore;
using ODP_Studio_Api.Application.DTOs;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
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

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
        }
        public async Task<User?> GetUserWithRolesAndOrgAsync(string username)
        {
            var user = await _context.Users
                .Include(u => u.UserOrgRoles)
                    .ThenInclude(uor => uor.RoleType)
                .Include(u => u.UserOrgRoles)
                    .ThenInclude(uor => uor.Org)
                .FirstOrDefaultAsync(u => u.UserName == username);

            // Optionally, you can map or transform here if needed
            return user;
        }

    }
}

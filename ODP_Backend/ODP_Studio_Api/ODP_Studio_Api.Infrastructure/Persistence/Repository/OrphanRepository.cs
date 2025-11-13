using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Exceptions;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ModelDTOs;
using ODP_Studio_Api.Domain.ValueObjects;
using ODP_Studio_Api.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Infrastructure.Persistence.Repository
{
    public class OrphanRepository : IOrphanRepository
    {
        private readonly AppDbContext _context;
        public OrphanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrphanSummaryDto> AddAsync(Orphan orphan, CancellationToken cancellationToken = default)
        {
           
            await _context.Orphans.AddAsync(orphan, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var dto = new OrphanSummaryDto { OrphanId = orphan.OrphanId };
            return dto;
        }
        public async Task<OrphanInfoWithOrgDto?> GetByIdAsync(Guid orphanId, CancellationToken cancellationToken)
        {
            var orphanInfo = await _context.Orphans
                .Include(o => o.OrphanOrgs)                 // Include navigation if needed
                .Include(o => o.PersonalInfo)               // Include owned types if needed
                .FirstOrDefaultAsync(o => o.OrphanId == orphanId, cancellationToken);

            if (orphanInfo == null)
                return null;

            var dto = new OrphanInfoWithOrgDto
            {
                Orphan = orphanInfo
            };
            return dto;
        }

        public async Task<OrphansListDto> GetAllByOrgIdAsync(Guid orgId, CancellationToken cancellationToken)
        {
            var orphanList = await _context.Orphans
                        .Include(o => o.OrphanOrgs)
                        .Where(o => o.OrphanOrgs.Any(oo => oo.OrgId == orgId))
                        .ToListAsync(cancellationToken);

            if (orphanList.Count == 0 && orphanList == null)
            {
                return null;
            }

            var dto = new OrphansListDto
            {
                orphans = orphanList
            };
            return dto;
        }

        public async Task<OrphanUpdateSummary> UpdateByIdAsync(Orphan request, CancellationToken cancellationToken = default)
        {
            var orphan = await _context.Orphans.FindAsync(new object[] { request.OrphanId }, cancellationToken);

            if (orphan == null)
            {
                throw new NotFoundException("Orphan does not exist or Created");
            }

            UpdateNonNullProperties(orphan, request);

            await _context.SaveChangesAsync(cancellationToken);

            return new OrphanUpdateSummary { status = true };
        }

        public static void UpdateNonNullProperties(object target, object source)
        {
            if (target == null || source == null) throw new ArgumentNullException();

            var targetType = target.GetType();
            var properties = targetType.GetProperties();

            foreach (var property in properties)
            {
                if (!property.CanRead || !property.CanWrite)
                    continue;

                var sourceValue = property.GetValue(source);

                if (sourceValue == null)
                    continue;

                if (property.PropertyType == typeof(string))
                {
                    if (!string.IsNullOrEmpty((string)sourceValue))
                    {
                        property.SetValue(target, sourceValue);
                    }
                }
                else if (Nullable.GetUnderlyingType(property.PropertyType) != null) // Nullable types
                {
                    property.SetValue(target, sourceValue);
                }
                else if (!property.PropertyType.IsClass || property.PropertyType.IsValueType) // Primitive types
                {
                    property.SetValue(target, sourceValue);
                }
                else
                {
                    var targetNested = property.GetValue(target);
                    if (targetNested == null)
                    {
                        property.SetValue(target, sourceValue);
                    }
                    else
                    {
                        // Recursively update complex type
                        UpdateNonNullProperties(targetNested, sourceValue);
                    }
                }
            }
        }


    }

}

using System.Collections.Immutable;
using Equipment.Domain;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Infrastructure;

public class EquipmentStatusRepository : IEquipmentStatusRepository
{
    private readonly EquipmentContext _ctx;

    public EquipmentStatusRepository(EquipmentContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<int> Upsert(Domain.EquipmentStatus equipmentStatus)
    {
        var model = EquipmentStatus.FromDomainObject(equipmentStatus);

        _ctx.EquipmentStatuses.Add(model);
        await _ctx.SaveChangesAsync();

        return model.Id;
    }

    public async Task<IReadOnlyCollection<Domain.EquipmentStatus>> GetStatusHistory(int equipmentId)
    {
        var result = await _ctx.EquipmentStatuses
            .Where(s => s.EquipmentId == equipmentId)
            .ToListAsync();

        return result.Select(s => s.ToDomainObject())
            .OrderByDescending(s => s.Timestamp) // SQLite doesn't support ordering by DateTimeOffset columns
            .ToImmutableList();
    }
}
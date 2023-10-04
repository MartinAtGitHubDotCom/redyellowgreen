using Equipment.Domain;

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
}
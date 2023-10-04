using Equipment.Domain;

namespace Equipment.Infrastructure;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly EquipmentContext _ctx;

    public EquipmentRepository(EquipmentContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<bool> Exists(int equipmentId)
    {
        return await _ctx.Equipment.FindAsync(equipmentId) != null;
    }
}
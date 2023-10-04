using Equipment.Domain;

namespace Equipment.Infrastructure;

public class EquipmentStatus
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public Status Status { get; set; }

    public static EquipmentStatus FromDomainObject(Domain.EquipmentStatus equipmentStatus)
    {
        return new EquipmentStatus
        {
            Id = equipmentStatus.Id,
            EquipmentId = equipmentStatus.EquipmentId,
            Timestamp = equipmentStatus.Timestamp,
            Status = equipmentStatus.Status,
        };
    }
}
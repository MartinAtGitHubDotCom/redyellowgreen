namespace Equipment.Domain;

public interface IEquipmentStatusRepository
{
    public Task<int> Upsert(EquipmentStatus equipmentStatus);
}
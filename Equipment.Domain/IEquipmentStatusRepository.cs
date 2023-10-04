namespace Equipment.Domain;

public interface IEquipmentStatusRepository
{
    public Task<int> Upsert(EquipmentStatus equipmentStatus);

    public Task<IReadOnlyCollection<EquipmentStatus>> GetStatusHistory(int equipmentId);
}
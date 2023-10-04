namespace Equipment.Domain;

public interface IEquipmentRepository
{
    Task<bool> Exists(int equipmentId);
}
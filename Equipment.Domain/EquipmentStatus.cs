namespace Equipment.Domain;

public record EquipmentStatus(int Id, int EquipmentId, DateTimeOffset Timestamp, Status Status);
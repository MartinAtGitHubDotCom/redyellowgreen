using Equipment.Domain;

namespace Equipment.Api;

public record EquipmentStatusDto(DateTimeOffset Timestamp, Status Status);
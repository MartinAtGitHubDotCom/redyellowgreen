using Equipment.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Api;

[Route("[controller]")]
public class EquipmentStatusController : Controller
{
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IEquipmentStatusRepository _equipmentStatusRepository;

    public EquipmentStatusController(
        IEquipmentRepository equipmentRepository, 
        IEquipmentStatusRepository equipmentStatusRepository)
    {
        _equipmentRepository = equipmentRepository;
        _equipmentStatusRepository = equipmentStatusRepository;
    }

    [Route("equipment/{equipmentId}/status")]
    [HttpPost]
    public async Task<IActionResult> SetEquipmentStatus([FromBody] EquipmentStatusDto equipmentStatus, int equipmentId)
    {
        if (!await _equipmentRepository.Exists(equipmentId))
        {
            return NotFound();
        }

        await _equipmentStatusRepository.Upsert(new EquipmentStatus(0, equipmentId, equipmentStatus.Timestamp, equipmentStatus.Status));

        return Ok();
    }
}
using Equipment.Api.LiveView;
using Equipment.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Equipment.Api;

[Route("[controller]")]
public class EquipmentStatusController : Controller
{
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IEquipmentStatusRepository _equipmentStatusRepository;
    private readonly IHubContext<EquipmentStatusHub> _hubContext;

    public EquipmentStatusController(
        IEquipmentRepository equipmentRepository, 
        IEquipmentStatusRepository equipmentStatusRepository, 
        IHubContext<EquipmentStatusHub> hubContext)
    {
        _equipmentRepository = equipmentRepository;
        _equipmentStatusRepository = equipmentStatusRepository;
        _hubContext = hubContext;
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
        
        await _hubContext.Clients.All.SendCoreAsync("ReceiveStatusUpdate", new object[] { equipmentId, Enum.GetName(equipmentStatus.Status)! });

        return Ok();
    }
    
    [Route("equipment/{equipmentId}/history")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipmentStatusDto>>> GetEquipmentStatusHistory(int equipmentId)
    {
        if (!await _equipmentRepository.Exists(equipmentId))
        {
            return NotFound();
        }

        var statusHistory = await _equipmentStatusRepository.GetStatusHistory(equipmentId);
        
        return Ok(statusHistory.Select(s => new EquipmentStatusDto(s.Timestamp, s.Status)));
    }
}
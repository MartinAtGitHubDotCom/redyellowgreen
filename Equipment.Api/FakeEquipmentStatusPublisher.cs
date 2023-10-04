using Equipment.Domain;

namespace Equipment.Api;

public class FakeEquipmentStatusPublisher : IHostedService, IDisposable
{
    private Timer? _timer = null;
    private Random _random = new Random();
    private HttpClient _client = new HttpClient();

    private async void UpdateEquipmentStatus(object? state)
    {
        var equipmentId = _random.Next(1, 4);
        var status = (Status)_random.Next(0, 3);
        
        await _client.PostAsJsonAsync($"http://localhost:5089/EquipmentStatus/equipment/{equipmentId}/status",
            new EquipmentStatusDto(DateTimeOffset.Now, status));
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(UpdateEquipmentStatus, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(3));
        return Task.CompletedTask;
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
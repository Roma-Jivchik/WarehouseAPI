namespace WarehouseAPI.Domain.Requests.WorkerRequests;

public class UpdateWorkerRequest
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Position { get; set; } = null!;
}
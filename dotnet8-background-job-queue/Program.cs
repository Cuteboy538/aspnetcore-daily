// Program.cs (minimal example)
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<JobQueue>();
builder.Services.AddHostedService<JobWorker>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var app = builder.Build();

app.MapPost("/enqueue", async (JobQueue queue) => {
    await queue.Enqueue(async ct => {
        Console.WriteLine("Job started");
        await Task.Delay(1000, ct);
        Console.WriteLine("Job done");
    });
    return Results.Ok("Job enqueued");
});

app.UseSwagger();
app.UseSwaggerUI();
app.Run();

public class JobQueue
{
    private readonly Channel<Func<CancellationToken, Task>> _queue = Channel.CreateUnbounded<Func<CancellationToken, Task>>();
    public async Task Enqueue(Func<CancellationToken, Task> job) => await _queue.Writer.WriteAsync(job);
    public async Task<Func<CancellationToken, Task>> Dequeue(CancellationToken ct) => await _queue.Reader.ReadAsync(ct);
}

public class JobWorker : BackgroundService
{
    private readonly JobQueue _queue;
    public JobWorker(JobQueue queue) => _queue = queue;

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            var job = await _queue.Dequeue(ct);
            try { await job(ct); }
            catch (Exception ex) { Console.WriteLine($"Job failed: {ex.Message}"); }
        }
    }
}

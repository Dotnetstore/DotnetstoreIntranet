using System.Diagnostics;

namespace Dotnetstore.Intranet.WebAPI.Utility.Models;

public sealed class StateBag
{
    private readonly Stopwatch _sw = new();

    public string? Status { get; set; }
    public long DurationMillis => _sw.ElapsedMilliseconds;

    public StateBag() => _sw.Start();
}
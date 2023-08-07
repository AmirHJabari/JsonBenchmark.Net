using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using JsonBenchmark.Net.Benchmarks;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Exporters.Csv;

var benchmarks = new BenchmarkSwitcher(new[]
{
    typeof(SimpleObjectSerializeBenchmark),
    typeof(ComplexObjectSerializeBenchmark)
});

#if DEBUG
//var test = new ComplexObjectSerializeBenchmark();
//test.GlobalSetup();
//var bytes = test.SpanJson_Bytes();
//var json = Encoding.UTF8.GetString(bytes);

Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("Please put this benchmark in Release mode to run benchmarks.");
Console.ResetColor();
#else
benchmarks.Run(args);
#endif

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddExporter(MarkdownExporter.GitHub)
            .AddExporter(RPlotExporter.Default)
            .AddExporter(CsvMeasurementsExporter.Default)
        .AddDiagnoser(MemoryDiagnoser.Default)
        .AddColumn(RankColumn.Arabic);

        var job = Job.ShortRun
            .WithLaunchCount(1)
            .WithWarmupCount(3)
            .WithRuntime(CoreRuntime.Core70)
            .WithJit(Jit.RyuJit)
            .WithPlatform(Platform.X64);
        
        AddJob(job);
    }
}
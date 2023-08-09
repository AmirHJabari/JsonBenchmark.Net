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
    typeof(ComplexObjectSerializeBenchmark),
    typeof(SimpleObjectDeserializeBenchmark),
    typeof(ComplexObjectDeserializeBenchmark),
    typeof(SuperSimpleObjectDeserializeBenchmark),
    typeof(SuperSimpleObjectSerializeBenchmark)
});

#if DEBUG
var test = new ComplexObjectDeserializeBenchmark();
test.GlobalSetup();

var obj = test.SrcGen_String();

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
            //.AddExporter(RPlotExporter.Default)
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
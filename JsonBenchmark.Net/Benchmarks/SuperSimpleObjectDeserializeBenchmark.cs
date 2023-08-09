using BenchmarkDotNet.Attributes;
using JsonBenchmark.Net.Models;
using JsonBenchmark.Net.Services;
using System.Text;

namespace JsonBenchmark.Net.Benchmarks;

[Config(typeof(BenchmarkConfig))]
public class SuperSimpleObjectDeserializeBenchmark
{
    static string json;
    static byte[] jsonBytes;
    static Encoding utf8 = Encoding.UTF8;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var obj = SuperSimpleClass.Create();
        jsonBytes = Utf8Json.JsonSerializer.Serialize(obj);
        json = utf8.GetString(jsonBytes);
    }

    #region Deserialize from json

    [Benchmark]
    public SuperSimpleClass Jil_String()
    {
        return Jil.JSON.Deserialize<SuperSimpleClass>(json);
    }

    [Benchmark]
    public SuperSimpleClass NetJSON_String()
    {
        return NetJSON.NetJSON.Deserialize<SuperSimpleClass>(json);
    }

    [Benchmark]
    public SuperSimpleClass Newtonsoft_String()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<SuperSimpleClass>(json);
    }

    [Benchmark]
    public SuperSimpleClass SpanJson_String()
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<SuperSimpleClass>(utf8.GetBytes(json));
    }

    [Benchmark]
    public SuperSimpleClass SystemTextJson_String()
    {
        return System.Text.Json.JsonSerializer.Deserialize<SuperSimpleClass>(json);
    }

    [Benchmark]
    public SuperSimpleClass SrcGen_String()
    {
        return System.Text.Json.JsonSerializer.Deserialize<SuperSimpleClass>(json, JsonSourceGen.Default.SuperSimpleClass);
    }

    [Benchmark]
    public SuperSimpleClass Utf8Json_String()
    {
        return Utf8Json.JsonSerializer.Deserialize<SuperSimpleClass>(json);
    }

    #endregion

    #region Deserialize from json bytes

    [Benchmark]
    public SuperSimpleClass Jil_Bytes()
    {
        return Jil.JSON.Deserialize<SuperSimpleClass>(utf8.GetString(jsonBytes));
    }

    [Benchmark]
    public SuperSimpleClass NetJSON_Bytes()
    {
        return NetJSON.NetJSON.Deserialize<SuperSimpleClass>(utf8.GetString(jsonBytes));
    }

    [Benchmark]
    public SuperSimpleClass Newtonsoft_Bytes()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<SuperSimpleClass>(utf8.GetString(jsonBytes));
    }

    [Benchmark(Baseline = true)]
    public SuperSimpleClass SpanJson_Bytes()
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<SuperSimpleClass>(jsonBytes);
    }

    [Benchmark]
    public SuperSimpleClass SystemTextJson_Bytes()
    {
        return System.Text.Json.JsonSerializer.Deserialize<SuperSimpleClass>(jsonBytes);
    }

    [Benchmark]
    public SuperSimpleClass SrcGen_Bytes()
    {
        return System.Text.Json.JsonSerializer.Deserialize<SuperSimpleClass>(jsonBytes, JsonSourceGen.Default.SuperSimpleClass);
    }

    [Benchmark]
    public SuperSimpleClass Utf8Json_Bytes()
    {
        return Utf8Json.JsonSerializer.Deserialize<SuperSimpleClass>(jsonBytes);
    }

    #endregion
}

using BenchmarkDotNet.Attributes;
using JsonBenchmark.Net.Models;
using System.Text;
using JsonBenchmark.Net.Services;

namespace JsonBenchmark.Net.Benchmarks;

[Config(typeof(BenchmarkConfig))]
public class ComplexObjectSerializeBenchmark
{
    static ComplexClass obj;
    static Utf8Json.IJsonFormatterResolver jsonresolver = Utf8Json.Resolvers.StandardResolver.Default;
    static Encoding utf8 = Encoding.UTF8;

    static NetJSON.NetJSONSettings njSettings = new()
    {
        DateFormat = NetJSON.NetJSONDateFormat.JsonNetISO,
        UseEnumString = true,
    };
    static Jil.Options jilOptions = new(dateFormat: Jil.DateTimeFormat.ISO8601);

    [GlobalSetup]
    public void GlobalSetup()
    {
        obj = ComplexClass.Create();
    }

    #region Json as string

    [Benchmark]
    public string Jil_String()
    {
        return Jil.JSON.Serialize(obj, jilOptions);
    }

    [Benchmark]
    public string NetJSON_String()
    {
        return NetJSON.NetJSON.Serialize(obj, njSettings);
    }

    [Benchmark]
    public string Newtonsoft_String()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    }

    [Benchmark]
    public string SpanJson_String()
    {
        return utf8.GetString(SpanJson.JsonSerializer.NonGeneric.Utf8.Serialize(obj));
    }

    [Benchmark]
    public string SystemTextJson_String()
    {
        return System.Text.Json.JsonSerializer.Serialize(obj);
    }

    [Benchmark]
    public string SrcGen_String()
    {
        return System.Text.Json.JsonSerializer.Serialize(obj, JsonSourceGen.Default.ComplexClass);
    }

    [Benchmark]
    public string Utf8Json_String()
    {
        return Utf8Json.JsonSerializer.ToJsonString(obj, jsonresolver);
    }

    #endregion

    #region Json as bytes

    [Benchmark]
    public byte[] Jil_Bytes()
    {
        return utf8.GetBytes(Jil.JSON.Serialize(obj, jilOptions));
    }

    [Benchmark]
    public byte[] NetJSON_Bytes()
    {
        return utf8.GetBytes(NetJSON.NetJSON.Serialize(obj, njSettings));
    }

    [Benchmark]
    public byte[] Newtonsoft_Bytes()
    {
        return utf8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
    }

    [Benchmark]
    public byte[] SpanJson_Bytes()
    {
        return SpanJson.JsonSerializer.NonGeneric.Utf8.Serialize(obj);
    }

    [Benchmark]
    public byte[] SystemTextJson_Bytes()
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj);
    }

    [Benchmark]
    public byte[] SrcGen_Bytes()
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj, JsonSourceGen.Default.ComplexClass);
    }

    [Benchmark]
    public byte[] Utf8Json_Bytes()
    {
        return Utf8Json.JsonSerializer.Serialize(obj, jsonresolver);
    }
    #endregion
}

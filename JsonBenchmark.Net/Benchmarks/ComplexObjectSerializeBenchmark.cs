using BenchmarkDotNet.Attributes;
using JsonBenchmark.Net.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace JsonBenchmark.Net.Benchmarks;

[Config(typeof(BenchmarkConfig))]
public class ComplexObjectSerializeBenchmark
{
    static ComplexClass obj;
    static Encoding utf8 = Encoding.UTF8;

    static NetJSON.NetJSONSettings njSettings = new()
    {
        DateFormat = NetJSON.NetJSONDateFormat.JsonNetISO,
        UseEnumString = true,
    };
    static Jil.Options jilOptions = new(dateFormat: Jil.DateTimeFormat.ISO8601);
    static System.Text.Json.JsonSerializerOptions stjOptions = new System.Text.Json.JsonSerializerOptions()
    {
        Converters =
            {
                new JsonStringEnumConverter()
            }
    };

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
        return System.Text.Json.JsonSerializer.Serialize(obj, stjOptions);
    }

    [Benchmark]
    public string Utf8Json_String()
    {
        return Utf8Json.JsonSerializer.ToJsonString(obj);
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

    [Benchmark(Baseline = true)]
    public byte[] SpanJson_Bytes()
    {
        return SpanJson.JsonSerializer.NonGeneric.Utf8.Serialize(obj);
    }

    [Benchmark]
    public byte[] SystemTextJson_Bytes()
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj, stjOptions);
    }

    [Benchmark]
    public byte[] Utf8Json_Bytes()
    {
        return Utf8Json.JsonSerializer.Serialize(obj);
    }
    #endregion
}

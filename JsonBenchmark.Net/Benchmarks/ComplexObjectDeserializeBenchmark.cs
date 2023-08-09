using BenchmarkDotNet.Attributes;
using JsonBenchmark.Net.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace JsonBenchmark.Net.Benchmarks;

[Config(typeof(BenchmarkConfig))]
public class ComplexObjectDeserializeBenchmark
{
    static string json;
    static byte[] jsonBytes;
    static Encoding utf8 = Encoding.UTF8;
    static NetJSON.NetJSONSettings njSettings = new()
    {
        DateFormat = NetJSON.NetJSONDateFormat.JsonNetISO,
        UseEnumString = true
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
        var obj = ComplexClass.Create();
        jsonBytes = Utf8Json.JsonSerializer.Serialize(obj);
        json = utf8.GetString(jsonBytes);
    }

    #region Deserialize from json

    [Benchmark]
    public ComplexClass Jil_String()
    {
        return Jil.JSON.Deserialize<ComplexClass>(json, jilOptions);
    }

    [Benchmark]
    public ComplexClass NetJSON_String()
    {
        return NetJSON.NetJSON.Deserialize<ComplexClass>(json, njSettings);
    }

    [Benchmark]
    public ComplexClass Newtonsoft_String()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ComplexClass>(json);
    }

    [Benchmark]
    public ComplexClass SpanJson_String()
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<ComplexClass>(utf8.GetBytes(json));
    }

    [Benchmark]
    public ComplexClass SystemTextJson_String()
    {
        return System.Text.Json.JsonSerializer.Deserialize<ComplexClass>(json, stjOptions);
    }

    [Benchmark]
    public ComplexClass Utf8Json_String()
    {
        return Utf8Json.JsonSerializer.Deserialize<ComplexClass>(json);
    }

    #endregion

    #region Deserialize from json bytes

    [Benchmark]
    public ComplexClass Jil_Bytes()
    {
        return Jil.JSON.Deserialize<ComplexClass>(utf8.GetString(jsonBytes), jilOptions);
    }

    [Benchmark]
    public ComplexClass NetJSON_Bytes()
    {
        return NetJSON.NetJSON.Deserialize<ComplexClass>(utf8.GetString(jsonBytes), njSettings);
    }

    [Benchmark]
    public ComplexClass Newtonsoft_Bytes()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ComplexClass>(utf8.GetString(jsonBytes));
    }

    [Benchmark(Baseline = true)]
    public ComplexClass SpanJson_Bytes()
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<ComplexClass>(jsonBytes);
    }

    [Benchmark]
    public ComplexClass SystemTextJson_Bytes()
    {
        return System.Text.Json.JsonSerializer.Deserialize<ComplexClass>(jsonBytes, stjOptions);
    }

    [Benchmark]
    public ComplexClass Utf8Json_Bytes()
    {
        return Utf8Json.JsonSerializer.Deserialize<ComplexClass>(jsonBytes);
    }

    #endregion
}

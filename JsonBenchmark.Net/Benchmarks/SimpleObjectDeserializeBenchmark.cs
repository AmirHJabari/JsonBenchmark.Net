﻿using BenchmarkDotNet.Attributes;
using JsonBenchmark.Net.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace JsonBenchmark.Net.Benchmarks;

[Config(typeof(BenchmarkConfig))]
public class SimpleObjectDeserializeBenchmark
{
    static string json;
    static byte[] jsonBytes;
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
        var obj = SimpleClass.Create();
        jsonBytes = Utf8Json.JsonSerializer.Serialize(obj);
        json = utf8.GetString(jsonBytes);
    }

    #region Deserialize from json

    [Benchmark]
    public SimpleClass Jil_String()
    {
        return Jil.JSON.Deserialize<SimpleClass>(json, jilOptions);
    }

    [Benchmark]
    public SimpleClass NetJSON_String()
    {
        return NetJSON.NetJSON.Deserialize<SimpleClass>(json, njSettings);
    }

    [Benchmark]
    public SimpleClass Newtonsoft_String()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleClass>(json);
    }

    [Benchmark]
    public SimpleClass SpanJson_String()
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<SimpleClass>(utf8.GetBytes(json));
    }

    [Benchmark]
    public SimpleClass SystemTextJson_String()
    {
        return System.Text.Json.JsonSerializer.Deserialize<SimpleClass>(json, stjOptions);
    }

    [Benchmark]
    public SimpleClass Utf8Json_String()
    {
        return Utf8Json.JsonSerializer.Deserialize<SimpleClass>(json);
    }

    #endregion

    #region Deserialize from json bytes

    [Benchmark]
    public SimpleClass Jil_Bytes()
    {
        return Jil.JSON.Deserialize<SimpleClass>(utf8.GetString(jsonBytes), jilOptions);
    }

    [Benchmark]
    public SimpleClass NetJSON_Bytes()
    {
        return NetJSON.NetJSON.Deserialize<SimpleClass>(utf8.GetString(jsonBytes), njSettings);
    }

    [Benchmark]
    public SimpleClass Newtonsoft_Bytes()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleClass>(utf8.GetString(jsonBytes));
    }

    [Benchmark(Baseline = true)]
    public SimpleClass SpanJson_Bytes()
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<SimpleClass>(jsonBytes);
    }

    [Benchmark]
    public SimpleClass SystemTextJson_Bytes()
    {
        return System.Text.Json.JsonSerializer.Deserialize<SimpleClass>(jsonBytes, stjOptions);
    }

    [Benchmark]
    public SimpleClass Utf8Json_Bytes()
    {
        return Utf8Json.JsonSerializer.Deserialize<SimpleClass>(jsonBytes);
    }

    #endregion
}

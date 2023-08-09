﻿using BenchmarkDotNet.Attributes;
using JsonBenchmark.Net.Models;
using JsonBenchmark.Net.Services;
using System.Text;

namespace JsonBenchmark.Net.Benchmarks;

[Config(typeof(BenchmarkConfig))]
public class SuperSimpleObjectSerializeBenchmark
{
    static SuperSimpleClass obj;
    static Encoding utf8 = Encoding.UTF8;

    [GlobalSetup]
    public void GlobalSetup()
    {
        obj = SuperSimpleClass.Create();
    }

    #region Json as string

    [Benchmark]
    public string Jil_String()
    {
        return Jil.JSON.Serialize(obj);
    }

    [Benchmark]
    public string NetJSON_String()
    {
        return NetJSON.NetJSON.Serialize(obj);
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
        return System.Text.Json.JsonSerializer.Serialize(obj, JsonSourceGen.Default.SuperSimpleClass);
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
        return utf8.GetBytes(Jil.JSON.Serialize(obj));
    }

    [Benchmark]
    public byte[] NetJSON_Bytes()
    {
        return utf8.GetBytes(NetJSON.NetJSON.Serialize(obj));
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
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj);
    }

    [Benchmark]
    public byte[] SrcGen_Bytes()
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj, JsonSourceGen.Default.SuperSimpleClass);
    }

    [Benchmark]
    public byte[] Utf8Json_Bytes()
    {
        return Utf8Json.JsonSerializer.Serialize(obj);
    }
    #endregion
}

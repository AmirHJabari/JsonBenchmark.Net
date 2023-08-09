using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using JsonBenchmark.Net.Models;
using System.Text.Json;
namespace JsonBenchmark.Net.Services;

/// <summary>
/// Source generated json serializer
/// </summary>
[JsonSerializable(typeof(SimpleClass))]
[JsonSerializable(typeof(ComplexClass))]
[JsonSerializable(typeof(SuperSimpleClass))]
public partial class JsonSourceGen : JsonSerializerContext
{

}
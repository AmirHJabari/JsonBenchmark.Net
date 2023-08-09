using JsonBenchmark.Net.Tools;

namespace JsonBenchmark.Net.Models;

public class SimpleClass
{
    public DayOfWeek DayOfWeek { get; set; }
    public Guid Guid { get; set; }
    public sbyte Sbyte { get; set; }
    public byte Byte { get; set; }

    public short Short { get; set; }
    public ushort Ushort { get; set; }

    public int Int { get; set; }
    public uint Uint { get; set; }

    public long Long { get; set; }
    public ulong Ulong { get; set; }

    public float Float { get; set; }
    public double Double { get; set; }
    public decimal Decimal { get; set; }

    public string String { get; set; }
    public char Char { get; set; }

    public bool False { get; set; }
    public bool True { get; set; }

    public DateTime DateTime { get; set; }
    public object Nullable { get; set; }

    public static SimpleClass Create(Rand rand = null!)
    {
        rand ??= new Rand(28115235);

        unchecked
        {
            return new SimpleClass
            {
                Guid = Guid.NewGuid(),
                DayOfWeek = rand.DayOfWeek(),
                Sbyte = rand.Sbyte(),
                Byte = rand.Byte(),
                Short = rand.Short(),
                Ushort = rand.Ushort(),
                Int = rand.Int(),
                Uint = rand.Uint(),
                Long = rand.Long(),
                Ulong = rand.Ulong(),

                Float = rand.Float(),
                Double = rand.Double(),
                Decimal = rand.Decimal(),

                False = false,
                True = true,

                String = rand.String(),
                Char = rand.Char(),

                DateTime = DateTime.UtcNow,
                Nullable = null!,
            };
        }
    }
}

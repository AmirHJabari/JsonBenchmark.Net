using JsonBenchmark.Net.Tools;

namespace JsonBenchmark.Net.Models;

public class ComplexClass
{
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public DayOfWeek DayOfWeek { get; set; }
    public DayOfWeek[] ArrDayOfWeek { get; set; }

    public Guid Guid { get; set; }
    public Guid[] ArrGuid { get; set; }

    public sbyte Sbyte { get; set; }
    public byte Byte { get; set; }

    public sbyte[] ArrSbyte { get; set; }
    public IEnumerable<byte> ArrByte { get; set; }

    public short Short { get; set; }
    public ushort Ushort { get; set; }

    public short[] ArrShort { get; set; }
    public ushort[] ArrUshort { get; set; }

    public int Int { get; set; }
    public uint Uint { get; set; }

    public int[] ArrInt { get; set; }
    public uint[] ArrUint { get; set; }

    public long Long { get; set; }
    public ulong Ulong { get; set; }

    public long[] ArrLong { get; set; }
    public ulong[] ArrUlong { get; set; }

    public float Float { get; set; }
    public double Double { get; set; }
    public decimal Decimal { get; set; }

    public float[] ArrFloat { get; set; }
    public double[] ArrDouble { get; set; }
    public decimal[] ArrDecimal { get; set; }

    public string String { get; set; }
    public char Char { get; set; }

    public string[] ArrString { get; set; }
    public char[] ArrChar { get; set; }

    public bool False { get; set; }
    public bool True { get; set; }

    public bool[] ArrFalse { get; set; }
    public bool[] ArrTrue { get; set; }

    public DateTime DateTime { get; set; }
    public SimpleClass? Nullable { get; set; }

    public DateTime[] ArrDateTime { get; set; }
    public SimpleClass[] ArrNullable { get; set; }

    public SimpleClass NestedClass { get; set; }
    public SimpleClass[] ArrNestedClass { get; set; }

    public static ComplexClass Create()
    {
        var rand = new Rand(28115235);

        unchecked
        {
            return new()
            {
                Guid = Guid.NewGuid(),
                ArrGuid = Arr(5, Guid.NewGuid),
                
                DayOfWeek= rand.DayOfWeek(),
                ArrDayOfWeek = Arr(5, rand.DayOfWeek),

                Sbyte = rand.Sbyte(),
                ArrSbyte = Arr(5, rand.Sbyte),

                Byte = rand.Byte(),
                ArrByte = Arr(5, rand.Byte),

                Short = rand.Short(),
                ArrShort = Arr(5, rand.Short),

                Ushort = rand.Ushort(),
                ArrUshort = Arr(5, rand.Ushort),

                Int = rand.Int(),
                ArrInt = Arr(5, rand.Int),

                Uint = rand.Uint(),
                ArrUint = Arr(5, rand.Uint),

                Long = rand.Long(),
                ArrLong = Arr(5, rand.Long),

                Ulong = rand.Ulong(),
                ArrUlong = Arr(5, rand.Ulong),

                Float = rand.Float(),
                ArrFloat = Arr(5, rand.Float),

                Double = rand.Double(),
                ArrDouble = Arr(5, rand.Double),

                Decimal = rand.Decimal(),
                ArrDecimal = Arr(5, rand.Decimal),

                False = false,
                ArrFalse = Arr(5, () => false),
                True = true,
                ArrTrue = Arr(5, () => true),

                String = rand.String(),
                ArrString = Arr(5, rand.String),
                Char = rand.Char(),
                ArrChar= Arr(5, rand.Char),

                DateTime = DateTime.UtcNow,
                ArrDateTime = Arr(5, () => DateTime.UtcNow),
                Nullable = null,
                ArrNullable = Arr<SimpleClass>(5, () => null),

                NestedClass = SimpleClass.Create(rand),
                ArrNestedClass = Arr(5, () => SimpleClass.Create(rand))
            };
        }
    }

    static T[] Arr<T>(int count, Func<T> creator)
    {
        T[] arr = new T[count];
        for (int i = 0; i < count; i++)
        {
            arr[i] = creator();
        }

        return arr;
    }
}

using Bogus;
using System.Text;

namespace JsonBenchmark.Net.Tools;

public class Rand
{
    readonly Random random;
    readonly Faker faker;

    public Rand(int seed)
    {
        random = new(seed);
        faker = new();
    }

    public DayOfWeek DayOfWeek() => (DayOfWeek)random.Next(0, 6);

    public string String() => faker.Name.FullName();

    public char Char() => (char)random.Next(0, 65000);
    
    public sbyte Sbyte() => (sbyte)random.Next();
    public byte Byte() => (byte)random.Next();

    public short Short() => (short)random.Next();
    public ushort Ushort() => (ushort)random.Next();

    public int Int() => (int)random.Next();
    public uint Uint() => (uint)random.Next();

    public long Long() => (long)random.Next();
    public ulong Ulong() => (ulong)random.Next();

    public float Float() => (short)random.Next() + (float)random.NextDouble();
    public double Double() => random.Next() + random.NextDouble();
    public decimal Decimal() => random.Next() + (decimal)random.NextDouble();
}

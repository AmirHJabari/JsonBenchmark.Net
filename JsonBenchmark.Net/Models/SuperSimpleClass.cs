using JsonBenchmark.Net.Tools;

namespace JsonBenchmark.Net.Models;

public class SuperSimpleClass
{
    public int Age { get; set; }
    public string Name { get; set; }

    public static SuperSimpleClass Create(Rand rand = null!)
    {
        rand ??= new Rand(28115235);

        unchecked
        {
            return new SuperSimpleClass
            {
                Age = rand.Int(),
                Name = rand.String(),
            };
        }
    }
}

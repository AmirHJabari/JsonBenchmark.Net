Benchmark for de/serializing different objects with multiple tools:
* `Jil`
* `NetJSON`
* `Newtonsoft.Json`
* `SpanJson`
* `Utf8Json`
* `System.Text.Json`

Objects:
* [SuperSimple](https://github.com/AmirHJabari/JsonBenchmark.Net#super-simple-object)
* [Simple](https://github.com/AmirHJabari/JsonBenchmark.Net#simple-object)
* [Complex](https://github.com/AmirHJabari/JsonBenchmark.Net#complex-object)

Definitely in different object types and different scenarios the result can vary but in general `SpanJson` wins both in execution time (faster) as well as memory allocation (less allocation).

**Note:** System.Text.Json source generator tested as well but there were not big enhancements in these 3 cases (SuperSimple/Simple/Complex objects) so I removed it.

<br/>

## Super Simple object:

object:
```json
{
    "Age": 20,
    "Name": "Amir H. Jabari"
}
```

<br/>

SERIALIZATION:

|                Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Rank |   Gen0 |   Gen1 | Allocated | Alloc Ratio |
|---------------------- |----------:|----------:|----------:|------:|--------:|-----:|-------:|-------:|----------:|------------:|
|            Jil_String | 170.60 ns |  64.86 ns |  3.555 ns |  1.46 |    0.09 |    6 | 0.0648 |      - |     544 B |        8.50 |
|        NetJSON_String | 116.14 ns |  40.90 ns |  2.242 ns |  0.99 |    0.02 |    3 | 0.0172 |      - |     144 B |        2.25 |
|     Newtonsoft_String | 456.76 ns |  57.11 ns |  3.130 ns |  3.90 |    0.16 |    9 | 0.1693 | 0.0005 |    1416 B |       22.12 |
|       SpanJson_String | 145.58 ns |  25.69 ns |  1.408 ns |  1.24 |    0.05 |    5 | 0.0200 |      - |     168 B |        2.62 |
| SystemTextJson_String | 203.68 ns |  29.35 ns |  1.609 ns |  1.74 |    0.06 |    7 | 0.0124 |      - |     104 B |        1.62 |
|       Utf8Json_String |  91.63 ns |  36.81 ns |  2.018 ns |  0.78 |    0.01 |    2 | 0.0124 |      - |     104 B |        1.62 |
|             Jil_Bytes | 206.99 ns |  64.40 ns |  3.530 ns |  1.77 |    0.05 |    8 | 0.0744 |      - |     624 B |        9.75 |
|         NetJSON_Bytes | 142.34 ns |  61.43 ns |  3.367 ns |  1.22 |    0.06 |    4 | 0.0257 |      - |     216 B |        3.38 |
|      Newtonsoft_Bytes | 521.04 ns | 450.81 ns | 24.710 ns |  4.45 |    0.32 |   10 | 0.1774 |      - |    1488 B |       23.25 |
|        SpanJson_Bytes | 117.17 ns |  88.43 ns |  4.847 ns |  1.00 |    0.00 |    3 | 0.0076 |      - |      64 B |        1.00 |
|  SystemTextJson_Bytes | 206.61 ns |  82.88 ns |  4.543 ns |  1.77 |    0.11 |    8 | 0.0086 |      - |      72 B |        1.12 |
|        Utf8Json_Bytes |  89.94 ns | 213.25 ns | 11.689 ns |  0.77 |    0.12 |    1 | 0.0086 |      - |      72 B |        1.12 |

<br/>

DESERIALIZATION:

|                Method |        Mean |      Error |    StdDev | Ratio | RatioSD | Rank |   Gen0 |   Gen1 | Allocated | Alloc Ratio |
|---------------------- |------------:|-----------:|----------:|------:|--------:|-----:|-------:|-------:|----------:|------------:|
|            Jil_String |   125.96 ns |  52.524 ns |  2.879 ns |  1.36 |    0.03 |    2 | 0.0210 |      - |     176 B |        2.00 |
|        NetJSON_String |   218.51 ns | 110.288 ns |  6.045 ns |  2.36 |    0.06 |    7 | 0.0238 |      - |     200 B |        2.27 |
|     Newtonsoft_String |   980.56 ns | 409.723 ns | 22.458 ns | 10.58 |    0.18 |   11 | 0.3204 |      - |    2688 B |       30.55 |
|       SpanJson_String |   127.85 ns |   7.664 ns |  0.420 ns |  1.38 |    0.01 |    3 | 0.0172 |      - |     144 B |        1.64 |
| SystemTextJson_String |   323.74 ns | 167.956 ns |  9.206 ns |  3.49 |    0.09 |   10 | 0.0095 |      - |      80 B |        0.91 |
|       Utf8Json_String |   171.97 ns |  87.940 ns |  4.820 ns |  1.85 |    0.05 |    6 | 0.0172 |      - |     144 B |        1.64 |
|             Jil_Bytes |   160.76 ns |   7.743 ns |  0.424 ns |  1.73 |    0.01 |    5 | 0.0343 |      - |     288 B |        3.27 |
|         NetJSON_Bytes |   243.69 ns |  32.301 ns |  1.771 ns |  2.63 |    0.03 |    8 | 0.0343 |      - |     288 B |        3.27 |
|      Newtonsoft_Bytes | 1,181.75 ns | 624.721 ns | 34.243 ns | 12.75 |    0.30 |   12 | 0.3376 | 0.0019 |    2824 B |       32.09 |
|        SpanJson_Bytes |    92.71 ns |  10.329 ns |  0.566 ns |  1.00 |    0.00 |    1 | 0.0105 |      - |      88 B |        1.00 |
|  SystemTextJson_Bytes |   274.26 ns | 404.983 ns | 22.198 ns |  2.96 |    0.25 |    9 | 0.0105 |      - |      88 B |        1.00 |
|        Utf8Json_Bytes |   129.51 ns |  19.648 ns |  1.077 ns |  1.40 |    0.00 |    4 | 0.0095 |      - |      80 B |        0.91 |

<br/>

## Simple object:
object:
```json
{
  "DayOfWeek": "Monday",
  "Guid": "2517056e-a9b1-43ce-8287-0fa2db6a9431",
  "Sbyte": 115,
  "Byte": 87,
  "Short": -6802,
  "Ushort": 54753,
  "Int": 1631550698,
  "Uint": 541273253,
  "Long": 693967912,
  "Ulong": 178489719,
  "Float": -25660.783,
  "Double": 1205673527.7033145,
  "Decimal": 1341589533.480338932238677,
  "String": "Corene Muller",
  "Char": "\uC91C",
  "False": false,
  "True": true,
  "DateTime": "2023-08-09T08:44:27.0601407Z",
  "Nullable": null
}
```

SERIALIZATION:

|                Method |       Mean |     Error |   StdDev | Ratio | RatioSD | Rank |   Gen0 |   Gen1 | Allocated | Alloc Ratio |
|---------------------- |-----------:|----------:|---------:|------:|--------:|-----:|-------:|-------:|----------:|------------:|
|            Jil_String |   941.9 ns |  88.30 ns |  4.84 ns |  1.22 |    0.04 |    3 | 0.3452 | 0.0019 |    2888 B |        7.08 |
|        NetJSON_String | 1,230.7 ns | 180.51 ns |  9.89 ns |  1.60 |    0.03 |    7 | 0.1945 |      - |    1640 B |        4.02 |
|     Newtonsoft_String | 2,687.0 ns | 213.64 ns | 11.71 ns |  3.49 |    0.11 |   11 | 0.4463 |      - |    3736 B |        9.16 |
|       SpanJson_String |   889.0 ns |  26.26 ns |  1.44 ns |  1.16 |    0.03 |    2 | 0.1411 |      - |    1184 B |        2.90 |
| SystemTextJson_String | 1,535.0 ns | 419.02 ns | 22.97 ns |  2.00 |    0.04 |   10 | 0.0992 |      - |     840 B |        2.06 |
|       Utf8Json_String | 1,126.7 ns | 125.08 ns |  6.86 ns |  1.46 |    0.03 |    6 | 0.1144 |      - |     960 B |        2.35 |
|             Jil_Bytes | 1,086.7 ns | 624.21 ns | 34.21 ns |  1.41 |    0.06 |    5 | 0.3948 | 0.0019 |    3312 B |        8.12 |
|         NetJSON_Bytes | 1,408.1 ns | 649.14 ns | 35.58 ns |  1.83 |    0.09 |    8 | 0.2422 |      - |    2032 B |        4.98 |
|      Newtonsoft_Bytes | 2,669.1 ns | 859.07 ns | 47.09 ns |  3.47 |    0.14 |   11 | 0.4921 |      - |    4144 B |       10.16 |
|        SpanJson_Bytes |   769.6 ns | 407.25 ns | 22.32 ns |  1.00 |    0.00 |    1 | 0.0486 |      - |     408 B |        1.00 |
|  SystemTextJson_Bytes | 1,432.3 ns |  77.61 ns |  4.25 ns |  1.86 |    0.05 |    9 | 0.0534 |      - |     448 B |        1.10 |
|        Utf8Json_Bytes |   998.7 ns |  85.47 ns |  4.68 ns |  1.30 |    0.04 |    4 | 0.0687 |      - |     584 B |        1.43 |

<br/>

DESERIALIZATION:

|                Method |       Mean |       Error |    StdDev | Ratio | RatioSD | Rank |   Gen0 | Allocated | Alloc Ratio |
|---------------------- |-----------:|------------:|----------:|------:|--------:|-----:|-------:|----------:|------------:|
|            Jil_String | 1,672.8 ns |   226.88 ns |  12.44 ns |  1.84 |    0.01 |    5 | 0.0648 |     544 B |        3.09 |
|        NetJSON_String | 2,687.4 ns |   359.09 ns |  19.68 ns |  2.96 |    0.03 |    9 | 0.2060 |    1752 B |        9.95 |
|     Newtonsoft_String | 5,077.5 ns |   412.17 ns |  22.59 ns |  5.59 |    0.04 |   11 | 0.4272 |    3600 B |       20.45 |
|       SpanJson_String | 1,030.2 ns |   126.57 ns |   6.94 ns |  1.13 |    0.01 |    2 | 0.0725 |     608 B |        3.45 |
| SystemTextJson_String | 2,002.5 ns |   213.21 ns |  11.69 ns |  2.20 |    0.01 |    8 | 0.0191 |     176 B |        1.00 |
|       Utf8Json_String | 1,614.4 ns |    84.65 ns |   4.64 ns |  1.78 |    0.01 |    4 | 0.0839 |     704 B |        4.00 |
|             Jil_Bytes | 1,841.1 ns |   322.56 ns |  17.68 ns |  2.03 |    0.02 |    6 | 0.1621 |    1360 B |        7.73 |
|         NetJSON_Bytes | 2,962.1 ns |   503.19 ns |  27.58 ns |  3.26 |    0.04 |   10 | 0.3052 |    2560 B |       14.55 |
|      Newtonsoft_Bytes | 5,328.8 ns |   631.81 ns |  34.63 ns |  5.86 |    0.05 |   12 | 0.5264 |    4440 B |       25.23 |
|        SpanJson_Bytes |   909.0 ns |    50.73 ns |   2.78 ns |  1.00 |    0.00 |    1 | 0.0210 |     176 B |        1.00 |
|  SystemTextJson_Bytes | 1,936.0 ns | 2,170.74 ns | 118.99 ns |  2.13 |    0.13 |    7 | 0.0210 |     176 B |        1.00 |
|        Utf8Json_Bytes | 1,504.3 ns |   224.11 ns |  12.28 ns |  1.65 |    0.01 |    3 | 0.0324 |     280 B |        1.59 |

<br/>

## Complex object:
object:
```json
{
  "DayOfWeek": "Monday",
  "ArrDayOfWeek": [...],
  "Guid": "a57fa617-6de3-4f0c-baa7-15d24b78450e",
  "ArrGuid": [...],
  "Sbyte": -91,
  "Byte": 22,
  "ArrSbyte": [...],
  "ArrByte": [...],
  "Short": -11190,
  "Ushort": 3155,
  "ArrShort": [...],
  "ArrUshort": [...],
  "Int": 322109475,
  "Uint": 935014617,
  "ArrInt": [...],
  "ArrUint": [...],
  "Long": 11825110,
  "Ulong": 1589199871,
  "ArrLong": [...],
  "ArrUlong": [...],
  "Float": 24319.451,
  "Double": 963420005.2432929,
  "Decimal": 447680652.812708440149533,
  "ArrFloat": [...],
  "ArrDouble": [...],
  "ArrDecimal": [...],
  "String": "Chanel Watsica",
  "Char": "\uA645",
  "ArrString": [...],
  "ArrChar": [...],
  "False": false,
  "True": true,
  "ArrFalse": [...],
  "ArrTrue": [...],
  "DateTime": "2023-08-09T08:46:02.1238559Z",
  "Nullable": null,
  "ArrDateTime": [...],
  "ArrNullable": [...],
  "NestedClass": {
    "DayOfWeek": "Thursday",
    "Guid": "1feae83b-d1a0-4abf-9cc5-607e7e1d25dd",
    "Sbyte": 65,
    "Byte": 96,
    "Short": 11441,
    "Ushort": 39016,
    "Int": 1852719280,
    "Uint": 1823129087,
    "Long": 1169426995,
    "Ulong": 1700782883,
    "Float": -22957.865,
    "Double": 685910393.3421444,
    "Decimal": 429821250.70247557605732,
    "String": "Hobart Cormier",
    "Char": "\uCBF9",
    "False": false,
    "True": true,
    "DateTime": "2023-08-09T08:46:02.1246572Z",
    "Nullable": null
  },
  "ArrNestedClass": [...]
}
```

<br/>

SERIALIZATION:

|                Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Rank |   Gen0 |   Gen1 | Allocated | Alloc Ratio |
|---------------------- |----------:|----------:|----------:|------:|--------:|-----:|-------:|-------:|----------:|------------:|
|            Jil_String |  9.812 μs | 2.8459 μs | 0.1560 μs |  1.16 |    0.01 |    3 | 2.7008 | 0.1068 |   22.1 KB |        5.48 |
|        NetJSON_String | 14.176 μs | 4.1052 μs | 0.2250 μs |  1.68 |    0.02 |    7 | 2.2125 |      - |  18.12 KB |        4.49 |
|     Newtonsoft_String | 30.533 μs | 1.9727 μs | 0.1081 μs |  3.61 |    0.01 |   11 | 3.6621 | 0.0916 |  30.17 KB |        7.48 |
|       SpanJson_String |  9.528 μs | 3.7369 μs | 0.2048 μs |  1.13 |    0.02 |    2 | 1.4648 |      - |  12.07 KB |        2.99 |
| SystemTextJson_String | 16.099 μs | 1.6895 μs | 0.0926 μs |  1.90 |    0.01 |   10 | 1.0681 |      - |   8.96 KB |        2.22 |
|       Utf8Json_String | 12.726 μs | 1.6417 μs | 0.0900 μs |  1.50 |    0.00 |    6 | 1.2207 |      - |  10.03 KB |        2.49 |
|             Jil_Bytes | 10.682 μs | 0.6454 μs | 0.0354 μs |  1.26 |    0.01 |    4 | 3.1433 | 0.0916 |   25.7 KB |        6.38 |
|         NetJSON_Bytes | 15.193 μs | 3.2670 μs | 0.1791 μs |  1.80 |    0.01 |    8 | 2.7008 |      - |  22.12 KB |        5.49 |
|      Newtonsoft_Bytes | 31.931 μs | 3.7113 μs | 0.2034 μs |  3.77 |    0.01 |   12 | 4.1504 | 0.1221 |  34.23 KB |        8.49 |
|        SpanJson_Bytes |  8.460 μs | 0.7523 μs | 0.0412 μs |  1.00 |    0.00 |    1 | 0.4883 |      - |   4.03 KB |        1.00 |
|  SystemTextJson_Bytes | 15.605 μs | 0.8849 μs | 0.0485 μs |  1.84 |    0.01 |    9 | 0.5798 |      - |   4.79 KB |        1.19 |
|        Utf8Json_Bytes | 11.687 μs | 1.1750 μs | 0.0644 μs |  1.38 |    0.01 |    5 | 0.7324 |      - |   5.98 KB |        1.48 |

<br/>

DESERIALIZATION:

|                Method |     Mean |     Error |   StdDev | Ratio | RatioSD | Rank |   Gen0 |   Gen1 | Allocated | Alloc Ratio |
|---------------------- |---------:|----------:|---------:|------:|--------:|-----:|-------:|-------:|----------:|------------:|
|            Jil_String | 21.58 μs |  1.104 μs | 0.061 μs |  1.63 |    0.02 |    3 | 1.0986 |      - |   9.04 KB |        3.32 |
|        NetJSON_String | 32.94 μs |  1.775 μs | 0.097 μs |  2.48 |    0.03 |    9 | 2.6245 |      - |  21.64 KB |        7.96 |
|     Newtonsoft_String | 62.99 μs | 37.604 μs | 2.061 μs |  4.75 |    0.18 |   11 | 2.1973 |      - |  17.97 KB |        6.61 |
|       SpanJson_String | 16.75 μs | 11.188 μs | 0.613 μs |  1.26 |    0.04 |    2 | 0.8392 | 0.0153 |   6.89 KB |        2.53 |
| SystemTextJson_String | 29.37 μs |  1.974 μs | 0.108 μs |  2.21 |    0.01 |    7 | 0.7324 |      - |   6.02 KB |        2.22 |
|       Utf8Json_String | 25.99 μs | 16.012 μs | 0.878 μs |  1.96 |    0.06 |    5 | 1.1292 |      - |   9.45 KB |        3.47 |
|             Jil_Bytes | 26.60 μs |  5.495 μs | 0.301 μs |  2.00 |    0.04 |    6 | 2.1057 | 0.0610 |  17.28 KB |        6.36 |
|         NetJSON_Bytes | 39.10 μs |  4.721 μs | 0.259 μs |  2.95 |    0.01 |   10 | 3.6621 |      - |  29.91 KB |       11.00 |
|      Newtonsoft_Bytes | 73.24 μs | 20.680 μs | 1.134 μs |  5.52 |    0.04 |   12 | 3.1738 | 0.1221 |  26.21 KB |        9.64 |
|        SpanJson_Bytes | 13.27 μs |  2.194 μs | 0.120 μs |  1.00 |    0.00 |    1 | 0.3204 |      - |   2.72 KB |        1.00 |
|  SystemTextJson_Bytes | 30.02 μs | 23.686 μs | 1.298 μs |  2.26 |    0.12 |    8 | 0.7324 |      - |   6.02 KB |        2.21 |
|        Utf8Json_Bytes | 22.10 μs |  5.922 μs | 0.325 μs |  1.66 |    0.03 |    4 | 0.6409 |      - |   5.33 KB |        1.96 |

<br/>

## Contribution
Any contribution is appreciated.

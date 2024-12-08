using Spectre.Console;
using SpeedHash.Benchmarks;
using System.IO;


namespace SpeedHash;

class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[bold yellow]Vítejte v nástroji SpeedHash Benchmark![/]");
        Console.WriteLine();

        var dataSizes = new[] { 10, 20, 50, 100 };
        var resultsDictionary = new Dictionary<int, Dictionary<string, long>>();
        var benchmarks = new IHashBenchmark[] { new Md5Benchmark(), new Sha1Benchmark(), new Sha256Benchmark(), new Sha512Benchmark(), new Blake2bBenchmark()  };

        var statusConsole = AnsiConsole.Status()
            .AutoRefresh(true)
            .Spinner(Spinner.Known.Default)
            .SpinnerStyle(Style.Parse("green"));

        statusConsole.Start("Spouštění benchmarků...", ctx => 
        {
            foreach (var dataSize in dataSizes)
            {
                ctx.Status($"Provádění benchmarků pro {dataSize} bajtů");
                ctx.Spinner(Spinner.Known.Dots);

                var results = RunAll(TimeSpan.FromSeconds(20), dataSize, benchmarks);

                resultsDictionary[dataSize] = results;
            }
        });

        var table = new Table().AddColumn("Počet bajtů");
        foreach (var benchmark in benchmarks)
        {
            table.AddColumn(benchmark.GetType().Name.Replace("Benchmark", ""));
        }

        foreach (var result in resultsDictionary)
        {
            var row = new List<string> { result.Key.ToString() };
            foreach (var benchResult in result.Value)
            {
                row.Add(benchResult.Value.ToString());
            }
            table.AddRow(row.ToArray());
        }

        AnsiConsole.Write(table);
        SaveResultsToCsv(resultsDictionary);
        Console.ReadLine();
    }

    static void SaveResultsToCsv(Dictionary<int, Dictionary<string, long>> resultsDictionary)
    {
        var fileName = $"BenchmarkResults_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
        using (var writer = new StreamWriter(fileName))
        {
            writer.WriteLine("DataSize," + string.Join(",", resultsDictionary.First().Value.Keys));

            // Write the data
            foreach (var result in resultsDictionary)
            {
                var dataSize = result.Key;
                var lineData = new List<string> { dataSize.ToString() };
                lineData.AddRange(result.Value.Values.Select(value => value.ToString()));
                writer.WriteLine(string.Join(",", lineData));
            }
        }
        AnsiConsole.MarkupLine($"[bold green]Výsledky uloženy do {fileName}[/]");
    }

    static Dictionary<string, long> RunAll(TimeSpan duration, int dataSize, IHashBenchmark[] benchmarks)
    {
        var results = new Dictionary<string, long>();

        foreach (var benchmark in benchmarks)
        {
            results[benchmark.GetType().Name] = BenchmarkExecutor.RunBenchmark(benchmark, duration, dataSize);
            AnsiConsole.MarkupLine($"[green]{benchmark.GetType().Name.Replace("Benchmark", "")} dokončeno pro {dataSize} bajtů[/]");
        }
        return results;
    }
}
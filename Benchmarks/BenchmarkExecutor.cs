namespace SpeedHash.Benchmarks;

public class BenchmarkExecutor
{
    public static long RunBenchmark(IHashBenchmark benchmark, TimeSpan duration, int dataSize)
    {
        long hashCount = 0;
        byte[] data = new byte[dataSize];
        new Random().NextBytes(data);

        DateTime endTime = DateTime.UtcNow.Add(duration);

        while (DateTime.UtcNow < endTime)
        {
            benchmark.ComputeHash(data);
            hashCount++;
        }

        return hashCount;
    }
}
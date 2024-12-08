using System.Security.Cryptography;

namespace SpeedHash.Benchmarks;

public class Md5Benchmark : IHashBenchmark
{
    private readonly MD5 _md5 = MD5.Create();

    public void ComputeHash(byte[] data)
    {
        _md5.ComputeHash(data);
    }

    public long RunBenchmark(TimeSpan duration, int dataSize)
    {
        long hashCount = 0;
        byte[] data = new byte[dataSize];
        new Random().NextBytes(data);

        DateTime endTime = DateTime.UtcNow.Add(duration);
        while (DateTime.UtcNow < endTime)
        {
            ComputeHash(data);
            hashCount++;
        }

        return hashCount;
    }
}
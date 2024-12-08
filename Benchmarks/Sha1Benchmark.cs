using System.Security.Cryptography;

namespace SpeedHash.Benchmarks;

public class Sha1Benchmark : IHashBenchmark
{
    private readonly SHA1 _sha1 = SHA1.Create();

    public void ComputeHash(byte[] data)
    {
        _sha1.ComputeHash(data);
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
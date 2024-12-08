using System.Security.Cryptography;

namespace SpeedHash.Benchmarks;

public class Sha256Benchmark : IHashBenchmark
{
    private readonly SHA256 _sha256 = SHA256.Create();

    public void ComputeHash(byte[] data)
    {
        // Compute the hash
        _sha256.ComputeHash(data);
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
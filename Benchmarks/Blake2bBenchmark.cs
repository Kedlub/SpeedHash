using NSec.Cryptography;

namespace SpeedHash.Benchmarks;

public class Blake2bBenchmark : IHashBenchmark
{
    private readonly Blake2b _blake2b = new Blake2b();

    public void ComputeHash(byte[] data)
    {
        // Compute the hash using nsec.cryptography for Blake2b
        byte[] hash = _blake2b.Hash(data);
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
using System.Security.Cryptography;

namespace SpeedHash.Benchmarks;

public class Sha1Benchmark : IHashBenchmark
{
    private readonly SHA1 _sha1 = SHA1.Create();

    public void ComputeHash(byte[] data)
    {
        _sha1.ComputeHash(data);
    }
}
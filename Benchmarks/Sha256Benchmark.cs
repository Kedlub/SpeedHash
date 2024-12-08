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
}
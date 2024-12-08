using System.Security.Cryptography;

namespace SpeedHash.Benchmarks;

public class Sha512Benchmark : IHashBenchmark
{
    private readonly SHA512 _sha512 = SHA512.Create();

    public void ComputeHash(byte[] data)
    {
        _sha512.ComputeHash(data);
    }
}
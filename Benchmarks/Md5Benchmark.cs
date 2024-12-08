using System.Security.Cryptography;

namespace SpeedHash.Benchmarks;

public class Md5Benchmark : IHashBenchmark
{
    private readonly MD5 _md5 = MD5.Create();

    public void ComputeHash(byte[] data)
    {
        _md5.ComputeHash(data);
    }
}
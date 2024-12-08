namespace SpeedHash;

public interface IHashBenchmark
{
    // Perform a single hash computation
    void ComputeHash(byte[] data);
}

namespace SpeedHash;

public interface IHashBenchmark
{
    // Perform a single hash computation
    void ComputeHash(byte[] data);

    // Start the benchmarking process and return the number of computations within the given time
    long RunBenchmark(TimeSpan duration, int dataSize = 1024);
}

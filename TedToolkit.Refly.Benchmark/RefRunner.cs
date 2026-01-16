using BenchmarkDotNet.Attributes;

namespace TedToolkit.Refly.Benchmark;

/// <summary>
///
/// </summary>
[MemoryDiagnoser]
public class RefRunner
{
    private static readonly BigStruct _value = default;

    /// <summary>
    ///
    /// </summary>
    [Benchmark(Baseline = true)]
    public void RefRun()
    {
        var item = new Ref<BigStruct>(_value);
        item.Value.DoSomething();
    }
}
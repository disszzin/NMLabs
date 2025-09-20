namespace NMLabs.Core.Interfaces;

public interface ILabSolver
{
    string Name { get; }
    int Number { get; }
    Task RunAsync();
}

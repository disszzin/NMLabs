namespace NMLabs.Core.Interfaces;

public interface IMathSolver<TInputData, TSolutionType>
{
    TSolutionType Solve(TInputData data);
}

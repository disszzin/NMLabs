namespace NMLabs.Core.Interfaces;

public interface IMathSolver<TInputData, TSolution>
{
    TSolution Solve(TInputData data);
}
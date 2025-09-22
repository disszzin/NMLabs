using NMLabs.Core.Interfaces;
using NMLabs.Labs.Lab1_Advection.Models;

namespace NMLabs.Labs.Lab1_Advection.Solvers;

public class CentralAdvectionSolver : IMathSolver<AdvectionParameters, (double[] X, List<double[]> History)>
{
    public (double[] X, List<double[]> History) Solve(AdvectionParameters data)
    {
        int n = (int)(data.X / data.Dx) + 1;
        double dt = data.CFL_Central * data.Dx / data.U;

        double[] T1 = new double[n];
        double[] T2 = new double[n];
        double[] xAxis = [.. Enumerable.Range(0, n).Select(i => i * data.Dx)];

        T1[0] = data.T0;
        T2[0] = data.T0;

        List<double[]> history = new();

        int iteration = 1;

        while (true)
        {
            for (int i = 1; i < n - 1; i++)
                T2[i] = T1[i] - data.U * dt / (2 * data.Dx) * (T1[i + 1] - T1[i - 1]);

            T2[n - 1] = T2[n - 2];

            if (iteration == 1 || iteration == 10)
            {
                history.Add((double[])T2.Clone());
                iteration = 1;
            }

            if (T2[n - 1] >= data.T0 / 2.0)
                break;

            Array.Copy(T2, T1, n);

            iteration++;
        }

        return (xAxis, history);
    }
}

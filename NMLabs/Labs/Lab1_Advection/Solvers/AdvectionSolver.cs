using NMLabs.Core.Interfaces;
using NMLabs.Labs.Lab1_Advection.Models;


namespace NMLabs.Labs.Lab1_Advection.Solvers;

public class AdvectionSolver : IMathSolver<AdvectionDataModel, (double[] X, double[] FinalTemperature, List<double[]> History)>
{
    public (double[] X, double[] FinalTemperature, List<double[]> History) Solve(AdvectionDataModel data)
    {
        double X = data.X;
        double dx = data.Dx;
        double u = data.U;
        double T0 = data.T0;
        double safetyFactor = data.SafetyFactor;

        int n = (int)(X / dx) + 1;
        double dt = safetyFactor * dx / u;

        double[] T1 = new double[n];
        double[] T2 = new double[n];
        double[] xCoordinates = new double[n];

        for (int i = 0; i < n; i++) 
        {
            xCoordinates[i] = i * dx;
        }

        T1[0] = T0;
        T2[0] = T0;

        List<double[]> history = new();
        int Lpr = 1;

        while (true) 
        {
            for (int i = 1; i < n; i++) 
            {
                T2[i] = T1[i] - u * dt / dx * (T1[i] - T1[i - 1]);
            }
            T2[n - 1] = T2[n - 2];

            if (Lpr == 1 || Lpr == 10)
                history.Add((double[])T2.Clone());

            Array.Copy(T2, T1, n);

            if (Math.Abs(T2[n - 1]) < T0 / 2.0)
            {
                Lpr++;
            }
            else
                break;
        }

        return (xCoordinates, T2, history);
    }
}

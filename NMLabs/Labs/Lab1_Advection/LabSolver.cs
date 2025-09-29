using NMLabs.Core.Interfaces;
using NMLabs.Core.Services;
using NMLabs.Core.Utilities;
using NMLabs.Labs.Lab1_Advection.Models;
using NMLabs.Labs.Lab1_Advection.Solvers;

namespace NMLabs.Labs.Lab1_Advection
{
    internal class LabSolver : ILabSolver
    {
        private readonly IPlotSevice _plotService;

        public string Name => "Анализ численного решения уравнения адвекции";

        public int Number => 1;

        public LabSolver(IPlotSevice plotService)
        {
            _plotService = plotService;
        }

        public async Task RunAsync()
        {
            Console.WriteLine($"Запуск лабораторной работы #{Number}: {Name}");
            Console.WriteLine("========================================================================================================================");


            var baseParams = new AdvectionParameters
            {
                X = InputHelper.GetDoubleFromConsole("Введите X: "),
                Dx = InputHelper.GetDoubleFromConsole("Введите dX: "),
                U = InputHelper.GetDoubleFromConsole("Введите U: "),
                T0 = InputHelper.GetDoubleFromConsole("Введите T0: "),
            };

            double CFL_Directional = InputHelper.GetDoubleFromConsole("Введите CFL для направленной разности: ");
            double CFL_Central = InputHelper.GetDoubleFromConsole("Введите CFL для центральной разности: ");

            int stepDirectional = InputHelper.GetIntFromConsole("Введите шаг построения для направленной разности: ");
            int stepCentral = InputHelper.GetIntFromConsole("Введите шаг построения для центральной разности: ");

            Console.WriteLine("Параметры расчета:");
            Console.WriteLine($"X = {baseParams.X}");
            Console.WriteLine($"dx = {baseParams.Dx}");
            Console.WriteLine($"u = {baseParams.U}");
            Console.WriteLine($"T0 = {baseParams.T0}");
            Console.WriteLine($"CFL Directional = {CFL_Directional}");
            Console.WriteLine($"CFL Central = {CFL_Central}");

            AdvectionParameters directionalParameters = baseParams.WithCFL(CFL_Directional).WithType(AdvectionParameters.AdvectionType.Directional);
            AdvectionParameters centralParameters = baseParams.WithCFL(CFL_Central).WithType(AdvectionParameters.AdvectionType.Central);

            var solver = new AdvectionSolver();
            var (xDir, historyDir) = solver.Solve(directionalParameters);
            var (xCen, historyCen) = solver.Solve(centralParameters);

            Console.WriteLine($"\nРасчет завершен. Получено {historyDir.Count} временных срезов для направленной и {historyCen.Count} временных срезов для центральной разности.");

            await PlotResults(xDir, historyDir, $"Изменение T по уравнению направленной разности при КФЛ={CFL_Directional}", stepDirectional);
            await PlotResults(xCen, historyCen, $"Изменение T по уравнению центральной разности при КФЛ={CFL_Directional}", stepCentral);
        }

        private Task PlotResults(double[] x, List<double[]> history, string label, int step) 
        {
            _plotService.CreatePlot(label);
            
            for (int i = 0; i < history.Count; i += step) 
            {
                _plotService.AddScatter(x, history[i], lineWidth: 2);
            }

            Console.WriteLine($"Открываю график \"{label}\"...");

            _plotService.ShowPlot();

            return Task.CompletedTask;
        }
    }
}

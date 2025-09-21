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

            var data = new AdvectionParameters
            {
                X = InputHelper.GetDoubleFromConsole("Введите X: "),
                Dx = InputHelper.GetDoubleFromConsole("Введите dX: "),
                U = InputHelper.GetDoubleFromConsole("Введите U: "),
                T0 = InputHelper.GetDoubleFromConsole("Введите T0: "),
                CFL_Directional = InputHelper.GetDoubleFromConsole("Введите CFL для направленной разности: "),
                CFL_Central = InputHelper.GetDoubleFromConsole("Введите CFL для центральной разности: "),
            };

            Console.WriteLine("Параметры расчета:");
            Console.WriteLine($"X = {data.X}");
            Console.WriteLine($"dx = {data.Dx}");
            Console.WriteLine($"u = {data.U}");
            Console.WriteLine($"T0 = {data.T0}");
            Console.WriteLine($"CFL Directional = {data.CFL_Directional}");
            Console.WriteLine($"CFL Central = {data.CFL_Central}");

            var directionalSolver = new DirectionalAdvectionSolver();
            var centralSolver = new CentralAdvectionSolver();
            var (xDir, historyDir) = directionalSolver.Solve(data);
            var (xCen, historyCen) = centralSolver.Solve(data);

            Console.WriteLine($"\nРасчет завершен. Получено {historyDir.Count} временных срезов для направленной и {historyCen.Count} временных срезов для центральной разности.");

            await PlotResults(xDir, historyDir, $"Изменение T по уравнению направленной разности при CFL={data.CFL_Directional}", "Directional", data);
            await PlotResults(xCen, historyCen, $"Изменение T по уравнению центральной разности при CFL={data.CFL_Central}", "Central", data);
        }

        private Task PlotResults(double[] x, List<double[]> history, string label, string fileMark, AdvectionParameters data) 
        {
            _plotService.CreatePlot(label);
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Purple, Color.Aquamarine, Color.Chocolate, Color.Gold, Color.HotPink, Color.Khaki };

            for (int i = 0; i < Math.Min(history.Count, 10); i++) 
            {
                string legendLabel = i == 0 ? "Шаг 1" : $"Шаг {i * 10}";
                _plotService.AddScatter(x, history[i], legendLabel, ScottPlot.Color.FromColor(colors[i % colors.Length]), lineWidth: 2);
            }
            _plotService.SavePlot($"lab1_{fileMark}.png");
            Console.WriteLine($"{label} сохранен: lab1_{fileMark}.png");

            _plotService.ShowPlot();

            return Task.CompletedTask;
        }
    }
}

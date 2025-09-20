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

            var data = new AdvectionDataModel
            {
                X = InputHelper.GetDoubleFromConsole("Введите X: "),
                Dx = InputHelper.GetDoubleFromConsole("Введите dX: "),
                U = InputHelper.GetDoubleFromConsole("Введите U: "),
                T0 = InputHelper.GetDoubleFromConsole("Введите T0: "),
                SafetyFactor = InputHelper.GetDoubleFromConsole("Введите SafetyFactor: "),
            };

            Console.WriteLine("Параметры расчета:");
            Console.WriteLine($"X = {data.X}");
            Console.WriteLine($"dx = {data.Dx}");
            Console.WriteLine($"u = {data.U}");
            Console.WriteLine($"T0 = {data.T0}");
            Console.WriteLine($"SafetyFactor = {data.SafetyFactor}");

            var solver = new AdvectionSolver();
            var (x, finalTemperature, history) = solver.Solve(data);

            Console.WriteLine($"\nРасчет завершен. Получено {history.Count} временных срезов.");

            await PlotResults(x, finalTemperature, history, data);
        }

        private async Task PlotResults(double[] x, double[] finalTemperature, List<double[]> history, AdvectionDataModel data) 
        {
            _plotService.CreatePlot("Финальное распределение температуры", "", "");
            _plotService.AddScatter(x, finalTemperature, ScottPlot.Color.FromColor(Color.Blue));
            _plotService.SavePlot("lab1_final.png");
            Console.WriteLine("График финального состояния сохранен: lab1_final.png");

            _plotService.CreatePlot("Эволюция распределения температуры", "", "");
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Purple };

            for (int i = 0; i < Math.Min(history.Count, 5); i++) 
            {
                //string label = i == 0 ? "Начальное состояние" : $"Шаг {i * 10}";
                _plotService.AddScatter(x, history[i], ScottPlot.Color.FromColor(colors[i % colors.Length]));
            }
            _plotService.SavePlot("lab1_evolution.png");
            Console.WriteLine("График эволюции сохранен: lab1_evolution.png");

            Console.WriteLine("\nАнализ результатов:");
            Console.WriteLine($"Максимальная температура: {finalTemperature.Max():F2} °C");
            Console.WriteLine($"Минимальная температура: {finalTemperature.Min():F2} °C");
            Console.WriteLine($"Скорость перемещения фронта: ~{data.U:F2} м/с");
            bool conditionMet = Math.Abs(finalTemperature[^1]) < data.T0 / 2.0;
            Console.WriteLine($"Условие остановки (T_end < T0/2): {conditionMet}");

            _plotService.ShowPlot();
        }
    }
}

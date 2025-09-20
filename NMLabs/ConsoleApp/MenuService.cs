using NMLabs.Core.Interfaces;

namespace NMLabs.ConsoleApp;

public class MenuService
{
    private readonly IEnumerable<ILabSolver> _labSolvers;

    public MenuService(IEnumerable<ILabSolver> labSolvers) 
    {
        _labSolvers = labSolvers.OrderBy(l => l.Number);
    }

    public async Task ShowMenuAsync() 
    {
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("Выберите лабораторную работу для запуска:");
            foreach (var lab in _labSolvers) 
            {
                Console.WriteLine($"{lab.Number}) {lab.Name}");
            }
            Console.WriteLine("0. Выход");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice == 0) 
            {
                Environment.Exit(0);
            }

            var selectedLab = _labSolvers.FirstOrDefault(l => l.Number == choice);

            if (selectedLab != null)
            {
                Console.Clear();
                await selectedLab.RunAsync();
                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
            else 
            {
                Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}

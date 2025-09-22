namespace NMLabs.Core.Utilities;

public static class InputHelper
{
    public static double GetDoubleFromConsole(string hint)
    {
        double result;
        Console.Write(hint);

        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите вещественное число.");
            Console.Write(hint);
        }
        return result;
    }
}
